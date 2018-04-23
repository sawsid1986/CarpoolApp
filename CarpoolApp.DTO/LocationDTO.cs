using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolApp.DTO
{
    public class LocationAddDTO
    {
        public string Name { get; set; }
        public string City { get; set; }
    }

    public class LocationReadModifyDTO: LocationAddDTO, ISoftDeletable
    {
        public int Id { get; set; }
    }
}
