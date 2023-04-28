using System;
using System.Threading.Tasks;
using Csla;
using Microsoft.AspNetCore.Mvc;

namespace RFit.AppServerCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataPortalTextController : Csla.Server.Hosts.HttpPortalController
    {
        public DataPortalTextController(ApplicationContext applicationContext)
          : base(applicationContext) 
        {
            UseTextSerialization = true;
        }

        [HttpGet]
        public string Get()
        {
            return "DataPortalTextController running...";
        }
    }
}