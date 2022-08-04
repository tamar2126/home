using BL;
using COMMON;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApi.Controllers
{
    [Route("api/city")]
    [ApiController]
    public class CityController : ControllerBase
    {
    
        [Route("getAllCity")]
        public IList<ComCity> Get()
        {
            return BL.City.GetAllCities();
        }
        
      
    }
}
