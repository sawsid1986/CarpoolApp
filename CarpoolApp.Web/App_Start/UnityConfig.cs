using CarpoolApp.DTO;
using CarpoolApp.Model.DbContexts;
using CarpoolApp.Model.Entities;
using CarpoolApp.Repositories.BaseRepositories;
using CarpoolApp.Service;
using CarpoolApp.Service.BaseServices;
using CarpoolApp.Web.Helpers;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CarpoolApp.Web
{
    public class UnityConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();

            //Context
            container.RegisterType<DbContext, CarpoolModel>();       

            //Repositories
            container.RegisterType<IBaseRepository<Vehicle>, BaseRepository<Vehicle>>();
            container.RegisterType<IBaseRepository<Location>, BaseRepository<Location>>();
            container.RegisterType<IBaseRepository<Post>, BaseRepository<Post>>();

            //Services
            container.RegisterType<IVehicleService, VehicleService>();
            container.RegisterType<ILocationService, LocationService>();
            container.RegisterType<IBaseService<LocationAddDTO,LocationReadModifyDTO, Location>, LocationService>();
            container.RegisterType<IPostService, PostService>();

            //Resolver
            config.DependencyResolver = new UnityResolver(container);           
        }
    }
}