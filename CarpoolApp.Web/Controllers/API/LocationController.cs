using CarpoolApp.DTO;
using CarpoolApp.Model.Entities;
using CarpoolApp.Service;
using CarpoolApp.Service.BaseServices;
using CarpoolApp.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CarpoolApp.Web.Controllers.API
{
    public class LocationController : BaseController
    {
        IBaseService<LocationAddDTO,LocationReadModifyDTO, Location> service;
        ILocationService locService;

        public LocationController(IBaseService<LocationAddDTO, LocationReadModifyDTO, Location> _service,ILocationService _locService)
        {
            service = _service;
            locService = _locService;
        }

        // GET api/<controller>
        public async Task<IHttpActionResult> Get()
        {
            return ProcessResult(await service.GetAllActiveAsync());
        }

        // GET api/<controller>/5
        public async Task<IHttpActionResult> Get(int id)
        {
            return ProcessResult(await service.GetById(id));
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        [Route("api/GetLocation")]
        [HttpGet]
        public async Task<IHttpActionResult> GetLocation(string locationName)
        {
            return ProcessResult(await locService.GetByString(locationName));
        }
    }
}