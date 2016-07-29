using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace BoundedContext1.Controllers
{
    [RoutePrefix("api/todo")]
    public class TodoController
         : ApiController
    {
        [HttpGet]
        [Route()]
        public IHttpActionResult GetAllTasks()
        {
            var list = new List<object>
                       {
                           new { id = "todo/1", name = "Create shared lib" },
                new { id = "todo/2", name = "Write tests" }
                       };

            return Ok(list);
        }

        public TodoController()
        {
            
        }
    }
}
