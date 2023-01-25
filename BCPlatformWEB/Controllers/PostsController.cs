using BCPlatformWEB.Data;
using BCPlatformWEB.Models;
using BCPlatformWEB.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;

namespace BCPlatformWEB.Controllers
{
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext dBContext;
        private readonly IWebHostEnvironment hostingEnvironment;

        public PostsController(ApplicationDbContext dBContext, IWebHostEnvironment hostingEnvironment)
        {
            this.dBContext = dBContext;
            this.hostingEnvironment = hostingEnvironment;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View(new AddPostViewModel()
            {
                RecentGames = dBContext.Games.ToList()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPostViewModel addPostRequest)
        {
            string imageNames = string.Empty;

            string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, @"Images\\Posts");
            foreach (var image in addPostRequest.Images)
            {
                string uniqueFileName = Guid.NewGuid().ToString() + "." + image.FileName.Split('.')[1];
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                image.CopyTo(new FileStream(filePath, FileMode.Create));
                imageNames += uniqueFileName;
            }

            var post = new Post()
            {
                Id = new Guid(),
                Title = addPostRequest.Title,
                Description = addPostRequest.Description,
                Content = addPostRequest.Content,
                Creator = new Guid(dBContext.Users.Where(x => x.UserName == HttpContext.User.Identity.Name).ToList()[0].Id),
                Game= addPostRequest.Game,
                UploadTime=DateTime.Now,
                ImageNames= imageNames,
            };

            await dBContext.Posts.AddAsync(post);
            await dBContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
