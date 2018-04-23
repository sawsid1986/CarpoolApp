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
using NUnit.Framework;
using CarpoolApp.Service.Configuration;
using CarpoolApp.Services.Test.EFHelpers;
using NSubstitute;
using CarpoolApp.Model.DbContexts;
using CarpoolApp.Repositories.BaseRepositories;

namespace CarpoolApp.Services.Test
{
    [TestFixture]
    class VehicleServiceTest 
    {
        private BaseRepository<Vehicle> _mockRepo;
        
        #region TestData
        private IQueryable<Vehicle> GetMockData()
        {
            return new List<Vehicle> {
                new Vehicle
                {
                    Id=1,
                    Name="A",
                    OwnerName="S",
                    RegistrationNumber="12",
                    IsActive=true
                },
                new Vehicle {
                    Id=2,
                    Name="B",
                    OwnerName="S",
                    RegistrationNumber="12",
                    IsActive=true
                },
                new Vehicle {
                    Id=3,
                    Name="C",
                    OwnerName="S",
                    RegistrationNumber="12",
                    IsActive=true
                },
                new Vehicle {
                    Id=4,
                    Name="D",
                    OwnerName="S",
                    RegistrationNumber="12",
                    IsActive=false
                },
            }.AsQueryable();
        }

        public static IQueryable<TestVehicleAddDTO> ValidAddDTOTestData()
        {
            return new List<TestVehicleAddDTO>() {
                new TestVehicleAddDTO
                {
                    AddDTO=new VehicleAddDTO() {
                        Name="D",
                        RegistrationNumber="M"
                    },
                    UserId="S"
                },
                new TestVehicleAddDTO
                {
                    AddDTO=new VehicleAddDTO() {
                        Name="E",
                        RegistrationNumber="M"
                    },
                    UserId="S"
                },
                new TestVehicleAddDTO
                {
                    AddDTO=new VehicleAddDTO() {
                        Name="A",
                        RegistrationNumber="M"
                    },
                    UserId="R"
                }                
            }.AsQueryable();
        }

        public static IQueryable<TestVehicleAddDTO> InValidAddDTOTestData()
        {
            return new List<TestVehicleAddDTO>() {
                new TestVehicleAddDTO
                {
                    AddDTO=new VehicleAddDTO() {
                        Name="D",                        
                    },
                    UserId="S"
                },
                new TestVehicleAddDTO
                {
                    AddDTO=new VehicleAddDTO() {                        
                        RegistrationNumber="M"
                    },
                    UserId="S"
                },
                new TestVehicleAddDTO
                {
                    AddDTO=new VehicleAddDTO() {
                        Name="A",
                        RegistrationNumber="M"
                    }
                }
            }.AsQueryable();
        }

        public static IQueryable<TestVehicleAddDTO> DuplicateAddDTOTestData()
        {
            return new List<TestVehicleAddDTO>() {
                new TestVehicleAddDTO
                {
                    AddDTO=new VehicleAddDTO() {
                        Name="A",
                        RegistrationNumber="M"
                    },
                    UserId="S"
                },
                new TestVehicleAddDTO
                {
                    AddDTO=new VehicleAddDTO() {
                        Name="B",
                        RegistrationNumber="M"
                    },
                    UserId="S"
                }
            }.AsQueryable();            
        }

        public static IQueryable<TestVehicleReadModifyDTO> ValidUpdateDTOTestData()
        {
            return new List<TestVehicleReadModifyDTO>() {
                new TestVehicleReadModifyDTO
                {
                    ReadModifyDTO=new VehicleReadModifyDTO() {
                        Id=1,
                        Name="A",
                        RegistrationNumber="M"
                    },
                    UserId="S"
                },
                new TestVehicleReadModifyDTO
                {
                    ReadModifyDTO=new VehicleReadModifyDTO() {
                        Id=2,
                        Name="B",
                        RegistrationNumber="M"
                    },
                    UserId="S"
                }
            }.AsQueryable();
        }
                
        public static IQueryable<TestVehicleReadModifyDTO> InValidUpdateDTOTestData()
        {
            return new List<TestVehicleReadModifyDTO>() {
                new TestVehicleReadModifyDTO
                {
                    ReadModifyDTO=new VehicleReadModifyDTO() {                        
                        Name="A",
                        RegistrationNumber="M"
                    },
                    UserId="S"
                },
                new TestVehicleReadModifyDTO
                {
                    ReadModifyDTO=new VehicleReadModifyDTO() {
                        Id=1,                        
                        RegistrationNumber="M"
                    },
                    UserId="S"
                },
                new TestVehicleReadModifyDTO
                {
                    ReadModifyDTO=new VehicleReadModifyDTO() {
                        Id=1,
                        Name="A",                        
                    },
                    UserId="S"
                },
                new TestVehicleReadModifyDTO
                {
                    ReadModifyDTO=new VehicleReadModifyDTO() {
                        Id=1,
                        Name="A",
                        RegistrationNumber="M"
                    }                    
                }
            }.AsQueryable();
        }

        public static IQueryable<TestVehicleReadModifyDTO> DuplicateUpdateDTOTestData()
        {
            return new List<TestVehicleReadModifyDTO>() {
                new TestVehicleReadModifyDTO
                {
                    ReadModifyDTO=new VehicleReadModifyDTO() {
                        Id=1,
                        Name="B",
                        RegistrationNumber="M"
                    },
                    UserId="S"
                }
            }.AsQueryable();
        }
        
        public static IQueryable<TestVehicleReadModifyDTO> NotFoundUpdateDTOTestData()
        {
            return new List<TestVehicleReadModifyDTO>() {
                new TestVehicleReadModifyDTO
                {
                    ReadModifyDTO=new VehicleReadModifyDTO() {
                        Id=4,
                        Name="A",
                        RegistrationNumber="M"
                    },
                    UserId="S"
                },
                new TestVehicleReadModifyDTO
                {
                    ReadModifyDTO=new VehicleReadModifyDTO() {
                        Id=2,
                        Name="B",
                        RegistrationNumber="M"
                    },
                    UserId="Q"
                }
            }.AsQueryable();
        }

        public static IQueryable<TestVehicleDeleteDTO> ValidDeleteTestData()
        {
            return new List<TestVehicleDeleteDTO>() {
                new TestVehicleDeleteDTO
                {
                    ID=1,
                    UserId="S"
                },
                new TestVehicleDeleteDTO
                {
                    ID=2,
                    UserId="S"
                }
            }.AsQueryable();
        }

        public static IQueryable<TestVehicleDeleteDTO> NotFoundDeleteTestData()
        {
            return new List<TestVehicleDeleteDTO>() {
                new TestVehicleDeleteDTO
                {
                    ID=4,
                    UserId="S"
                },
                new TestVehicleDeleteDTO
                {
                    ID=1,
                    UserId="R"
                }
            }.AsQueryable();
        }
        #endregion

        private VehicleService getService()
        {
            return new VehicleService(_mockRepo);
        }

        [SetUp]
        public void Init()
        {
            AutoMapperServiceConfiguration.InitializeAutomapper();

            var mockdbSet = EFHelperClass.GetMockDbSet<Vehicle>(GetMockData());
            //mockdbSet.GetEnumerator().Returns(data.GetEnumerator());

            var context = Substitute.For<CarpoolModel>();
            context.Set<Vehicle>().Returns(mockdbSet);

            _mockRepo = new BaseRepository<Vehicle>(context);
        }
        
        #region GetAllAsync
        [Test]
        public async Task ValidGetAllAsync()
        {
            var mockService = getService();
            var test = await mockService.GetAllActiveAsync("S");
            Assert.That(test.IsValid, Is.EqualTo(true));
            Assert.That(test.Result.Count(), Is.EqualTo(GetMockData().Count(v => v.IsActive && v.OwnerName == "S")));
        }

        [Test]
        public async Task EmptyGetAllAsync()
        {   
            var mockService = getService();

            var test = await mockService.GetAllActiveAsync("R");
            Assert.That(test.IsValid, Is.EqualTo(false));
            Assert.That(test.IsFound, Is.EqualTo(false));
            Assert.That(test.Result, Is.Null);
        }
        #endregion

        #region AddAsync
        [Test, TestCaseSource("ValidAddDTOTestData")]
        public async Task ValidAddAsyncTest(TestVehicleAddDTO t)
        {
            var mockService = getService();
            var test = await mockService.AddAsync(t.AddDTO,t.UserId);
            Assert.That(test.IsValid, Is.EqualTo(true));
        }

        [Test, TestCaseSource("InValidAddDTOTestData")]
        public async Task InValidAddAsyncTest(TestVehicleAddDTO t)
        {
            var mockService = getService();
            var test = await mockService.AddAsync(t.AddDTO, t.UserId);
            Assert.That(test.IsValid, Is.EqualTo(false));
        }

        [Test, TestCaseSource("DuplicateAddDTOTestData")]
        public async Task DuplicateAddAsyncTest(TestVehicleAddDTO t)
        {
            var mockService = getService();
            var test = await mockService.AddAsync(t.AddDTO,t.UserId);
            Assert.That(test.IsDuplicate, Is.EqualTo(true));
            Assert.That(test.IsValid, Is.EqualTo(false));
        }
        #endregion

        #region UpdateAsync
        [Test, TestCaseSource("ValidUpdateDTOTestData")]
        public async Task ValidUpdateAsyncTest(TestVehicleReadModifyDTO t)
        {
            var mockService = getService();
            var test = await mockService.UpdateAsync(t.ReadModifyDTO, t.UserId);
            Assert.That(test.IsValid, Is.EqualTo(true));
        }

        [Test, TestCaseSource("InValidUpdateDTOTestData")]
        public async Task InValidUpdateAsyncTest(TestVehicleReadModifyDTO t)
        {
            var mockService = getService();
            var test = await mockService.UpdateAsync(t.ReadModifyDTO, t.UserId);
            Assert.That(test.IsValid, Is.EqualTo(false));
        }

        [Test, TestCaseSource("DuplicateUpdateDTOTestData")]
        public async Task DuplicateUpdateAsyncTest(TestVehicleReadModifyDTO t)
        {
            var mockService = getService();
            var test = await mockService.UpdateAsync(t.ReadModifyDTO, t.UserId);
            Assert.That(test.IsDuplicate, Is.EqualTo(true));
            Assert.That(test.IsValid, Is.EqualTo(false));
        }

        [Test, TestCaseSource("NotFoundUpdateDTOTestData")]
        public async Task NotFoundUpdateAsyncTest(TestVehicleReadModifyDTO t)
        {
            var mockService = getService();
            var test = await mockService.UpdateAsync(t.ReadModifyDTO, t.UserId);
            Assert.That(test.IsFound, Is.EqualTo(false));
            Assert.That(test.IsValid, Is.EqualTo(false));
        }
        #endregion

        #region DeleteAsync
        [Test, TestCaseSource("ValidDeleteTestData")]
        public async Task ValidDeleteAsyncTest(TestVehicleDeleteDTO t)
        {
            var mockService = getService();
            var test = await mockService.DeleteAsync(t.ID, t.UserId);            
            Assert.That(test.IsValid, Is.EqualTo(true));
        }

        [Test, TestCaseSource("NotFoundDeleteTestData")]
        public async Task NotFoundDeleteAsync(TestVehicleDeleteDTO t)
        {
            var mockService = getService();
            var test = await mockService.DeleteAsync(t.ID, t.UserId);
            Assert.That(test.IsFound, Is.EqualTo(false));
            Assert.That(test.IsValid, Is.EqualTo(false));
        }
        #endregion
        
        [TearDown]
        public void End()
        {
            _mockRepo.Dispose();
        }

        #region TestClasses
        public class TestVehicleAddDTO
        {
            public VehicleAddDTO AddDTO{ get; set; }
            public string UserId { get; set; }
        }

        public class TestVehicleReadModifyDTO
        {
            public VehicleReadModifyDTO ReadModifyDTO { get; set; }
            public string UserId { get; set; }
        }

        public class TestVehicleDeleteDTO
        {
            public int ID { get; set; }
            public string UserId { get; set; }
        }
        #endregion
    }
}
