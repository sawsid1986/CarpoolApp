using CarpoolApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CarpoolApp.Web.Helpers;
using System.Security.Claims;
using System.Net.Http;

namespace CarpoolApp.Web.Helpers
{
    public class BaseController : ApiController
    {
        protected string UserName;

        public BaseController()
        {
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null && identity.AuthenticationType == "Bearer")
            {
                UserName = identity.Claims.Single(c => c.Type == ClaimTypes.Name).Value;
            }
        }

        protected IHttpActionResult ProcessResult<T>(Query<T> result) where T : class
        {
            if (result.IsValid)
            {
                return Ok(result.Result);
            }
            else
            {
                return ProcessResult((Command)result);
            }
        }

        protected IHttpActionResult ProcessResult(Command result)
        {
            if (!result.IsFound)
                return NotFound();
            else if (result.IsDuplicate)
                return BadRequest("Duplicate Record Entered");
            else if (result.Ex != null)
                return BadRequest(result.Ex.Message);
            else if (result.ModelState != null)
                return BadRequest(result.ModelState.ToModelStateDictionary());
            else
                return Ok();
        }
    }
}