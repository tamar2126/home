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
    [Route("api/street")]
    [ApiController]
    public class StreetController : ControllerBase
    {
        
        [Route("getAllStreetsByCityId/{cityId}")]
        public  List<ComStreet> Get(int cityId)
        {
            return Street.GetAllStreetsByCityId(cityId);
        }
        [Route("deleteStreet/{streetId}")]
        public void Delete(int streetId)
        {
             Street.DeleteStreet(streetId);
        }
        [Route("updateStreet")]
        public ComStreet Post([FromBody]ComStreet street)
        {
          return  Street.UpdateStreet(street);
        }
        [Route("addStreet")]
        public ComStreet Put([FromBody] ComStreet street)
        {
            return Street.AddStreet(street);
        }

    }
}
