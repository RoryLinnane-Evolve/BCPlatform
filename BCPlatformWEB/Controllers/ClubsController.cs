using BCPlatformWEB.Data;
using BCPlatformWEB.Models;
using BCPlatformLib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BCPlatformWEB.Controllers
{
    public class ClubsController : Controller
    {
        private readonly ApplicationDbContext dBContext;

        public ClubsController(ApplicationDbContext DBContext)
        {
            dBContext = DBContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clubs = await dBContext.Clubs.ToListAsync();
            return View(clubs);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddClubViewModel addClubRequest)
        {
            var club = new Club()
            {
                Id= new Guid(),
                Name = addClubRequest.Name,
                Location= addClubRequest.Location
            };

            await dBContext.Clubs.AddAsync(club);
            await dBContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult>View(Guid id)
        {
            var club = await dBContext.Clubs.FirstOrDefaultAsync(x=> x.Id==id);

            if (club != null)
            {
                var viewModel = new UpdateClubViewModel()
                {
                    Id = club.Id,
                    Name = club.Name,
                    Location = club.Location
                };
                return await Task.Run(() => View("View", viewModel));
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult>View(UpdateClubViewModel model)
        {
            var club = await dBContext.Clubs.FindAsync(model.Id);

            if (club != null)
            {
                club.Name= model.Name;
                club.Location= model.Location;
                await dBContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateClubViewModel model)
        {
            var club = await dBContext.Clubs.FindAsync(model.Id);
            if (club != null)
            {
                dBContext.Clubs.Remove(club);
                await dBContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
