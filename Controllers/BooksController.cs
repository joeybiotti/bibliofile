using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bibliofile.Data;
using Bibliofile.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Bibliofile.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
         private readonly UserManager<ApplicationUser> _userManager;

        public BooksController(ApplicationDbContext context,  UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;    
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View(await _context.Books.Where(b => b.IsRead == true).ToListAsync());   
        }

        //GET To Read
        public async Task<IActionResult> ToRead()
        {
            return View(await _context.Books.Where(b => b.IsRead == false).ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Books
                .SingleOrDefaultAsync(m => m.BookId == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,Title,Author,Image")] Books books)
        {
            if (ModelState.IsValid)
            {
                _context.Add(books);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(books);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Books.SingleOrDefaultAsync(m => m.BookId == id);
            if (books == null)
            {
                return NotFound();
            }
            return View(books);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Books books)
        {
            if (id != books.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(books);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BooksExists(books.BookId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(books);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Books
                .SingleOrDefaultAsync(m => m.BookId == id);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var books = await _context.Books.SingleOrDefaultAsync(m => m.BookId == id);
            _context.Books.Remove(books);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BooksExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }
    
        //Search method to search database 
        //When search btn is clicked, database is filtered for either title or author
        [ActionName("Search")]
        public async Task <IActionResult> SearchIndex(string SearchString)
        {
            var books = from b in _context.Books
                select b; 

            var id = await GetCurrentUserAsync();
            
                if(!String.IsNullOrEmpty(SearchString))
                {
                    books = books.Where(b => b.Title.Contains(SearchString)
                                            || b.Author.Contains(SearchString));
                }
                return View(books);
        }

        //Make Book Read 
        public async Task<IActionResult> MakeBookRead(int id)
        {
            var book = await _context.Books
                .SingleOrDefaultAsync(m => m.BookId == id);
                book.IsRead = true;
                _context.Update(book);
                _context.SaveChanges();
               return RedirectToAction("Index");
        }
    }
}