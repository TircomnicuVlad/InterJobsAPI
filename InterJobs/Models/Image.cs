﻿using System;
using System.Collections.Generic;

namespace InterJobsAPI.Models
{
    public partial class Image
    {

        public Guid Id { get; set; }
        public IFormFile ImageContent { get; set; } = null!;

        public virtual User User { get; set; }
    }
}
