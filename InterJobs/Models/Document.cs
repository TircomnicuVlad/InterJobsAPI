using Microsoft.AspNetCore.Builder;

namespace InterJobsAPI.Models
{
    public partial class Document
    {

        public Guid Id { get; set; }
        public byte[] DocumentContent { get; set; } = null!;

        public virtual JobApplication? JobApplication { get; set; }
    }
}
