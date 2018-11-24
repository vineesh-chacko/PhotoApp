using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApp.Models
{
    public class AlbumCollection : List<Album>
    {
        public IEnumerable<Album> Albums { get; set; }
    }

    public class Album
    {
        public int Userid { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }

    }


}
