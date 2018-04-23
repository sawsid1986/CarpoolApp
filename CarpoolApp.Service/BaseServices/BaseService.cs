using CarpoolApp.Model.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarpoolApp.Core;
using CarpoolApp.Repositories.BaseRepositories;
using AutoMapper;
using System.Linq.Expressions;
using System.Web.ModelBinding;
using CarpoolApp.Service.Helpers;
using CarpoolApp.DTO;

namespace CarpoolApp.Service.BaseServices
{
    public abstract class BaseService<TAddDTO, TReadModifyDTO, TEntity> : IBaseService<TAddDTO,TReadModifyDTO, TEntity>
        where TAddDTO:class
        where TReadModifyDTO : class, DTO.ISoftDeletable
        where TEntity : class, Model.Entities.BaseEntities.ISoftDeletable
    {
        protected IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        protected abstract Expression<Func<TEntity, bool>> GetActivePredicate();
        protected abstract Expression<Func<TEntity, bool>> GetDuplicatePredicate(TAddDTO t);
        protected abstract Expression<Func<TEntity, bool>> GetDuplicatePredicateForModify(TReadModifyDTO t);        

        public async Task<Query<IEnumerable<TReadModifyDTO>>> GetAllActiveAsync()
        {
            try
            {
                if (!await _repository.AnyAsync(GetActivePredicate()))
                {
                    return new Query<IEnumerable<TReadModifyDTO>>(IsFound: false);
                }
                return new Query<IEnumerable<TReadModifyDTO>>(Mapper.Map<IEnumerable<TReadModifyDTO>>(await _repository.GetAllAsync(GetActivePredicate())));
            }
            catch (Exception ex)
            {
                return new Query<IEnumerable<TReadModifyDTO>>(Ex: ex);
            }
        }

        public async Task<Query<IEnumerable<TReadModifyDTO>>> GetAllAsync()
        {
            try
            {                
                return new Query<IEnumerable<TReadModifyDTO>>(Mapper.Map<IEnumerable<TReadModifyDTO>>(await _repository.GetAllAsync()));
            }
            catch (Exception ex)
            {
                return new Query<IEnumerable<TReadModifyDTO>>(Ex: ex);
            }
        }

        public async Task<Command> AddAsync(TAddDTO T)
        {
            try
            {
                var ModelState = DataAnnotationModelValidator.Validate(T);
                
                if(ModelState!=null)
                {
                    return new Command(_modelState: ModelState);
                }       

                if (await _repository.AnyAsync(GetDuplicatePredicate(T)))
                {
                    return new Command(IsDuplicate: true);
                }

                await _repository.AddAsync(Mapper.Map<TEntity>(T));
                return new Command();
            }
            catch (Exception ex)
            {
                return new Command(Ex: ex);
            }
        }

        public async Task<Command> UpdateAsync(TReadModifyDTO T)
        {
            try
            {
                var ModelState = DataAnnotationModelValidator.Validate(T);

                if (ModelState != null)
                {
                    return new Command(_modelState: ModelState);
                }

                if(!await _repository.AnyAsync(v=>v.Id==T.Id))
                {
                    return new Command(IsFound:false);
                }

                if (await _repository.AnyAsync(GetDuplicatePredicateForModify(T)))
                {
                    return new Command(IsDuplicate: true);
                }

                await _repository.EditAsync(Mapper.Map<TEntity>(T));
                return new Command();
            }
            catch (Exception ex)
            {
                return new Command(Ex: ex);
            }
        }

        public async Task<Command> DeleteAsync(int Id)
        {
            try
            {
                if (!await _repository.AnyAsync(v => v.Id == Id))
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

        public async Task<Query<TReadModifyDTO>> GetById(int Id)
        {
            try
            {
                if (!await _repository.AnyAsync(v => v.Id == Id))
                {
                    return new Query<TReadModifyDTO>(IsFound: false);
                }
                
                return new Query<TReadModifyDTO>(Mapper.Map<TReadModifyDTO>(await _repository.GetByIDAsync(Id)));
            }
            catch (Exception ex)
            {
                return new Query<TReadModifyDTO>(Ex: ex);
            }
        }
    }
}
