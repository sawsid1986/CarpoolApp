using CarpoolApp.Model.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolApp.Model.Entities
{
    [Table("TD.REQUEST")]
    public class Request : ISoftDeletable
    {
        [Column("REQUEST_ID")]
        public int? Id { get; set; }
        [Column("REQUESTER_NAME")]
        public string Requester { get; set; }
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
        [Column("NUMBER_OF_SEATS_REQUESTED")]
        public int NumberOfSeats { get; set; }
        [Column("REQUEST_STATUS_ID")]
        public int StatusId { get; set; }
        [Column("INSERTED_ON")]
        public DateTime? CreatedOn { get; set; }
        [Column("MODIFIED_ON")]
        public DateTime? UpdatedOn { get; set; }
        [Column("IS_CURRENT")]
        public bool IsActive { get; set; }
    }
}
