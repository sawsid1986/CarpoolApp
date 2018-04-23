using CarpoolApp.Core;
using CarpoolApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolApp.Service
{
    public interface IPostService
    {
        Task<Query<IEnumerable<PostReadModifyDTO>>> GetAllActiveAsync(string UserID);
        Task<Command> AddAsync(PostAddDTO T, string UserID);
        Task<Command> UpdateAsync(PostReadModifyDTO T, string UserID);
        Task<Command> DeleteAsync(int Id, string UserID);
    }
}
