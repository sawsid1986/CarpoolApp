using CarpoolApp.Model.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolApp.Model.Entities
{
    [Table("TD.VEHICLE")]
    public class Vehicle:ISoftDeletable
    {
        [Column("VEHICLE_ID")]
        public int? Id { get; set; }
        [Column("VEHICLE_NAME")]
        public string Name { get; set; }
        [Column("VEHICLE_REGISTRATION_NUMBER")]
        public string RegistrationNumber { get; set; }
        [Column("VEHICLE_OWNER_NAME")]
        public string OwnerName { get; set; }
        [Column("INSERTED_ON")]
        public DateTime? CreatedOn { get; set; }
        [Column("MODIFIED_ON")]
        public DateTime? UpdatedOn { get; set; }
        [Column("IS_CURRENT")]
        public bool IsActive { get; set; }
    }
}
