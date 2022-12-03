using System;
using System.Collections.Generic;

namespace InterJobsAPI.Models
{
    public partial class Image
    {
        public Image()
        {
            Users = new HashSet<User>();
        }

        public Guid Id { get; set; }
        public string ImageContent { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
