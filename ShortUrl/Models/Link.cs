using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortUrl.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string LongURL { get; set; }
        public string ShortUrl { get; set; }
        public string CreatedData { get; set; }
        public int Count { get; set; }
    }
}
