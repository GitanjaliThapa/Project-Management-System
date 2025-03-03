using System.ComponentModel.DataAnnotations;
using Milestone3Project.Models;

namespace Milestone3Project.Models
{
    public class Subtask
    {
        [Key]
        public int SubtaskID { get; set; }

        public required string SubtaskName { get; set; } // Required property

        public string? SubtaskDescription { get; set; } // Optional property
        public required DateTime SubtaskDate { get; set; } // Required property
        public required string SubtaskStatus { get; set; } // Required property

        // Foreign Key
        public required int TaskID { get; set; } // Required property
        public required ProjectTask ProjectTask { get; set; } // Required property
    }
}