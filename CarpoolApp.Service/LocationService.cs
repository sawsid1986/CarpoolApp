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

namespace CarpoolApp.Service
{
    public class LocationService:BaseService<LocationAddDTO,LocationReadModifyDTO,Location>,ILocationService
    {
        public LocationService(IBaseRepository<Location> repository) : base(repository)
        {
        }

        public async Task<Query<IEnumerable<LocationReadModifyDTO>>> GetByString(string Location)
        {
            return new Query<IEnumerable<LocationReadModifyDTO>>(Mapper.Map<IEnumerable<LocationReadModifyDTO>>(await _repository.GetAllAsync(loc => loc.Name.StartsWith(Location) && loc.IsActive)));            
        }

        protected override Expression<Func<Location, bool>> GetActivePredicate()
        {
            return loc => loc.IsActive;
        }

        protected override Expression<Func<Location, bool>> GetDuplicatePredicate(LocationAddDTO t)
        {
            return loc => loc.IsActive && loc.Name == t.Name && loc.City == t.City; 
        }

        protected override Expression<Func<Location, bool>> GetDuplicatePredicateForModify(LocationReadModifyDTO t)
        {
            return loc => loc.IsActive && loc.Name == t.Name && loc.City == t.City && loc.Id != t.Id;
        }        
    }
}
