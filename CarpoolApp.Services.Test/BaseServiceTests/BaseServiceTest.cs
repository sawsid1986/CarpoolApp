using CarpoolApp.DTO;
using CarpoolApp.Model.DbContexts;
using CarpoolApp.Model.Entities;
using CarpoolApp.Model.Entities.BaseEntities;
using CarpoolApp.Repositories.BaseRepositories;
using CarpoolApp.Service;
using CarpoolApp.Service.BaseServices;
using CarpoolApp.Service.Configuration;
using CarpoolApp.Services.Test.EFHelpers;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpoolApp.Services.Test.BaseServiceTests
{
    
    public abstract class BaseServiceTest<TAddDTO,TReadModifyDTO, TEntity>
        where TAddDTO : class
        where TReadModifyDTO : class,DTO.ISoftDeletable
        where TEntity : class,Model.Entities.BaseEntities.ISoftDeletable
    {
        protected BaseRepository<TEntity> _mockRepo;

        protected abstract BaseService<TAddDTO, TReadModifyDTO, TEntity> getService();
        
        protected abstract IQueryable<TEntity> GetMockData();        

        [SetUp]
        public void Init()
        {
            AutoMapperServiceConfiguration.InitializeAutomapper();

            var mockdbSet = EFHelperClass.GetMockDbSet<TEntity>(GetMockData());
            //mockdbSet.GetEnumerator().Returns(data.GetEnumerator());

            var context = Substitute.For<CarpoolModel>();            
            context.Set<TEntity>().Returns(mockdbSet);

            _mockRepo = new BaseRepository<TEntity>(context);
        }

        #region GetAllAsyncTest
        [Test]
        public async Task ValidGetAllAsync()
        {
            var mockService = getService();
            var test=await mockService.GetAllAsync();
            Assert.That(test.IsValid, Is.EqualTo(true));                        
            Assert.That(test.Result.Count(), Is.EqualTo(GetMockData().Count()));
        }

        [Test]
        public async Task EmptyGetAllAsync()
        {
            var mockdbSet = EFHelperClass.GetMockDbSet<TEntity>(new List<TEntity>().AsQueryable());
            var context = Substitute.For<CarpoolModel>();
            context.Set<TEntity>().Returns(mockdbSet);

            _mockRepo = new BaseRepository<TEntity>(context);
            var mockService = getService();

            var test = await mockService.GetAllAsync();
            Assert.That(test.IsValid, Is.EqualTo(true));
            Assert.That(test.Result.Count(), Is.EqualTo(0));

       }
        //[Test]
        //public async Task ExceptionGetAllAsync()
        //{
        //    //_mockRepo.GetAllAsync().Returns(() => { throw new Exception(); });

        //    var mockService = getService();

        //    var test = await mockService.GetAllAsync();
        //    Assert.That(test.IsValid, Is.EqualTo(false));
        //    Assert.That(test.Result, Is.Null);

        //}
        #endregion

        #region AddAsyncTest
        [Test,TestCaseSource("ValidAddDTOTestData")]
        public async Task ValidAddAsyncTest(TAddDTO t)
        {
            var mockService = getService();
            var test = await mockService.AddAsync(t);
            Assert.That(test.IsValid, Is.EqualTo(true));            
        }

        [Test, TestCaseSource("DuplicateAddDTOTestData")]
        public async Task DuplicateAddAsyncTest(TAddDTO t)
        {
            var mockService = getService();
            var test = await mockService.AddAsync(t);
            Assert.That(test.IsDuplicate, Is.EqualTo(true));
            Assert.That(test.IsValid, Is.EqualTo(false));
        }

        #endregion

        [TearDown]
        public void End()
        {
            _mockRepo.Dispose();
        }
    }
}
