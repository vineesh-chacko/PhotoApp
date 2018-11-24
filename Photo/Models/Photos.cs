using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApp.Models
{
    public class PhotoCollection : List<Photo>
    {
        public IEnumerable<Photo> Photos { get; set; }
    }

    public class Photo
    {
        public int Albumid { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }

    }
   
}
