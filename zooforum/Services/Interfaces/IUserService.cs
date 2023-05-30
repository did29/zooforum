using zooforum.Services.ViewModels;

namespace zooforum.Services.Interfaces
{
    public interface IUserService
    {
        Task DeleteUser(string id);
        Task CreateAsync(UserViewModel model);
       UserViewModel UpdateById(string id);
        Task UpdateAsync(UserViewModel model);
    }
}
