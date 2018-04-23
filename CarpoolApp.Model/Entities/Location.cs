using CarpoolApp.Model.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolApp.Model.Entities
{
    [Table("TL.LOCATION")]
    public class Location : ISoftDeletable
    {
        [Column("LOCATION_ID")]
        public int? Id { get; set; }
        [Column("LOCATION_NAME")]
        public string Name { get; set; }
        [Column("LOCATION_CITY")]
        public string City { get; set; }        
        [Column("INSERTED_ON")]
        public DateTime? CreatedOn { get; set; }
        [Column("MODIFIED_ON")]
        public DateTime? UpdatedOn { get; set; }
        [Column("IS_CURRENT")]
        public bool IsActive { get; set; }
    }
}
