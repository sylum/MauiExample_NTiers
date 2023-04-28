using System;
using System.Threading.Tasks;
using Csla;
using Microsoft.AspNetCore.Mvc;

namespace RFit.AppServerCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataPortalController : Csla.Server.Hosts.HttpPortalController
    {
        public DataPortalController(ApplicationContext applicationContext)
          : base(applicationContext) 
        {
            
        }

        [HttpGet]
        public string Get()
        {
            return "DataPortalController running...";
        }
    }
}