using TravelDeskProject.Models;
using TravelDeskProject.ViewModel;

namespace TravelDeskProject.IRepo
{
    public interface IUserRepo
    {
        string Add(User user);
        User GetUser(int id);
        List<User> AllUsers();
        List<UserViewModel> AllUsersToDisplay();
        void DeleteUser(int id);
        void EditUser(int id, User user);
        public List<Department> GetDepartmentNames();
        public List<User> GetAllManagers();

        public List<Role> GetAllRoles();
    }
}
