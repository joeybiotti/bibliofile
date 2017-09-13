using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bibliofile.Data;
using Bibliofile.Models;

namespace bibliofile.Controllers
{
    public class UserBooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserBooksController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: UserBooks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserBooks.Include(u => u.Book);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userBooks = await _context.UserBooks
                .Include(u => u.Book)
                .SingleOrDefaultAsync(m => m.UserBookId == id);
            if (userBooks == null)
            {
                return NotFound();
            }

            return View(userBooks);
        }

        // GET: UserBooks/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId");
            return View();
        }

        // POST: UserBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserBookId,IsRead,BookId")] UserBooks userBooks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userBooks);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", userBooks.BookId);
            return View(userBooks);
        }

        // GET: UserBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userBooks = await _context.UserBooks.SingleOrDefaultAsync(m => m.UserBookId == id);
            if (userBooks == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", userBooks.BookId);
            return View(userBooks);
        }

        // POST: UserBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserBookId,IsRead,BookId")] UserBooks userBooks)
        {
            if (id != userBooks.UserBookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userBooks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserBooksExists(userBooks.UserBookId))
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
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", userBooks.BookId);
            return View(userBooks);
        }

        // GET: UserBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userBooks = await _context.UserBooks
                .Include(u => u.Book)
                .SingleOrDefaultAsync(m => m.UserBookId == id);
            if (userBooks == null)
            {
                return NotFound();
            }

            return View(userBooks);
        }

        // POST: UserBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userBooks = await _context.UserBooks.SingleOrDefaultAsync(m => m.UserBookId == id);
            _context.UserBooks.Remove(userBooks);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UserBooksExists(int id)
        {
            return _context.UserBooks.Any(e => e.UserBookId == id);
        }
    }
}
