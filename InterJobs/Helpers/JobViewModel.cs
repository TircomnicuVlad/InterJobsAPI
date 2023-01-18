namespace InterJobsAPI.Helpers
{
    public class JobViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public Guid EmployerId { get; set; }
        public string OpenPositionsNumber { get; set; }
        public string? Location { get; set; }
        public string? RequiredSkills { get; set; }
        public string? Type { get; set; }
    }
}
