using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BCrypt.Net;

namespace Milestone3Project.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; } // Changed from Guid to int

        public required string Username { get; set; }  // Required property
        public required string Email { get; set; }     // Required property
        public required string PasswordHash { get; set; } // Required property

        // Navigation property for related Projects
        public List<Project> Projects { get; set; } = new List<Project>();

        // Parameterless constructor for EF Core
        public User() { }

        // Constructor with validation and hashing
        public User(string username, string email, string password)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException(nameof(username));
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentNullException(nameof(email));
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentNullException(nameof(password));

            Username = username;
            Email = email;
            PasswordHash = HashPassword(password);
        }

        // Public method for password hashing (can be reused)
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Method to verify entered password
        public bool VerifyPassword(string enteredPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, PasswordHash);
        }

        // Method to update password securely
        public void UpdatePassword(string newPassword)
        {
            if (string.IsNullOrWhiteSpace(newPassword)) throw new ArgumentNullException(nameof(newPassword));
            PasswordHash = HashPassword(newPassword);
        }
    }
}
