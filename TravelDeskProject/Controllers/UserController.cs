using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using TravelDeskProject.IRepo;
using TravelDeskProject.Models;
using TravelDeskProject.Repo;
using TravelDeskProject.ViewModel;

namespace TravelDeskProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        private TravelDbContext _context;
        IUserRepo _userRepo;

        public UserController(IUserRepo userRepo,IMemoryCache memoryCache, TravelDbContext context)
        {
            _userRepo = userRepo;
            _memoryCache = memoryCache;
            _context = context;

        }
       
        [HttpGet]
        [Route("GetUser/{id}")]
        public IActionResult GetUser(int id)
        {
            User user= _userRepo.GetUser(id);
            return Ok(user);
        

        }
        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(User user)
        {

            string result = _userRepo.Add(user);
            return Ok(result);
        }
        [HttpGet]
        [Route("AllUsers")]
        public async Task<IActionResult> AllUsers() 
        {
            var cacheKey = "UserList";
            //checks if cache entries exists
            if (!_memoryCache.TryGetValue(cacheKey, out List<User> UserList))
            {
                //calling the server

                UserList = await _context.Users.Where(x=>x.IsActive==true).ToListAsync();
                //setting up cache options
                var cacheExpiryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(50),
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = TimeSpan.FromSeconds(20)
                };
                //setting cache entries
                _memoryCache.Set(cacheKey, UserList, cacheExpiryOptions);
            }
            return Ok(UserList);
        }
        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userRepo.DeleteUser(id);
            return Ok("User deleted Successfully!!!");
        }
        [HttpPatch]
        [Route("EditUser/{id}")]
        public IActionResult EditUser(int id, User user)
        {
            _userRepo.EditUser(id,user);
            return Ok("User edited successfully!!!");
        }
        [HttpGet]
        [Route("GetDepartmentNames")]
        public IActionResult GetDepartmentNames()
        {
            List<Department> list= _userRepo.GetDepartmentNames();
            return Ok(list);
        }
        [HttpGet]
        [Route("GetAllManagers")]
        public IActionResult GetAllManagers()
        {
            List<User> managers= _userRepo.GetAllManagers();
            return Ok(managers);
        }
        [HttpGet]
        [Route("AllUsersToDisplay")]
        public List<UserViewModel> AllUsersToDisplay()
        {
            List<UserViewModel> users=_userRepo.AllUsersToDisplay();
            return users;

        }
        [HttpGet]
        [Route("GetAllRoles")]
        public List<Role> GetAllRoles()
        {
            List<Role> roles= _userRepo.GetAllRoles();

            return roles;
        }
    }
}
