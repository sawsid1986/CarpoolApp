using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolApp.DTO
{
    public class VehicleAddDTO
    {
        [Required(ErrorMessage ="Please Enter Car Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Car Registration Number")]
        public string RegistrationNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Owner Name")]
        public string OwnerName { get; set; }
    }

    public class VehicleReadModifyDTO:VehicleAddDTO, ISoftDeletable
    {     
        public DateTime? AddedOn { get; set; }
        public int Id { get; set; }
    }
}
