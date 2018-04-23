using CarpoolApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolApp.Model.DbContexts
{
    public class CarpoolModel : DbContext
    {
        public CarpoolModel() : base("CarpoolModel")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
        }

        public virtual IDbSet<Vehicle> Vehicles { get; set; }
        public virtual IDbSet<Post> Posts { get; set; }
        public virtual IDbSet<Location> Locations { get; set; }
        public virtual IDbSet<Request> Requests { get; set; }
        public virtual IDbSet<Status> Statuses { get; set; }
    }
}
