using CarpoolApp.Model.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolApp.Model.Entities
{
    [Table("TD.POST")]
    public class Post : ISoftDeletable
    {
        [Column("POST_ID")]
        public int? Id { get; set; }
        [Column("CAR_ID")]
        public int CarId { get; set; }
        [Column("DEPARTURE_TIME")]
        public DateTime? DepartureTime { get; set; }
        [Column("FROM_LOCATION_ID")]
        public int? FromLocationId { get; set; }
        [Column("TO_LOCATION_ID")]
        public int? ToLocationId { get; set; }
        [Column("FROM_LANDMARK")]
        public string FromLandmark { get; set; }
        [Column("TO_LANDMAKR")]
        public string ToLandmark { get; set; }
        [Column("NUMBER_OF_SEATS")]
        public int NumberOfSeats { get; set; }
        [Column("POST_STATUS_ID")]
        public int StatusId { get; set; }
        [Column("POST_CREATED_BY")]
        public string CreatedBy { get; set; }
        [Column("INSERTED_ON")]
        public DateTime? CreatedOn { get; set; }
        [Column("MODIFIED_ON")]
        public DateTime? UpdatedOn { get; set; }
        [Column("IS_CURRENT")]
        public bool IsActive { get; set; }
        [ForeignKey("FromLocationId")]
        public virtual Location FromLocation { get; set; }
        [ForeignKey("ToLocationId")]
        public virtual Location ToLocation { get; set; }
        [ForeignKey("CarId")]
        public virtual Vehicle Car { get; set; }
    }
}
