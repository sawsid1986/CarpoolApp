using CarpoolApp.Core;
using CarpoolApp.DTO;
using CarpoolApp.Model.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolApp.Service.BaseServices
{
    public interface IBaseService<TAddDTO,TReadModifyDTO,TEntity>
        where TAddDTO:class
        where TReadModifyDTO: class, DTO.ISoftDeletable
        where TEntity: class, Model.Entities.BaseEntities.ISoftDeletable
    {
        Task<Query<IEnumerable<TReadModifyDTO>>> GetAllAsync();
        Task<Query<IEnumerable<TReadModifyDTO>>> GetAllActiveAsync();
        Task<Query<TReadModifyDTO>> GetById(int Id);
        Task<Command> AddAsync(TAddDTO T);
        Task<Command> UpdateAsync(TReadModifyDTO T);
        Task<Command> DeleteAsync(int Id);
    }
}
