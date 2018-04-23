using AutoMapper;
using CarpoolApp.DTO;
using CarpoolApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolApp.Service.Configuration
{
    public class AutoMapperServiceConfiguration
    {
        public static void InitializeAutomapper()
        {
            Mapper.Initialize(cfg => {
                //cfg.AddProfile<AppProfile>();
                cfg.CreateMap<Vehicle, VehicleReadModifyDTO>()
                    .ForMember(dest=>dest.AddedOn,opt=>opt.MapFrom(src=>src.CreatedOn))
                    .ReverseMap();
                cfg.CreateMap<VehicleAddDTO, Vehicle>();
                cfg.CreateMap<Location, LocationReadModifyDTO>()
                    .ReverseMap();
                cfg.CreateMap<LocationAddDTO, Location>();
                cfg.CreateMap<Post, PostReadModifyDTO>()
                    .ForMember(dest=>dest.Car,opt=>opt.MapFrom(src=>src.Car))
                    .ForMember(dest => dest.FromLocation, opt => opt.MapFrom(src => src.FromLocation))
                    .ForMember(dest => dest.ToLocation, opt => opt.MapFrom(src => src.ToLocation))
                    .ReverseMap();
                cfg.CreateMap<PostAddDTO, Post>();

            });
        }
    }
}
