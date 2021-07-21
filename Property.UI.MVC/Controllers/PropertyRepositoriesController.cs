using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Property.Context;
using Property.Domain.Models;

namespace Property.UI.MVC.Controllers
{
    public class PropertyRepositoriesController : Controller
    {
        private readonly AppDbContext _context;

        public PropertyRepositoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PropertyRepositories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Property.ToListAsync());
        }

        // GET: PropertyRepositories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyRepository = await _context.Property
                .FirstOrDefaultAsync(m => m.idProperty == id);
            if (propertyRepository == null)
            {
                return NotFound();
            }

            return View(propertyRepository);
        }

        // GET: PropertyRepositories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PropertyRepositories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idProperty,name,address,price,codeInternal,year,idOwner")] PropertyRepository propertyRepository)
        {
            if (ModelState.IsValid)
            {
                _context.Add(propertyRepository);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(propertyRepository);
        }

        // GET: PropertyRepositories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyRepository = await _context.Property.FindAsync(id);
            if (propertyRepository == null)
            {
                return NotFound();
            }
            return View(propertyRepository);
        }

        // POST: PropertyRepositories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idProperty,name,address,price,codeInternal,year,idOwner")] PropertyRepository propertyRepository)
        {
            if (id != propertyRepository.idProperty)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propertyRepository);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyRepositoryExists(propertyRepository.idProperty))
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
            return View(propertyRepository);
        }

        // GET: PropertyRepositories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyRepository = await _context.Property
                .FirstOrDefaultAsync(m => m.idProperty == id);
            if (propertyRepository == null)
            {
                return NotFound();
            }

            return View(propertyRepository);
        }

        // POST: PropertyRepositories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propertyRepository = await _context.Property.FindAsync(id);
            _context.Property.Remove(propertyRepository);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyRepositoryExists(int id)
        {
            return _context.Property.Any(e => e.idProperty == id);
        }
    }
}
