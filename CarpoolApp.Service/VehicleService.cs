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
    public class VehicleService : IVehicleService
    {
        IBaseRepository<Vehicle> _repository;

        public VehicleService(IBaseRepository<Vehicle> _repo)            
        {
            _repository = _repo;
        }

        public async Task<Query<VehicleReadModifyDTO>> GetById(int Id)
        {
            try
            {
                if (!await _repository.AnyAsync(vehicle=>vehicle.Id== Id))
                {
                    return new Query<VehicleReadModifyDTO>(IsFound: false);
                }
                return new Query<VehicleReadModifyDTO>(Mapper.Map<VehicleReadModifyDTO>(await _repository.GetByIDAsync(Id)));
            }
            catch (Exception ex)
            {
                return new Query<VehicleReadModifyDTO>(Ex: ex);
            }
        }

        public async Task<Query<IEnumerable<VehicleReadModifyDTO>>> GetAllActiveAsync(string UserID)
        {
            try
            {
                if (!await _repository.AnyAsync(GetActivePredicate(UserID)))
                {
                    return new Query<IEnumerable<VehicleReadModifyDTO>>(IsFound: false);
                }
                return new Query<IEnumerable<VehicleReadModifyDTO>>(Mapper.Map<IEnumerable<VehicleReadModifyDTO>>(await _repository.GetAllAsync(GetActivePredicate(UserID))));
            }
            catch (Exception ex)
            {
                return new Query<IEnumerable<VehicleReadModifyDTO>>(Ex: ex);
            }
        }

        public async Task<Command> AddAsync(VehicleAddDTO T, string UserID)
        {
            try
            {
                T.OwnerName = UserID;

                var ModelState = DataAnnotationModelValidator.Validate(T);
                if (ModelState != null)
                {
                    return new Command(_modelState: ModelState);
                }

                if (await _repository.AnyAsync(GetDuplicatePredicate(T, UserID)))
                {
                    return new Command(IsDuplicate: true);
                }
                
                await _repository.AddAsync(Mapper.Map<Vehicle>(T));
                return new Command();
            }
            catch (Exception ex)
            {
                return new Command(Ex: ex);
            }
        }

        public async Task<Command> UpdateAsync(VehicleReadModifyDTO T, string UserID)
        {
            try
            {
                T.OwnerName = UserID;
                var ModelState = DataAnnotationModelValidator.Validate(T);

                if (ModelState != null)
                {
                    return new Command(_modelState: ModelState);
                }

                if (!await _repository.AnyAsync(v => v.Id == T.Id && v.IsActive && v.OwnerName== UserID))
                {
                    return new Command(IsFound: false);
                }

                if (await _repository.AnyAsync(GetDuplicatePredicateForModify(T,UserID)))
                {
                    return new Command(IsDuplicate: true);
                }

                await _repository.EditAsync(Mapper.Map<Vehicle>(T));
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
                if (!await _repository.AnyAsync(v => v.Id == Id && v.OwnerName == UserID && v.IsActive))
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

        private Expression<Func<Vehicle, bool>> GetActivePredicate(string UserID)
        {
            return v => v.OwnerName == UserID && v.IsActive;
        }

        private Expression<Func<Vehicle, bool>> GetDuplicatePredicate(VehicleAddDTO t, string userID)
        {
            return v => v.IsActive && v.OwnerName == userID && v.Name == t.Name;
        }

        private Expression<Func<Vehicle, bool>> GetDuplicatePredicateForModify(VehicleReadModifyDTO t, string userID)
        {
            return v => v.IsActive && v.OwnerName == userID && v.Name == t.Name && v.Id != t.Id;
        }
    }
}
