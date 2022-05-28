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
    public class ProductTransController : Controller
    {
        private readonly ApplicationContext _context;

        public ProductTransController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: ProductTrans
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.ProductTrans.Include(p => p.Product).Include(p => p.Trans);
            return View(await applicationContext.ToListAsync());
        }

        // GET: ProductTrans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTrans = await _context.ProductTrans
                .Include(p => p.Product)
                .Include(p => p.Trans)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productTrans == null)
            {
                return NotFound();
            }

            return View(productTrans);
        }

        // GET: ProductTrans/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductId");
            ViewData["TransId"] = new SelectList(_context.Set<Trans>(), "TransID", "TransID");
            return View();
        }

        // POST: ProductTrans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TransId,ProductId")] ProductTrans productTrans)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productTrans);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductId", productTrans.ProductId);
            ViewData["TransId"] = new SelectList(_context.Set<Trans>(), "TransID", "TransID", productTrans.TransId);
            return View(productTrans);
        }

        // GET: ProductTrans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTrans = await _context.ProductTrans.FindAsync(id);
            if (productTrans == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductId", productTrans.ProductId);
            ViewData["TransId"] = new SelectList(_context.Set<Trans>(), "TransID", "TransID", productTrans.TransId);
            return View(productTrans);
        }

        // POST: ProductTrans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TransId,ProductId")] ProductTrans productTrans)
        {
            if (id != productTrans.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productTrans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductTransExists(productTrans.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductId", productTrans.ProductId);
            ViewData["TransId"] = new SelectList(_context.Set<Trans>(), "TransID", "TransID", productTrans.TransId);
            return View(productTrans);
        }

        // GET: ProductTrans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTrans = await _context.ProductTrans
                .Include(p => p.Product)
                .Include(p => p.Trans)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productTrans == null)
            {
                return NotFound();
            }

            return View(productTrans);
        }

        // POST: ProductTrans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productTrans = await _context.ProductTrans.FindAsync(id);
            _context.ProductTrans.Remove(productTrans);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductTransExists(int id)
        {
            return _context.ProductTrans.Any(e => e.Id == id);
        }
    }
}
