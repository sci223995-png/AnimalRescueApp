using AnimalRescueApp.Data; 
using AnimalRescueApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimalRescueApp.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AnimalsController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index(string searchString)
        {
            var animals = _context.Animals.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                animals = animals.Where(s => s.Name.Contains(searchString) || s.Species.Contains(searchString));
            }

            return View(animals.ToList());
        }
        [Authorize]
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(Animal animal, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
                Directory.CreateDirectory(uploadsFolder); 

                var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(imageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);


                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                animal.ImageURL = "/uploads/" + uniqueFileName;
            }
            else
            {
                animal.ImageURL = "/uploads/default.png"; 
            }

            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}