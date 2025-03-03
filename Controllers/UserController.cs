using Microsoft.AspNetCore.Mvc;
using Milestone3Project.Models;
using System.Linq;

namespace Milestone3Project.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        // Constructor to initialize AppDbContext
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // Action to display projects associated with a specific user
        public IActionResult UserProjects(int userId)  // Change userId type to int
        {
            var userProjects = _context.Projects
                .Where(p => p.UserId == userId)  // Ensure that UserId is of type int in the Projects model
                .ToList();  // Explicitly calling ToList() here to resolve ambiguity

            return View(userProjects);
        }
    }
}