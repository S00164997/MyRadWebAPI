﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interest.Models
{
    public class NewsArticle
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Provider { get; set; }
    }
}
