using Microsoft.EntityFrameworkCore;
using Milestone3Project.Models;

var builder = WebApplication.CreateBuilder(args);

// Configure Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=Milestone3.db"));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Ensure the database is created
    context.Database.EnsureCreated();

    // Seed Projects if they don't exist
    if (!context.Projects.Any())
    {
        context.Projects.AddRange(
            new Project 
            { 
                ProjectName = "Website Redesign", 
                Description = "Update company website",
                ProjectStatus = "InProgress",
                ProjectStartDate = DateTime.Now,
                ProjectDueDate = DateTime.Now.AddMonths(3),
                UserId = 1,  // Assign a valid user ID
                User = context.Users.FirstOrDefault(u => u.UserId == 1) ?? throw new Exception("User not found")
            },
            new Project 
            { 
                ProjectName = "Mobile App Development", 
                Description = "Create new mobile app",
                ProjectStatus = "NotStarted",
                ProjectStartDate = DateTime.Now,
                ProjectDueDate = DateTime.Now.AddMonths(6),
                UserId = 1,  // Assign a valid user ID
                User = context.Users.FirstOrDefault(u => u.UserId == 1) ?? throw new Exception("User not found")
            }
        );
        context.SaveChanges();
    }


    // Seed ProjectTasks if they don't exist
    if (!context.ProjectTasks.Any())
    {
        var project1 = context.Projects.First();
        var project2 = context.Projects.Skip(1).First();

        context.ProjectTasks.AddRange(
            new ProjectTask 
            { 
                ProjectID = project1.ProjectID, 
                TaskName = "Design UI", 
                TaskStatus = "Completed",
                Project = project1  // Assign the actual project object
            },
            new ProjectTask 
            { 
                ProjectID = project1.ProjectID, 
                TaskName = "Develop Backend", 
                TaskStatus = "Pending",
                Project = project1
            },
            new ProjectTask 
            { 
                ProjectID = project2.ProjectID, 
                TaskName = "API Integration", 
                TaskStatus = "Pending",
                Project = project2
            }
        );
        context.SaveChanges();
    }

}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();






// var builder = WebApplication.CreateBuilder(args);
//
// // Add services to the container.
// builder.Services.AddControllersWithViews();
//
// var app = builder.Build();
//
// // Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/Home/Error");
//     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//     app.UseHsts();
// }
//
// app.UseHttpsRedirection();
// app.UseStaticFiles();
//
// app.UseRouting();
//
// app.UseAuthorization();
//
// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");
//
// app.Run();
