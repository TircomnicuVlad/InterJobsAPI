using InterJobsAPI.Models;

namespace InterJobsAPI.Helpers
{
    public class JobApplicationViewModel
    {
        public Guid Id { get; set; }
        public Guid JobID { get; set; }
        public Guid UserID { get; set; }
        public IFormFile CVContent { get; set; }
        public int Status { get; set; }

    }
}
