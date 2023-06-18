using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using zooforum.Data;
using zooforum.Data.DataModel;
using zooforum.Services.Interfaces;
using zooforum.Services.ViewModels;

namespace zooforum.Services
{
    public class UserService : IUserService
    {
        
        private readonly ApplicationDbContext context;
        public UserService(ApplicationDbContext post)
        {
            context = post;
        }

        public List<UserViewModel> GetAll()
        {
            return context.User.Select(user => new UserViewModel()
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                RegistrationDate = user.RegistrationDate

            }).ToList();
        }
        public async Task CreateUser(UserViewModel model)
        {
            User user = new User();

            user.Id = Guid.NewGuid().ToString();
            user.UserName = model.Username;
            user.Email = model.Email;
            user.RegistrationDate = model.RegistrationDate;

            await context.User.AddAsync(user);
            await context.SaveChangesAsync();
        }
		public async Task AddUser(User user)
        {
            await context.User.AddAsync(user);
            await context.SaveChangesAsync();
        }
        public async Task DeleteUser(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("Eror!");
            }
            if (id != null)
            {
                var animalDb = context.User.FirstOrDefault(x => x.Id == id);
                context.User.Remove(animalDb);
                await context.SaveChangesAsync();
            }
        }
        public async Task UpdateAsync(UserViewModel model)
        {
            var user = await context.User.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (user != null)
            {
                user.UserName = model.Username;
                user.Email = model.Email;
                user.RegistrationDate = model.RegistrationDate;

                await context.SaveChangesAsync();
            }
        }
        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
        public UserViewModel GetUserById(string id)
        {
            UserViewModel user = context.User
                .Select(user => new UserViewModel
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Email = user.Email,
                    RegistrationDate = user.RegistrationDate,
                }).SingleOrDefault(user => user.Id == id);

            return user;
        }
        public UserViewModel UpdateById(string id)
        {
            UserViewModel user = context.User
                .Select(user => new UserViewModel
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Email = user.Email,
                    RegistrationDate = user.RegistrationDate,
                }).SingleOrDefault(user => user.Id == id);

            return user;
        }
        public async Task UpdateUser(UserViewModel model)
        {
            User user = context.User.Find(model.Id);

            bool isUserNull = user == null;
            if (isUserNull)
            {
                return;
            }

            context.User.Update(user);
            await context.SaveChangesAsync();
        }
    }
}
