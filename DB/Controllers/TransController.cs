using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DB.Models;

namespace DB.Controllers
{
    public class TransController : Controller
    {
        private readonly ApplicationContext _context;

        public TransController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Trans
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Trans.Include(t => t.Customer);
            return View(await applicationContext.ToListAsync());
        }

        // GET: Trans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trans = await _context.Trans
                .Include(t => t.Customer)
                .FirstOrDefaultAsync(m => m.TransID == id);
            if (trans == null)
            {
                return NotFound();
            }

            return View(trans);
        }

        // GET: Trans/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId");
            return View();
        }

        // POST: Trans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransID,TransDate,CustomerId,WholesaleSign")] Trans trans)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trans);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", trans.CustomerId);
            return View(trans);
        }

        // GET: Trans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trans = await _context.Trans.FindAsync(id);
            if (trans == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", trans.CustomerId);
            return View(trans);
        }

        // POST: Trans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransID,TransDate,CustomerId,WholesaleSign")] Trans trans)
        {
            if (id != trans.TransID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransExists(trans.TransID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", trans.CustomerId);
            return View(trans);
        }

        // GET: Trans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trans = await _context.Trans
                .Include(t => t.Customer)
                .FirstOrDefaultAsync(m => m.TransID == id);
            if (trans == null)
            {
                return NotFound();
            }

            return View(trans);
        }

        // POST: Trans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trans = await _context.Trans.FindAsync(id);
            _context.Trans.Remove(trans);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransExists(int id)
        {
            return _context.Trans.Any(e => e.TransID == id);
        }
    }
}
