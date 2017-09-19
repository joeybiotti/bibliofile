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
    public class ToReadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToReadController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ToRead
        public async Task<IActionResult> Index()
        {
            return View(await _context.ToRead.ToListAsync());
        }

        // GET: ToRead/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toRead = await _context.ToRead
                .SingleOrDefaultAsync(m => m.BookId == id);
            if (toRead == null)
            {
                return NotFound();
            }

            return View(toRead);
        }

        // GET: ToRead/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToRead/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,Title,Author,Image,IsRead")] ToRead toRead)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toRead);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(toRead);
        }

        // GET: ToRead/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toRead = await _context.ToRead.SingleOrDefaultAsync(m => m.BookId == id);
            if (toRead == null)
            {
                return NotFound();
            }
            return View(toRead);
        }

        // POST: ToRead/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ToRead toRead)
        {
            if (id != toRead.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toRead);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToReadExists(toRead.BookId))
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
            return View(toRead);
        }

        // GET: ToRead/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toRead = await _context.ToRead
                .SingleOrDefaultAsync(m => m.BookId == id);
            if (toRead == null)
            {
                return NotFound();
            }

            return View(toRead);
        }

        // POST: ToRead/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toRead = await _context.ToRead.SingleOrDefaultAsync(m => m.BookId == id);
            _context.ToRead.Remove(toRead);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ToReadExists(int id)
        {
            return _context.ToRead.Any(e => e.BookId == id);
        }

        //POST Change IsRead from false to true
        // [HttpPost]
        // public async Task<IActionResult> MakeBookRead(int id)
        // {
        //     var book = await _context.ToRead.SingleOrDefaultAsync(o => o.IsRead == false);
        //     return(book === true);
        //}
    //}
    }
} 