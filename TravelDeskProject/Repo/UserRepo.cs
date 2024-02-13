using Microsoft.EntityFrameworkCore;
using TravelDeskProject.IRepo;
using TravelDeskProject.Models;
using TravelDeskProject.ViewModel;

namespace TravelDeskProject.Repo
{
    public class UserRepo : IUserRepo
    {
        TravelDbContext _db;
        public UserRepo(TravelDbContext db)
        {
            _db = db;
        }
        public string Add(User user)
        {
            user.IsActive = true;
            if (!_db.Users.Any(x => x.Email == user.Email))
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                return "Added Successfully";
            }
            else
            {
                return "Email already exists";
            }
        }
        public User GetUser(int id)
        {
            return _db.Users.Where(x => x.UserId == id).FirstOrDefault();
        }
        public List<User> AllUsers()
        {
            return _db.Users.Where(x => x.IsActive == true).ToList();
        }

        public void DeleteUser(int id)
        {
            User user = _db.Users.Where(x => x.UserId == id).FirstOrDefault();
            user.IsActive = false;
            _db.SaveChanges();
        }
        public void EditUser(int id, User user)
        {
            var data = _db.Users.Where(e => e.UserId == id).FirstOrDefault();
            if (data != null)
            {
                data.FirstName = user.FirstName;
                data.LastName = user.LastName;
                data.Email = user.Email;
                data.Password = user.Password;
                data.Address = user.Address;
                data.MobileNumber = user.MobileNumber;
                data.CreateBy = user.CreateBy;
                data.CreatedOn = user.CreatedOn;
                data.UpdateBy = user.UpdateBy;
                data.UpdatedOn = user.UpdatedOn;
                data.IsActive = user.IsActive;
                data.RoleId = user.RoleId;
                data.ManagerId = user.ManagerId;
                data.DepartmentId = user.DepartmentId;
                _db.Users.Update(data);
                _db.SaveChanges();
            }
        }
        public List<Department> GetDepartmentNames()
        {
            List<Department> list = _db.Departments.ToList();
            return list;
        }
        public List<User> GetAllManagers()
        {
            List<User> managers = _db.Users.Where(x => x.RoleId == 4).ToList();
            return managers;
        }
        public List<UserViewModel> AllUsersToDisplay()
        {
            var query =
            (from user in _db.Users
            join manager in _db.Users on user.ManagerId equals manager.UserId
            join role in _db.Roles on user.RoleId equals role.RoleId
            join department in _db.Departments on user.DepartmentId equals department.DepartmentId
            where user.IsActive == true
            select new UserViewModel
            {
            UserId = user.UserId,
            FirstName = user.FirstName,
            LastName = user.LastName,
            RoleName = role.RoleName,
            ManagerName = manager.FirstName + " " + manager.LastName,
            DepartmentName = department.DepartmentName
            }).ToList();
            return query;

        }
        public List<Role> GetAllRoles()
        {
            List<Role> roles = _db.Roles.Where(x => x.RoleId == 3 || x.RoleId == 4).ToList();
            return roles;
        }
        


    }
}

