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
    public class DiscountTransController : Controller
    {
        private readonly ApplicationContext _context;

        public DiscountTransController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: DiscountTrans
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.DiscountTrans.Include(d => d.Discount).Include(d => d.Trans);
            return View(await applicationContext.ToListAsync());
        }

        // GET: DiscountTrans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discountTrans = await _context.DiscountTrans
                .Include(d => d.Discount)
                .Include(d => d.Trans)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (discountTrans == null)
            {
                return NotFound();
            }

            return View(discountTrans);
        }

        // GET: DiscountTrans/Create
        public IActionResult Create()
        {
            ViewData["DiscountId"] = new SelectList(_context.Discount, "DiscountId", "DiscountId");
            ViewData["TransId"] = new SelectList(_context.Set<Trans>(), "TransID", "TransID");
            return View();
        }

        // POST: DiscountTrans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TransId,DiscountId")] DiscountTrans discountTrans)
        {
            if (ModelState.IsValid)
            {
                _context.Add(discountTrans);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiscountId"] = new SelectList(_context.Discount, "DiscountId", "DiscountId", discountTrans.DiscountId);
            ViewData["TransId"] = new SelectList(_context.Set<Trans>(), "TransID", "TransID", discountTrans.TransId);
            return View(discountTrans);
        }

        // GET: DiscountTrans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discountTrans = await _context.DiscountTrans.FindAsync(id);
            if (discountTrans == null)
            {
                return NotFound();
            }
            ViewData["DiscountId"] = new SelectList(_context.Discount, "DiscountId", "DiscountId", discountTrans.DiscountId);
            ViewData["TransId"] = new SelectList(_context.Set<Trans>(), "TransID", "TransID", discountTrans.TransId);
            return View(discountTrans);
        }

        // POST: DiscountTrans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TransId,DiscountId")] DiscountTrans discountTrans)
        {
            if (id != discountTrans.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(discountTrans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiscountTransExists(discountTrans.ID))
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
            ViewData["DiscountId"] = new SelectList(_context.Discount, "DiscountId", "DiscountId", discountTrans.DiscountId);
            ViewData["TransId"] = new SelectList(_context.Set<Trans>(), "TransID", "TransID", discountTrans.TransId);
            return View(discountTrans);
        }

        // GET: DiscountTrans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discountTrans = await _context.DiscountTrans
                .Include(d => d.Discount)
                .Include(d => d.Trans)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (discountTrans == null)
            {
                return NotFound();
            }

            return View(discountTrans);
        }

        // POST: DiscountTrans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var discountTrans = await _context.DiscountTrans.FindAsync(id);
            _context.DiscountTrans.Remove(discountTrans);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiscountTransExists(int id)
        {
            return _context.DiscountTrans.Any(e => e.ID == id);
        }
    }
}
