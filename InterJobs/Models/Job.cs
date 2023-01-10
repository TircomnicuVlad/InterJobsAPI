using System;
using System.Collections.Generic;

namespace InterJobsAPI.Models
{
    public partial class Job
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public Guid EmployerId { get; set; }
        public int OpenPositionsNumber { get; set; }
        public string? Location { get; set; }
        public string? RequiredSkills { get; set; }
        public string? Type { get; set; }

        public virtual User Employer { get; set; } = null!;
        public virtual ICollection<JobApplication> JobApplications { get; set; } = null!;
    }
}
