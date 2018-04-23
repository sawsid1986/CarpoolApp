using CarpoolApp.Core;
using CarpoolApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolApp.Service
{
    public interface IVehicleService
    {        
        Task<Query<IEnumerable<VehicleReadModifyDTO>>> GetAllActiveAsync(string UserID);
        Task<Query<VehicleReadModifyDTO>> GetById(int Id);
        Task<Command> AddAsync(VehicleAddDTO T, string UserID);
        Task<Command> UpdateAsync(VehicleReadModifyDTO T, string UserID);
        Task<Command> DeleteAsync(int Id, string UserID);
    }
}
