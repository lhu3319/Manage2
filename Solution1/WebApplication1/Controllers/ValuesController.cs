using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Modules;

namespace WebApplication1.Controllers
{
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [Route("api/Insert")]
        [HttpPost]
        public ActionResult<ArrayList> Post([FromForm]Test test)
        {
            return Query.Getinsert(test);
        }

        [Route("api/Select")]
        [HttpGet]
        public ActionResult<ArrayList> Select([FromForm]Test test)
        {
            return Query.Getselect();
        }

        [Route("api/Update")]
        [HttpPost]
        public ActionResult<ArrayList> Update([FromForm]Test test)
        {
            return Query.Getupdate(test);
        }

        [Route("api/Delete")]
        [HttpPost]
        public ActionResult<ArrayList> Delete([FromForm]Test test)
        {
            return Query.Getdelete(test);
        }
    }
}
