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
    public class PostController : BaseController
    {
        IPostService service;

        public PostController(IPostService _service)
        {
            service = _service;
        }

        public async Task<IHttpActionResult> Get()
        {
            return ProcessResult(await service.GetAllActiveAsync(UserName));
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>        
        public async Task<IHttpActionResult> Post([FromBody]PostAddDTO value)
        {
            return ProcessResult(await service.AddAsync(value, UserName));
        }

        // PUT api/<controller>/5        
        public async Task<IHttpActionResult> Put([FromBody]PostReadModifyDTO value)
        {
            return ProcessResult(await service.UpdateAsync(value, UserName));
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            return ProcessResult(await service.DeleteAsync(id, UserName));
        }
    }
}
