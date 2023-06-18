using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using zooforum.Data;
using zooforum.Services;
using zooforum.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAnimalService,AnimalService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IAnswerService, AnswerService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//for the roles
using (var scope = app.Services.CreateScope())
{
	var roles = new[] { "Admin", "User", "Chef" };

	//foreach (var role in roles)
	//{
	//	var roleManager =
	//		scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
	//	if (!await roleManager.RoleExistsAsync(role))
	//		await roleManager.CreateAsync(new IdentityRole(role));
	//}
}

using (var scope = app.Services.CreateScope())
{
	var userManager =
		scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

	var roles = new[] { "Admin", "User", "Chef" };

	string email = "admin@admin.com";
	string password = "admin";

	if (await userManager.FindByEmailAsync(email) == null)
	{
		var user = new IdentityUser();
		user.UserName = email;
		user.Email = email;

		await userManager.CreateAsync(user, password);

		await userManager.AddToRoleAsync(user, "Admin");
	}
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
