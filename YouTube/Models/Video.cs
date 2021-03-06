using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouTube.Models
{
    public class Video
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class SearchVideoId
    {
        public string Kind { get; set; }
        public string VideoId { get; set; }
    }

}

