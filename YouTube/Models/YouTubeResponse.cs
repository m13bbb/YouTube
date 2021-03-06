using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouTube.Models
{
    public class YouTubeResponse
    {
        public Item[] items { get; set; }


        public class Item
        {
            public SearchVideoId id { get; set; }
            public Snippet snippet { get; set; }
        }

        public class Snippet
        {
            public string title { get; set; }
            public string description { get; set; }
        }
    }
}
