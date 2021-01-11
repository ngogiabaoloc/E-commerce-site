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

using System.IO;
// for: private readonly HostingEnvironment _hostingEnvironment;
//using Microsoft.Extensions.Hosting.Internal;
//using Microsoft.Extensions.Hosting;

using Microsoft.AspNetCore.Hosting;

namespace vroom.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        // Database
        private readonly ApplicationDbContext _db;
        // User Login
        private readonly UserManager<IdentityUser> _userManager;
        // input from browser
        private readonly IWebHostEnvironment _env;

        public BookController(ApplicationDbContext db, UserManager<IdentityUser> userManager,
                              IWebHostEnvironment env)
        {
            _db = db;
            _userManager = userManager;
            //_hostingEnvironment = hostingEnvironment;
            _env = env;
        }

        // /make
        //public IActionResult Index()
        public async Task<IActionResult> Index(string searchString, string sortOrder)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            //ViewBag.PriceSortParam = "price_des";
            ViewBag.PriceSortParam = String.IsNullOrEmpty(sortOrder) ? "price_desc" : "";
            //ViewBag.CurrentFilter = searchString;

            var book_list = await _db.Books.ToArrayAsync();



            // In order to run sort a list
            // source: https://stackoverflow.com/questions/676500/how-change-listt-data-to-iqueryablet-data/676504
            var book_list_clean = book_list.AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                book_list_clean = book_list_clean.Where(b => b.Title.Contains(searchString));
            }

            if (sortOrder == "price_desc")
            {
                book_list_clean = book_list_clean.OrderByDescending(b => b.Price);
            }
            else
            {
                book_list_clean = book_list_clean.OrderBy(b => b.Price);
            }

            //Console.WriteLine("A number of books: " + book_list.Length);

            //for (int i = 0; i < book_list.Length; i++)
            //{
            //    Console.WriteLine(book_list[i].Title, book_list[i].Description);
            //}

            return View(book_list_clean);
            //return View(_db.Makes.ToList());
        }

        //HTTP Get Method
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //public IActionResult Create(Make make)
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                if (currentUser == null) return Challenge();


                Random rnd = new Random();
                book.Id = rnd.Next((int)Math.Pow(10, 5), (int)Math.Pow(10, 6));

                //Console.WriteLine("User : " + currentUser + " with UserId " + currentUser.Id);
                //Console.WriteLine("Title: " + book.Title);
                //book.Description = "description";
                //Console.WriteLine("Description: " + book.Description);
                //Console.WriteLine("Price: " + book.Price);
                ////book.ImagePath = "path";
                //Console.WriteLine("ImagePath: " + book.ImagePath);
                

                var BookID = book.Id;
                //Console.WriteLine("BookID: " + BookID);

                // Source: https://mariusschulz.com/blog/getting-the-web-root-path-and-the-content-root-path-in-asp-net-core#:~:text=The%20web%20root%20path%20is,web%2Dservable%20application%20content%20files.
                //Get wwrootPath to save the file on server
                string wwrootPath = _env.WebRootPath;
                //Console.WriteLine("WebRootPath: " + wwrootPath);
                //Console.WriteLine("ContentRootPath: " + _env.ContentRootPath);

                //Get the Uploaded files
                var files = HttpContext.Request.Form.Files;
                //Console.WriteLine("files: " + files);


                //Upload the file on server and save the path in database if user have submitted file
                if (files.Count != 0)
                {
                    // ImagePath
                    var ImagePath = "images/";
                    //Extract the extension of submitted file
                    var ImageExtension = Path.GetExtension(files[0].FileName);
                    

                    //Create the relative image path to be saved in database table 
                    var RelativeImagePath = ImagePath + BookID + ImageExtension;

                    //Create absolute image path to upload the physical file on server
                    var AbsImagePath = Path.Combine(wwrootPath, RelativeImagePath);

                    //Upload the file on server using Absolute Path
                    using (var filestream = new FileStream(AbsImagePath, FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    //Set the path in database
                    book.ImagePath = RelativeImagePath;

                    //Console.WriteLine("Extension: " + ImageExtension);
                    //Console.WriteLine("RelativeImagePath: " + RelativeImagePath);
                    //Console.WriteLine("AbsImagePath: " + AbsImagePath);
                }
                try
                {
                    using (var transaction = _db.Database.BeginTransaction())
                    {
                        _db.Add(book);
                        _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Books ON");
                        _db.SaveChanges();
                        _db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Books OFF");
                        transaction.Commit();
                    }
                }
                catch 
                {
                    Console.WriteLine($"Failed:");
                    _db.Add(book);
                    _db.SaveChanges();
                }


                return RedirectToAction(nameof(Index));
            }

            return View(book);
        }

        [Route("Book/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            Console.WriteLine("Delete Item ID : " + id);
            var book = _db.Books.Find(id);
            Console.WriteLine("book : " + book + book.Id + book.Title);

            if (book == null)
            {
                return NotFound();
            }
            _db.Books.Remove(book);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        // == [Route("/book/edit/{id}")]
        public IActionResult Edit(int id)
        {
            Console.WriteLine("Edit Item ID : " + id);
            var book = _db.Books.Find(id);
            Console.WriteLine("Edit : " + book + " " + book.Id + " " + book.Title);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            Console.WriteLine("Edit : " + book + " " + book.Id + " " + book.Title);

            if (ModelState.IsValid)
            {
                var BookID = book.Id;

                // Source: https://mariusschulz.com/blog/getting-the-web-root-path-and-the-content-root-path-in-asp-net-core#:~:text=The%20web%20root%20path%20is,web%2Dservable%20application%20content%20files.
                //Get wwrootPath to save the file on server
                string wwrootPath = _env.WebRootPath;

                //Get the Uploaded files
                var files = HttpContext.Request.Form.Files;


                //Upload the file on server and save the path in database if user have submitted file
                if (files.Count != 0)
                {
                    // ImagePath
                    var ImagePath = "images/";
                    //Extract the extension of submitted file
                    var ImageExtension = Path.GetExtension(files[0].FileName);


                    //Create the relative image path to be saved in database table 
                    var RelativeImagePath = ImagePath + BookID + ImageExtension;

                    //Create absolute image path to upload the physical file on server
                    var AbsImagePath = Path.Combine(wwrootPath, RelativeImagePath);

                    //Upload the file on server using Absolute Path
                    using (var filestream = new FileStream(AbsImagePath, FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    //Set the path in database
                    book.ImagePath = RelativeImagePath;
                }

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


                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }


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
