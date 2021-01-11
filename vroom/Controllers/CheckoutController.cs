using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vroom.Data;

namespace vroom.Controllers
{
    public class CheckoutController : Controller
    {
        // Database
        private readonly ApplicationDbContext _db;
        // User Login
        private readonly UserManager<IdentityUser> _userManager;

        public CheckoutController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<IActionResult> IndexAsync()
        {
            Console.WriteLine("Checkout Page");

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            var book_list = await _db.Books
                    .Where(x => x.User_Id == currentUser.Id)
                    .ToArrayAsync();

            ViewData["Sub_total"] = 0;

            var sub_total = 0;
            for (int i = 0; i < book_list.Length; i++)
            {
                sub_total += book_list[i].Price;
            }
            ViewData["Sub_total"] = sub_total;

            Console.WriteLine("Sub Total: " + ViewData["Sub_total"]);

            ViewData["Sub_total"] = (int)ViewData["Sub_total"];

            return View();
        }

        public async Task<IActionResult> DoneTransactionAsync()
        {
            Console.WriteLine("Done Transaction");

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            var book_list = await _db.Books
                    .Where(x => x.User_Id == currentUser.Id)
                    .ToArrayAsync();
            
            for (int i = 0; i < book_list.Length; i++)
            {
                book_list[i].User_Id = "";
                _db.Update(book_list[i]);
                _db.SaveChanges();
            }

            return Redirect("/");
        }
    }
}
