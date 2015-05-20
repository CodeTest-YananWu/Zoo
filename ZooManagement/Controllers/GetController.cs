using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ZooManagement.Controllers
{
    public class GetController : ApiController
    {
        [Route("api/get/AnimalTypes")]
        [HttpGet]
        public IEnumerable<string> AnimalTypes() 
        {
            List<string> AnimalTypes = new List<string>();
            foreach (var value in Enum.GetValues(typeof(AnimalType)))
            {
                AnimalTypes.Add(value.ToString());
            }
            return AnimalTypes;
        }

        [Route("api/get/AnimalGenders")]
        [HttpGet]
        public IEnumerable<string> AnimalGenders()
        {
            List<string> AnimalGenders = new List<string>();
            foreach (var value in Enum.GetValues(typeof(AnimalGender)))
            {
                AnimalGenders.Add(value.ToString());
            }
            return AnimalGenders;
        }
    }
}
