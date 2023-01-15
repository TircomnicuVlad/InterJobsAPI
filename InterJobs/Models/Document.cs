using Microsoft.AspNetCore.Builder;

namespace InterJobsAPI.Models
{
    public partial class Document
    {

        public Guid Id { get; set; }
        public IFormFile DocumentContent { get; set; } = null!;

        public virtual JobApplication JobApplication { get; set; }
    }
}
