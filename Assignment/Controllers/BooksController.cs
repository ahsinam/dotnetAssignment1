using System.Diagnostics;
using Assignment.Data;
using Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public BooksController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var authors = this.dbContext.Authors.ToList();
            ViewBag.Authors = authors;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel viewModel)
        {
            var author = this.dbContext.Authors.FirstOrDefault(a => a.Id == viewModel.AuthorId);

            var book = new Books
            {
                Title = viewModel.Title,
                Publisher = viewModel.Publisher,
                PublishedDate = viewModel.PublishedDate,
                ISBN = viewModel.ISBN,
                Price = viewModel.Price,
                Authors = author,
                Genre = viewModel.Genre
            };

            await this.dbContext.Books.AddAsync(book);

            await dbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Books");
        }

        [HttpGet]
        public IActionResult Index()
        {
            var books = this.dbContext.Books.Include(book => book.Authors).ToList();
            ViewBag.Books = books;


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var authors = this.dbContext.Authors.ToList();
            ViewBag.Authors = authors;

            var book = await this.dbContext.Books.FindAsync(id);
            if (book is not null) {
                ViewBag.Book = book;
                ViewBag.PublishedDate = new DateOnly(book.PublishedDate.GetValueOrDefault().Year, book.PublishedDate.GetValueOrDefault().Month, book.PublishedDate.GetValueOrDefault().Day).ToString("yyyy-MM-dd");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditBookViewModel viewModel)
        {
            var author = this.dbContext.Authors.FirstOrDefault(a => a.Id == viewModel.AuthorId);

            var book = await this.dbContext.Books.FindAsync(viewModel.Id);

            if ((book is not null) && (author is not null)) {
                book.Title = viewModel.Title;
                book.Publisher = viewModel.Publisher;
                book.PublishedDate = viewModel.PublishedDate;
                book.ISBN = viewModel.ISBN;
                book.Price = viewModel.Price;
                book.Authors = author;
                book.Genre = viewModel.Genre;


            await this.dbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Books");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var book = await this.dbContext.Books.FindAsync(id);

            if (book is not null)
            {
                this.dbContext.Books.Remove(book);
                await this.dbContext.SaveChangesAsync();

            }


            return RedirectToAction("Index", "Books");
        }

    }
}
