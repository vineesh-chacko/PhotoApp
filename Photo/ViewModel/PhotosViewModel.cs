using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoApp.ViewModel
{


    public class PhotosList : List<PhotosViewModel>
    {
        IEnumerable<PhotosViewModel> DisplayPhotos { get; set; }
    }


    public class PhotosViewModel
    {

        public int Id { get; set; }
        public string AlbumName { get; set; }
        public string PhotoTitle { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
