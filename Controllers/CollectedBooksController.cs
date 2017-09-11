using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bibliofile.Data;
using bibliofile.Models;

namespace bibliofile.Controllers
{
    // Built by scaffolding-- 9/11
    public class CollectedBooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CollectedBooksController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: CollectedBooks
        public async Task<IActionResult> Index()
        {
            return View(await _context.CollectedBooks.ToListAsync());
        }

        // GET: CollectedBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collectedBooks = await _context.CollectedBooks
                .SingleOrDefaultAsync(m => m.CollectedBookId == id);
            if (collectedBooks == null)
            {
                return NotFound();
            }

            return View(collectedBooks);
        }

        // GET: CollectedBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CollectedBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CollectedBookId,Author,Summary")] CollectedBooks collectedBooks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collectedBooks);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(collectedBooks);
        }

        // GET: CollectedBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collectedBooks = await _context.CollectedBooks.SingleOrDefaultAsync(m => m.CollectedBookId == id);
            if (collectedBooks == null)
            {
                return NotFound();
            }
            return View(collectedBooks);
        }

        // POST: CollectedBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CollectedBookId,Author,Summary")] CollectedBooks collectedBooks)
        {
            if (id != collectedBooks.CollectedBookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(collectedBooks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollectedBooksExists(collectedBooks.CollectedBookId))
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
            return View(collectedBooks);
        }

        // GET: CollectedBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collectedBooks = await _context.CollectedBooks
                .SingleOrDefaultAsync(m => m.CollectedBookId == id);
            if (collectedBooks == null)
            {
                return NotFound();
            }

            return View(collectedBooks);
        }

        // POST: CollectedBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var collectedBooks = await _context.CollectedBooks.SingleOrDefaultAsync(m => m.CollectedBookId == id);
            _context.CollectedBooks.Remove(collectedBooks);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CollectedBooksExists(int id)
        {
            return _context.CollectedBooks.Any(e => e.CollectedBookId == id);
        }
    }
}
