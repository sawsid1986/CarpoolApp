using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolApp.Model.Entities.BaseEntities
{
    public interface ISoftDeletable
    {
        int? Id { get; set; }
        [Column("INSERTED_ON")]
        DateTime? CreatedOn { get; set; }
        [Column("MODIFIED_ON")]
        DateTime? UpdatedOn { get; set; }
        [Column("IS_CURRENT")]
        bool IsActive { get; set; }
    }
}

