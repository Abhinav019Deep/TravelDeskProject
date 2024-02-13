using Microsoft.AspNetCore.Mvc;
using TravelDeskProject.IRepo;
using TravelDeskProject.Models;

namespace TravelDeskProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelRequestController : Controller
    {
        public ITravelRequestRepo _travelRequestRepo;
        public TravelRequestController(ITravelRequestRepo travelRequestRepo)
        {
            _travelRequestRepo = travelRequestRepo;
        }
        [HttpPost]
        [Route("AddRequest")]
        public IActionResult AddRequest(TravelRequest travelRequest)
        {
            if(travelRequest != null)
            {
                _travelRequestRepo.AddRequest(travelRequest);
                return Ok("Added successfully !");
            }
            else
            {
                return BadRequest();
            }

        }


    }
}
