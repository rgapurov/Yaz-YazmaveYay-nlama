using dersASP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace dersASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NoteContext _Context;

        public HomeController(ILogger<HomeController> logger, NoteContext context)
        {
            _logger = logger;
            _Context = context;
        }

        public IActionResult Index()
        {
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
        //login
        public IActionResult Login(string Email, string Password)
        {
            var author = _Context.Authors.FirstOrDefault(x => x.Email == Email && x.Password == Password);
            if (author == null)
            {
                return RedirectToAction(nameof(Index));
            }
            HttpContext.Session.SetInt32("id", author.Id);
            return RedirectToAction(nameof(Category));
        }
        public IActionResult Category()
        {
            List<Category> List = _Context.Categories.ToList();
            return View(List);
        }
        public IActionResult Tag()
        {
            List<Tag> List = _Context.Tags.ToList();
            return View(List);
        }

        public IActionResult Author()
        {
            List<Author> List = _Context.Authors.ToList();
            return View(List);
        }
        //Category
        public async Task<IActionResult> AddCategory(Category category)
        {
            await _Context.AddAsync(category);
            await _Context.SaveChangesAsync();
            return RedirectToAction(nameof(Category));
        }
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            _Context.Update(category);
            await _Context.SaveChangesAsync();
            return RedirectToAction(nameof(Category));
        }
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            Category category = await _Context.Categories.FindAsync(id);
            _Context.Remove(category);
            await _Context.SaveChangesAsync();
            return RedirectToAction(nameof(Category));
        }
        // Author
        public async Task<IActionResult> AddAuthor(Author author)
        {
            await _Context.AddAsync(author);
            await _Context.SaveChangesAsync();
            return RedirectToAction(nameof(Author));
        }
        public async Task<IActionResult> UpdateAuthor(Author author)
        {
            _Context.Update(author);
            await _Context.SaveChangesAsync();
            return RedirectToAction(nameof(Author));
        }
        public async Task<IActionResult> DeleteAuthor(int? id)
        {
            Author author = await _Context.Authors.FindAsync(id);
            _Context.Remove(author);
            await _Context.SaveChangesAsync();
            return RedirectToAction(nameof(Author));
        }
        //Tag
        public async Task<IActionResult> AddTag(Tag tag)
        {
            await _Context.AddAsync(tag);
            await _Context.SaveChangesAsync();
            return RedirectToAction(nameof(Tag));
        }
        public async Task<IActionResult> UpdateTag(Tag tag)
        {
            _Context.Update(tag);
            await _Context.SaveChangesAsync();
            return RedirectToAction(nameof(Tag));
        }
        public async Task<IActionResult> DeleteTag(int? id)
        {
            Tag tag = await _Context.Tags.FindAsync(id);
            _Context.Remove(tag);
            await _Context.SaveChangesAsync();
            return RedirectToAction(nameof(Tag));
        }
    }
}
