using zooforum.Services.ViewModels;

namespace zooforum.Services.Interfaces
{
    public interface IUserService
    {
        Task DeleteUser(string id);
        Task CreateUser(UserViewModel model);
       UserViewModel UpdateById(string id);
        Task UpdateUser(UserViewModel model);
    }
}
