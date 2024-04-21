using Assignment.Data;
using Assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public AuthorsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAuthorViewModel viewModel)
        {
            var author = new Authors
            {
                Name = viewModel.Name,
            };

            await this.dbContext.Authors.AddAsync(author);

            await dbContext.SaveChangesAsync();

            return View();
        }
    }
}
