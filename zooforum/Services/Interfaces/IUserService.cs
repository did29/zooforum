using zooforum.Services.ViewModels;

namespace zooforum.Services.Interfaces
{
    public interface IUserService
    {
        Task DeleteUser(string id);
        Task CreateUser(UserViewModel model);
        UserViewModel UpdateById(string id);
        Task UpdateUser(UserViewModel model);
        List<UserViewModel> GetAll();
        Task SaveChangesAsync();
        UserViewModel GetDetailsById(string id);
        UserViewModel Find(string id);
        Task UpdateAsync(UserViewModel model);
    }
}
