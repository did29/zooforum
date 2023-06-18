using Microsoft.AspNetCore.Identity;

namespace zooforum.Data.DataModel
{
    public class User: IdentityUser
    {
        public DateTime RegistrationDate { get; set; }
    }
}
