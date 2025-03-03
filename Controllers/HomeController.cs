using Microsoft.AspNetCore.Mvc;
using Milestone3Project.Models;
using System.Linq;

namespace Milestone3Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            // Fetch data for charts
            var totalProjects = _context.Projects.Count();
            var totalTasks = _context.ProjectTasks.Count();  // Using ProjectTasks here
            var completedTasks = _context.ProjectTasks.Count(t => t.TaskStatus == "Completed");
            var pendingTasks = _context.ProjectTasks.Count(t => t.TaskStatus != "Completed");

            // Fetch project names
            var projectNames = _context.Projects.Select(p => p.ProjectName).ToList();

            // Fetch task counts for each project efficiently
            var projectTaskCounts = _context.Projects
                .Select(p => new
                {
                    p.ProjectID,
                    TaskCount = _context.ProjectTasks.Count(t => t.ProjectID == p.ProjectID)
                })
                .ToList()  // Materialize the data from the database
                .Select(x => x.TaskCount)  // Extract task counts into a list
                .ToList();

            // Prepare the data for the view
            var dashboardData = new
            {
                totalProjects,
                totalTasks,
                completedTasks,
                pendingTasks,
                projectNames,
                projectTaskCounts
            };

            // Print data to the console for debugging
            Console.WriteLine($"Total Projects: {totalProjects}, Total Tasks: {totalTasks}, Completed: {completedTasks}, Pending: {pendingTasks}");

            return View(dashboardData);
        }

    }
}



// using System.Diagnostics;
// using Microsoft.AspNetCore.Mvc;
// using Milestone3Project.Models;
//
// namespace Milestone3Project.Controllers;
//
// public class HomeController : Controller
// {
//     private readonly ILogger<HomeController> _logger;
//
//     public HomeController(ILogger<HomeController> logger)
//     {
//         _logger = logger;
//     }
//
//     public IActionResult Index()
//     {
//         return View();
//     }
//
//     public IActionResult Privacy()
//     {
//         return View();
//     }
//
//     [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//     public IActionResult Error()
//     {
//         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//     }
// }