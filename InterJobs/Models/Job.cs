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

        public virtual User Employer { get; set; } = null!;
    }
}
