using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pet_Web_Application_10._12._24_F.Data;
using Pet_Web_Application_10._12._24_F.Models;

namespace Pet_Web_Application_10._12._24_F.Migrations
{
    public class PuppiesController : Controller
    {
        private readonly PuppiesProductPurchasesDbFContext _context;

        public PuppiesController(PuppiesProductPurchasesDbFContext context)
        {
            _context = context;
        }

        // GET: Puppies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Puppies.ToListAsync());
        }

        // GET: Puppies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puppies = await _context.Puppies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (puppies == null)
            {
                return NotFound();
            }

            return View(puppies);
        }

        // GET: Puppies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Puppies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BreedName,ProductName,MyPuppy,PuppyPrice")] Puppies puppies)
        {
            if (ModelState.IsValid)
            {
                _context.Add(puppies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(puppies);
        }

        // GET: Puppies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puppies = await _context.Puppies.FindAsync(id);
            if (puppies == null)
            {
                return NotFound();
            }
            return View(puppies);
        }

        // POST: Puppies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BreedName,ProductName,MyPuppy,PuppyPrice")] Puppies puppies)
        {
            if (id != puppies.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(puppies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PuppiesExists(puppies.Id))
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
            return View(puppies);
        }

        // GET: Puppies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puppies = await _context.Puppies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (puppies == null)
            {
                return NotFound();
            }

            return View(puppies);
        }

        // POST: Puppies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var puppies = await _context.Puppies.FindAsync(id);
            if (puppies != null)
            {
                _context.Puppies.Remove(puppies);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PuppiesExists(int id)
        {
            return _context.Puppies.Any(e => e.Id == id);
        }
    }
}
