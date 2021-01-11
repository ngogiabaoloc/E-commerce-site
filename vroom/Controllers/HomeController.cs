using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using vroom.Data;
using vroom.Models;

namespace vroom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // Database
        private readonly ApplicationDbContext _db;
        // User Login
        private readonly UserManager<IdentityUser> _userManager;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, 
            UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _db = db;
            _userManager = userManager;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var book_list = await _db.Books.ToArrayAsync();
            // In order to run sort a list
            // source: https://stackoverflow.com/questions/676500/how-change-listt-data-to-iqueryablet-data/676504
            var book_list_clean = book_list.AsQueryable();

            return View(book_list_clean);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> AddItemAsync(int Id)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(Id);

                var currentUser = await _userManager.GetUserAsync(User);
                if (currentUser == null) return Challenge();

                var book = await _db.Books.Where(x => x.Id == Id).SingleOrDefaultAsync();
                book.User_Id = currentUser.Id;

                //using (var transaction = _db.Database.BeginTransaction())
                //{
                //    _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Books ON");
                //    _db.Update(book);
                //    _db.SaveChanges();
                //    _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Books OFF");
                //    transaction.Commit();
                //}

                try
                {
                    using (var transaction = _db.Database.BeginTransaction())
                    {
                        _db.Update(book);
                        _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Books ON");
                        _db.SaveChanges();
                        _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Books OFF");
                        transaction.Commit();
                    }
                }
                catch
                {
                    Console.WriteLine($"Failed:");
                    _db.Update(book);
                    _db.SaveChanges();
                }



                Console.WriteLine("Book Title " + book.Title);
                Console.WriteLine("Book Description " + book.Description);
                Console.WriteLine("Book UserId " + book.User_Id);

                return RedirectToAction("Index");
            }

            Console.WriteLine("Invalid input");
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
