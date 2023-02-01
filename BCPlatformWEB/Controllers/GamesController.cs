using BCPlatformWEB.Data;
using BCPlatformWEB.Models;
using BCPlatformWEB.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BCPlatformWEB.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext dBContext;
        private readonly IWebHostEnvironment hostingEnvironment;

        public GamesController(ApplicationDbContext DBContext, IWebHostEnvironment hostingEnvironment)
        {
            dBContext = DBContext;
            this.hostingEnvironment = hostingEnvironment;
        }
        public async Task<IActionResult>Index()
        {
            var games = await dBContext.Games.ToListAsync();
            return View(games);
        }

        [HttpGet]
        public IActionResult Add()
        {            
            return View(new AddGameViewModel() 
            { 
                Teams=dBContext.Clubs.ToList()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddGameViewModel addGameRequest)
        {
            
            string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, @"Images\\Scoresheets");
            string uniqueFileName = Guid.NewGuid().ToString()+"."+addGameRequest.Scoresheet.FileName.Split('.')[1];
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            addGameRequest.Scoresheet.CopyTo(new FileStream(filePath, FileMode.Create));

            var game = new Game()
            {
                Id = new Guid(),
                HomeTeam = addGameRequest.HomeTeam,
                AwayTeam = addGameRequest.AwayTeam,
                Location = addGameRequest.Location,
                _DateTime=addGameRequest._DateTime,
                Info = addGameRequest.Info,
                ScoresheetName = uniqueFileName
            };

            await dBContext.Games.AddAsync(game);
            await dBContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult>View(Guid id)
        {
            var game = await dBContext.Games.FirstOrDefaultAsync(x=> x.Id == id);

            if(game !=null)
            {
                var viewModel = new UpdateGameViewModel() 
                { 
                    Id= game.Id,
                    HomeTeam= game.HomeTeam,
                    AwayTeam= game.AwayTeam,
                    Location = game.Location,
                    _DateTime=game._DateTime, 
                    Info = game.Info,
                    ScoresheetName = game.ScoresheetName,
                    Teams=dBContext.Clubs.ToList()
                };
                return await Task.Run(()=> View("View", viewModel));
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateGameViewModel model)
        {
            var game = await dBContext.Games.FindAsync(model.Id);

            if (game != null)
            {
                game.HomeTeam = model.HomeTeam;
                game.AwayTeam = model.AwayTeam;
                game.Location = model.Location;
                game.Info = model.Info;
                game._DateTime= model._DateTime;
                await dBContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateClubViewModel model)
        {
            var game = await dBContext.Games.FindAsync(model.Id);
            if(game != null)
            {
                dBContext.Games.Remove(game); 
                await dBContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        #region App Methods

        [HttpGet]
        public async Task<List<Game>> AppGetGames()
        {
            return await dBContext.Games.ToListAsync();
        }

        #endregion
    }
}
