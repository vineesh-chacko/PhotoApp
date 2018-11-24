using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PhotoApp.Models;
using PhotoApp.ViewModel;

namespace Runpath.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosApiController : ControllerBase
    {
        [HttpGet]
        public IList<PhotosViewModel> Get()
        {
            PhotoCollection _photos;
            AlbumCollection _albums;

            var webClient = new System.Net.WebClient();
            var photosJson = webClient.DownloadString(@"http://jsonplaceholder.typicode.com/photos");
            _photos = JsonConvert.DeserializeObject<PhotoCollection>(photosJson);

            var albumJson = webClient.DownloadString(@"http://jsonplaceholder.typicode.com/albums");
            _albums = JsonConvert.DeserializeObject<AlbumCollection>(albumJson);

            var photoViewModleList = from photos in _photos
                                     join album in _albums
               on photos.Albumid equals album.Id
                                     select new PhotosViewModel
                                     {
                                         Id = photos.Id,
                                         PhotoTitle = photos.Title,
                                         AlbumName = album.Title,
                                         ThumbnailUrl = photos.ThumbnailUrl,
                                         Url = photos.Url
                                     };

            return photoViewModleList.ToList();
        }
    }
}
