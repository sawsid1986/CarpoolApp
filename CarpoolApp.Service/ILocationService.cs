using CarpoolApp.Core;
using CarpoolApp.DTO;
using CarpoolApp.Service.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolApp.Service
{
   public interface ILocationService
    {
        Task<Query<IEnumerable<LocationReadModifyDTO>>> GetByString(string Location);
    }
}
