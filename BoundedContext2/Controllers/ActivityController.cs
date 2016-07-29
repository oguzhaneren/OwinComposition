using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace BoundedContext2.Controllers
{
    [RoutePrefix("api/activities")]
    public class ActivityController
         : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllActivities()
        {
            var list = new List<object>
                       {
                           new {id = Guid.NewGuid(), text = "User created"},
                           new {id = Guid.NewGuid(), text = "Order approved"},
                           new {id = Guid.NewGuid(), text = "Payment failed"}
                       };

            return Ok(list);
        }
    }
}
