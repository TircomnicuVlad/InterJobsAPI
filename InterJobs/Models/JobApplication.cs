namespace InterJobsAPI.Models
{
    public partial class JobApplication
    {
        public Guid Id { get; set; }
        public Guid JobID { get; set; }
        public Guid UserID { get; set; }
        public Guid CVID { get; set; }
        public int Status { get; set; }

        public virtual Job Job { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual Document CV { get; set; } = null!;
    }
}
