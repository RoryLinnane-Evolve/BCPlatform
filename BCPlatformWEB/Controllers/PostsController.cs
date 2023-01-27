using BCPlatformWEB.Data;
using BCPlatformWEB.Models;
using BCPlatformWEB.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using System.IO;

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
                imageNames += (uniqueFileName+",");
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
            return Redirect("/");
        }

        [HttpGet]
        public async Task<IActionResult>Update(Guid id)
        {
            var post = await dBContext.Posts.FirstOrDefaultAsync(x=>x.Id == id);
            if(post!=null)
            {
                var viewModel = new UpdatePostViewModel()
                {
                    Id = post.Id,
                    Title = post.Title,
                    Description = post.Description,
                    Content = post.Content,
                    Creator=post.Creator, 
                    Game=post.Game,
                    UploadTime=post.UploadTime,
                    ImageNames=post.ImageNames,
                    RecentGames=dBContext.Games.ToList()
                };
                return await Task.Run(() => View("Update", viewModel));
            }
            else
            {
                return Redirect("/");
            }
        }

        [HttpPost]
        public async Task<IActionResult>Update(UpdatePostViewModel model)
        {
            var post = await dBContext.Posts.FindAsync(model.Id);

            if(post!=null)
            {
                post.Title= model.Title;
                post.Description= model.Description;
                post.Content= model.Content;
                post.Creator= new Guid(dBContext.Users.Where(x => x.UserName == HttpContext.User.Identity.Name).ToList()[0].Id);
                post.Game=model.Game;
                post.UploadTime=DateTime.Now;
                post.ImageNames=model.ImageNames;
                await dBContext.SaveChangesAsync();
                return Redirect("/");
            }
            return Redirect("/");
        }
    }
}
