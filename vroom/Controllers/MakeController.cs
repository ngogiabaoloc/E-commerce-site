using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vroom.Data;
using vroom.Models;
using Microsoft.EntityFrameworkCore;

namespace vroom.Controllers
{
    [Authorize]
    public class MakeController : Controller
    {
        // Database
        private readonly ApplicationDbContext _db;
        // User Login
        private readonly UserManager<IdentityUser> _userManager;


        public MakeController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        // /make
        //public IActionResult Index()
        public async Task<IActionResult> Index()
        {
            Console.WriteLine("Make Page");
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            Console.WriteLine("User: " + User);
            Console.WriteLine("Current User: " + currentUser);
            Console.WriteLine("Current User Id: " + currentUser.Id);

            var user_item_list = await _db.Makes
                    .Where(x => x.User_Id == currentUser.Id)
                    .ToArrayAsync();

            // test only
            for (int i = 0; i < user_item_list.Length; i++)
            {
                Console.WriteLine(user_item_list[i].User_Id);
                Console.WriteLine(user_item_list[i].Name);
            }

            return View(user_item_list);
            //return View(_db.Makes.ToList());
        }

        //HTTP Get Method
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //public IActionResult Create(Make make)
        public async Task<IActionResult> Create(Make make)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                if (currentUser == null) return Challenge();

                make.User_Id = currentUser.Id;

                Random rnd = new Random();
                make.Id = rnd.Next((int)Math.Pow(10, 5), (int)Math.Pow(10, 6));
                
                Console.WriteLine("User : " + currentUser + " with UserId " + currentUser.Id + " created " + make.Name);

                // Error: https://stackoverflow.com/questions/1334012/cannot-insert-explicit-value-for-identity-column-in-table-table-when-identity
                // Solution source: https://stackoverflow.com/questions/40896047/how-to-turn-on-identity-insert-in-net-core/43973327#43973327
                using (var transaction = _db.Database.BeginTransaction())
                {
                    _db.Makes.Add(make);        // == _db.Add(make);
                    _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Makes ON");
                    _db.SaveChanges();
                    _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Makes OFF");
                    transaction.Commit();
                }

                    

                return RedirectToAction(nameof(Index));
            }

            return View(make);
        }

        //[Route("Make/Delete/{id}")]
        //public IActionResult Delete(int id)
        //{
        //    Console.WriteLine("Delete Item ID : " + id);
        //    var make = _db.Makes.Find(id);
        //    Console.WriteLine("make : " + make + make.Id + make.Name);

        //    if (make == null)
        //    {
        //        return NotFound();
        //    }
        //    _db.Makes.Remove(make);
        //    _db.SaveChanges();

        //    return RedirectToAction(nameof(Index));
        //}

        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    Console.WriteLine("Edit Item ID : " + id);
        //    var make = _db.Makes.Find(id);
        //    Console.WriteLine("Edit : " + make + " "+ make.Id + " " + make.Name);

        //    if (make == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(make);
        //}

        //[HttpPost]
        //public IActionResult Edit(Make make)
        //{
        //    Console.WriteLine("Edit : " + make + " " + make.Id + " " + make.Name);

        //    if (ModelState.IsValid)
        //    {
        //        _db.Update(make);
        //        _db.SaveChanges();
        //        Console.WriteLine("Edit successfully: " + make + " " + make.Id + " " + make.Name);
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return RedirectToAction(nameof(Index));
        //}


        static void test(int year, int month)
        {
            /* 
                // make/bikes
                // [Route("path")] : overwrite the original path
                [Route("Make")]
                [Route("Make/Bikes")]
                public IActionResult Bikes()
                {
                    Make make = new Make { Id = 1, Name = "Max Duong" };

                    return View(make);
                }

                // domain.com/make/bikes -> domain.com/home/privacy/
                public IActionResult Bikes_redirect()
                {
                    Make make = new Make { Id = 1, Name = "Max Duong" };

                    return Redirect("/home/Privacy");
                }

                // domain.com/make/bikes -> domain.com/home/privacy/
                public IActionResult Bikes_redirect_action()
                {
                    Make make = new Make { Id = 1, Name = "Max Duong" };

                    return RedirectToAction("Privacy", "Home");
                }

                [Route("make/bikes/{year}/{month}")]
                public IActionResult ByYearMonth_1(int year, int month)
                {
                    return Content(year + ": " + month);
                }
            */
        }
    }
    
}
