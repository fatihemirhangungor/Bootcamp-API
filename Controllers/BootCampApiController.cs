using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Odev2.Models;

namespace Odev2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootCampApiController : ControllerBase
    {
        //Get all bootcamps
        [HttpGet("/bootcamps")]
        public IEnumerable<BootCamp> Get()
        {
            //return all the bootcamps in _bootCamps list
            return BootCamp._bootCamps;
        }

        //Get bootcamp by id
        [HttpGet("/bootcamp/{id}")]
        public IEnumerable<BootCamp> GetById(int id)
        {
            //Linq expression for getting the bootcamp by id
            return BootCamp._bootCamps.Where(bootcamp => bootcamp.Id == id);
        }

        //Join bootcamp, enter id for the bootcamp you want to join
        //and enter your user informations
        //This method will add the user to the bootcamp and return that bootcamp
        [HttpPost("/join-bootcamp")]
        public IEnumerable<BootCamp> Join_BootCamp(int bootCampId, User newUser)
        {
            //When a new user sign up for a bootcamp, his/her id will be incremented by 1, according to the number of participants
            //This is for keeping the id's tight. 1,2,3,... etc
            newUser.Id = BootCamp._bootCamps.Where(bootcamp => bootcamp.Id == bootCampId).FirstOrDefault().Participants.Count + 1;

            //Get the bootcamp by id
            var bootcamp = BootCamp._bootCamps.Where(bootcamp => bootcamp.Id == bootCampId).FirstOrDefault();

            //Checking if it is null or not
            if (bootcamp != null)
            {
                //If bootcamp is not null, add the user to bootcamp's participants list
                bootcamp.Participants.Add(newUser);
            }

            //return the bootcamp that added user
            return BootCamp._bootCamps.Where(bootcamp => bootcamp.Id == bootCampId);
        }
    }
}
