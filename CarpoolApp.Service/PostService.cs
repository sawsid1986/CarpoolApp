using CarpoolApp.DTO;
using CarpoolApp.Model.Entities;
using CarpoolApp.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using CarpoolApp.Repositories.BaseRepositories;
using CarpoolApp.Core;
using AutoMapper;
using CarpoolApp.Service.Helpers;

namespace CarpoolApp.Service
{
    public class PostService :IPostService
    {
        IBaseRepository<Post> _repository;

        public PostService(IBaseRepository<Post> repository) 
        {
            _repository = repository;
        }

        public async Task<Query<IEnumerable<PostReadModifyDTO>>> GetAllActiveAsync(string UserID)
        {
            try
            {
                if (!await _repository.AnyAsync(GetActivePredicate(UserID)))
                {
                    return new Query<IEnumerable<PostReadModifyDTO>>(IsFound: false);
                }
                return new Query<IEnumerable<PostReadModifyDTO>>(Mapper.Map<IEnumerable<PostReadModifyDTO>>(await _repository.GetAllAsync(GetActivePredicate(UserID))));
            }
            catch (Exception ex)
            {
                return new Query<IEnumerable<PostReadModifyDTO>>(Ex: ex);
            }
        }

        public async Task<Command> AddAsync(PostAddDTO T, string UserID)
        {
            try
            {
                T.CreatedBy = UserID;
                var ModelState = DataAnnotationModelValidator.Validate(T);
                if (ModelState != null)
                {
                    return new Command(_modelState: ModelState);
                }

                if (await _repository.AnyAsync(GetDuplicatePredicate(T, UserID)))
                {
                    return new Command(IsDuplicate: true);
                }

                await _repository.AddAsync(Mapper.Map<Post>(T));
                return new Command();
            }
            catch (Exception ex)
            {
                return new Command(Ex: ex);
            }
        }

        public async Task<Command> UpdateAsync(PostReadModifyDTO T, string UserID)
        {
            try
            {
                T.CreatedBy = UserID;
                var ModelState = DataAnnotationModelValidator.Validate(T);

                if (ModelState != null)
                {
                    return new Command(_modelState: ModelState);
                }

                if (!await _repository.AnyAsync(v => v.Id == T.Id && v.IsActive && v.CreatedBy == UserID))
                {
                    return new Command(IsFound: false);
                }

                if (await _repository.AnyAsync(GetDuplicatePredicateForModify(T, UserID)))
                {
                    return new Command(IsDuplicate: true);
                }

                await _repository.EditAsync(Mapper.Map<Post>(T));
                return new Command();
            }
            catch (Exception ex)
            {
                return new Command(Ex: ex);
            }
        }

        public async Task<Command> DeleteAsync(int Id, string UserID)
        {
            try
            {
                if (!await _repository.AnyAsync(v => v.Id == Id &&  v.IsActive && v.CreatedBy == UserID))
                {
                    return new Command(IsFound: false);
                }

                await _repository.DeleteAsync(v => v.Id == Id);
                return new Command();
            }
            catch (Exception ex)
            {
                return new Command(Ex: ex);
            }
        }        

        private Expression<Func<Post, bool>> GetActivePredicate(string userID)
        {
            return post => post.IsActive && post.CreatedBy == userID;
        }

        private Expression<Func<Post, bool>> GetDuplicatePredicate(PostAddDTO t, string userID)
        {
            return post => false;
        }        

        private Expression<Func<Post, bool>> GetDuplicatePredicateForModify(PostReadModifyDTO t, string userID)
        {
            return post => false;
        }
    }
}
