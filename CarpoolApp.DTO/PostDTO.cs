using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolApp.DTO
{
    public class PostAddDTO
    {   
        [Required(ErrorMessage ="Please Select Car")]
        public int? CarId { get; set; }        
        [Required(ErrorMessage ="Please Select Departure Time")]
        public DateTime? DepartureTime { get; set; }
        [Required(ErrorMessage = "Please Select From Location")]
        public int? FromLocationId { get; set; }
        [Required(ErrorMessage = "Please Select Destination")]
        public int? ToLocationId { get; set; }        
        public string FromLandmark { get; set; }        
        public string ToLandmark { get; set; }
        [Required(ErrorMessage = "Please Enter Number of Seats Available")]
        public int? NumberOfSeats { get; set; }
        [Required(ErrorMessage ="Please Enter Requestor Name")]
        public string CreatedBy { get; set; }
        public int StatusId { get; set; }        
    }

    public class PostReadModifyDTO: PostAddDTO,ISoftDeletable
    {        
        public int Id { get; set; }
        public LocationReadModifyDTO FromLocation { get; set; }
        public LocationReadModifyDTO ToLocation { get; set; }
        public VehicleReadModifyDTO Car { get; set; }
    }
}
