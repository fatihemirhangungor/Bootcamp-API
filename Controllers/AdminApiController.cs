using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Odev2.Models;

namespace Odev2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminApiController : ControllerBase
    {
        //Create bootcamp, takes a BootCamp object as parameter and adds it to the _bootcamps list in BootCamp.cs model
        [HttpPost("/bootcamp/create")]
        public IEnumerable<BootCamp> Create(BootCamp newBootCamp)
        {
            //Add bootcamp the to list
            BootCamp._bootCamps.Add(new BootCamp(newBootCamp.Id, newBootCamp.Name, newBootCamp.Participants));

            //return it after to see details
            return BootCamp._bootCamps.Where(x => x.Id == newBootCamp.Id);
        }

        //Delete method to delete a bootcamp by it's id
        [HttpDelete("/bootcamp")]
        public async Task<ActionResult<BootCamp>> Delete(int bootCampId)
        {
            //Get bootcamp by id from the list
            var bootcamp = BootCamp._bootCamps.Where(x => x.Id == bootCampId).FirstOrDefault();

            //Check if it is null or not
            if (bootcamp != null)
            {
                //Remove bootcamp from list
                BootCamp._bootCamps.Remove(bootcamp);
            }

            //return the deleted bootcamp
            return bootcamp;
        }

        //Confirm user to accept his/her application
        //Takes two parameters as bootCampId and userId
        [HttpPut("/user/confirm")]
        public IEnumerable<BootCamp> Confirm_User(int bootCampId, int userId)
        {
            //Get the bootcamp's participants list to make changes
            var participants = BootCamp._bootCamps.Where(x => x.Id == bootCampId).First().Participants;

            //Get the user from participants list
            var user = participants.Where(user => user.Id == userId).FirstOrDefault();

            //If user is not confirmed, confirm it
            if (user.Confirmed == false)
            {
                //Make true
                user.Confirmed = true;
            }

            //Return the bootcamp details
            return BootCamp._bootCamps.Where(x => x.Id == bootCampId);
        }

        //Delete user
        //Takes two parameters as bootCampId and userId
        [HttpDelete("/user/delete")]
        public IEnumerable<BootCamp> Delete_User(int bootCampId, int userId)
        {
            //Get participants list of chosen bootcamp by id
            var participants = BootCamp._bootCamps.Where(x => x.Id == bootCampId).First().Participants;

            //Remove the user from list
            participants.Remove(participants.Where(user => user.Id == userId).First());

            //Return the bootcamp for details
            return BootCamp._bootCamps.Where(x => x.Id == bootCampId);
        }
    }
}
