using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Milestone3Project.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Ensure auto-generation
        public int ProjectID { get; set; } // No 'required' here

        [Required]
        public required string ProjectName { get; set; }

        [Required]
        public required string ProjectStatus { get; set; } = "InProgress";

        public required DateTime ProjectStartDate { get; set; }
        public required DateTime ProjectDueDate { get; set; }

        public string Description { get; set; }

        [ForeignKey("User")]
        public required int UserId { get; set; }

        public required User User { get; set; } // Required navigation property

        public List<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
        public List<Milestone> Milestones { get; set; } = new List<Milestone>();
    }

}