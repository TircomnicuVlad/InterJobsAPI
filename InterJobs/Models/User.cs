using System;
using System.Collections.Generic;

namespace InterJobsAPI.Models
{
    public partial class User
    {
        public User()
        {
            Jobs = new HashSet<Job>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Guid UserTypeId { get; set; }
        public string Email { get; set; } = null!;
        public Guid? ProfilePictureId { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual Image? ProfilePicture { get; set; }
        public virtual UserType? UserType { get; set; } = null!;
        public virtual ICollection<Job> Jobs { get; set; }
        public virtual ICollection<JobApplication>? JobApplications { get; set; }
    }
}
