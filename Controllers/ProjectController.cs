using Microsoft.AspNetCore.Mvc;
using Milestone3Project.Models;
using System;
using System.Linq;

namespace Milestone3Project.Controllers
{
    public class ProjectController : Controller
    {
        private readonly AppDbContext _context;

        // Constructor to initialize AppDbContext
        public ProjectController(AppDbContext context)
        {
            _context = context;
        }

        // Action to display the milestones for a specific project
        public IActionResult ProjectMilestones(int projectId)
        {
            // Query the Milestones table to get milestones for the given project ID
            var projectMilestones = _context.Milestones
                .Where(m => m.ProjectID == projectId)
                .ToList();

            // Return the project milestones to the view
            return View(projectMilestones);
        }

        // Action to display the list of all projects
        public IActionResult ProjectList()
        {
            // Query the Projects table to get all projects
            var projects = _context.Projects.ToList();

            // Return the list of projects to the view
            return View(projects);
        }

        [HttpPost]
        public IActionResult CreateProject()
        {
            // Create a new Project object with all required properties
            var newProject = new Project
            {
                ProjectName = "New Project",
                ProjectStartDate = DateTime.Now,
                ProjectDueDate = DateTime.Now.AddMonths(1),
                ProjectStatus = "InProgress",  // Ensure a value is assigned here
                Description = "Description of the project",
                UserId = 1,  // Assign a valid UserId
                User = _context.Users.FirstOrDefault(u => u.UserId == 1)  // You need to fetch the user as well (or pass in an actual User object)
            };

            // Add the new project to the context
            _context.Projects.Add(newProject);

            // Save changes to the database (EF Core will generate ProjectID automatically)
            _context.SaveChanges();

            // Redirect to ProjectList after successful creation
            return RedirectToAction("ProjectList");
        }

    }
}
