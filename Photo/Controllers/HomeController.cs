using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PhotoApp.ViewModel;

namespace PhotoApp.Models
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            //var webClient = new System.Net.WebClient();
            //var json = webClient.DownloadString(@"http://jsonplaceholder.typicode.com/photos");
            //var photos = JsonConvert.DeserializeObject<Photos>(json);

            return View();

        }


        public ActionResult GetPhotoData()
        {
            PhotoCollection _photos;
            AlbumCollection _albums;

            var webClient = new System.Net.WebClient();
            var photosJson = webClient.DownloadString(@"http://jsonplaceholder.typicode.com/photos");
            _photos = JsonConvert.DeserializeObject<PhotoCollection>(photosJson);

            var albumJson = webClient.DownloadString(@"http://jsonplaceholder.typicode.com/albums");
            _albums = JsonConvert.DeserializeObject<AlbumCollection>(albumJson);

            var photoViewModleList = (from photos in _photos
                                      join album in _albums
                on photos.Albumid equals album.Id
                                      select new PhotosViewModel
                                      {
                                          Id = photos.Id,
                                          PhotoTitle = photos.Title,
                                          AlbumName = album.Title,
                                          ThumbnailUrl = photos.ThumbnailUrl,
                                          Url = photos.Url
                                      }).ToList();

            return Json(new { data = photoViewModleList });
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
