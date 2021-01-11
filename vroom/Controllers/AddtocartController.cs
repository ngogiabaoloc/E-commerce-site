using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vroom.Data;
using vroom.Models;

namespace vroom.Controllers
{
    public class AddtocartController : Controller
    {
        // Database
        private readonly ApplicationDbContext _db;
        // User Login
        private readonly UserManager<IdentityUser> _userManager;


        public AddtocartController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        // /addtocart
        //public IActionResult Index()
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            Console.WriteLine("Add_To_Cart Page");

            var book_list = await _db.Books
                    .Where(x => x.User_Id == currentUser.Id)
                    .ToArrayAsync();

            for (int i = 0; i < book_list.Length; i++)
            {
                Console.WriteLine("Title: " + book_list[i].Title);
                Console.WriteLine("Descrip: " + book_list[i].Description);
                Console.WriteLine("User Id: " + book_list[i].User_Id);
            }

            //return View(user_item_list);
            return View(book_list);
        }

    }
    
}
