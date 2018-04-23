using CarpoolApp.DTO;
using CarpoolApp.Model.Entities;
using CarpoolApp.Services.Test.BaseServiceTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarpoolApp.Service.BaseServices;
using CarpoolApp.Service;

namespace CarpoolApp.Services.Test
{
    class LocationServiceTest : BaseServiceTest<LocationAddDTO,LocationReadModifyDTO, Location>
    {
        protected override IQueryable<Location> GetMockData()
        {
            return new List<Location>() {
                new Location() {
                    Id=1,
                    Name="A",
                    City="P",
                    IsActive=true
                },
                new Location() {
                    Id=1,
                    Name="B",
                    City="P",
                    IsActive=true
                },
                new Location() {
                    Id=1,
                    Name="A",
                    City="Q",
                    IsActive=true
                },
                new Location() {
                    Id=1,
                    Name="C",
                    City="P",
                    IsActive=false
                }
            }.AsQueryable();
        }

        protected override BaseService<LocationAddDTO,LocationReadModifyDTO, Location> getService()
        {
            return new LocationService(_mockRepo);
        }

        protected static IQueryable<LocationAddDTO> ValidAddDTOTestData()
        {
            return new List<LocationAddDTO>() {
                new LocationAddDTO() {                    
                    Name="D",
                    City="P"
                },
                new LocationAddDTO() {                    
                    Name="B",
                    City="Q"
                },
                new LocationAddDTO() {
                    Name="C",
                    City="P"
                }
            }.AsQueryable();
        }

        protected static IQueryable<LocationAddDTO> DuplicateAddDTOTestData()
        {
            return new List<LocationAddDTO>() {
                new LocationAddDTO() {
                    Name="A",
                    City="P"
                },
                new LocationAddDTO() {
                    Name="A",
                    City="Q"
                }
            }.AsQueryable();
        }
    }
}
