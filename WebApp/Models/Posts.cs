using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Posts
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Poster { get; set; }
    }
}
