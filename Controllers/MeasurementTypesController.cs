using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NextGenInventories_2._0.Data;
using NextGenInventories_2._0.Models;

namespace NextGenInventories_2._0.Controllers
{
    public class MeasurementTypesController : Controller
    {
        private readonly NextGenInventories_2_0Context _context;

        public MeasurementTypesController(NextGenInventories_2_0Context context)
        {
            _context = context;
        }

        // GET: MeasurementTypes
        public async Task<IActionResult> Index()
        {
              return _context.MeasurementType != null ? 
                          View(await _context.MeasurementType.ToListAsync()) :
                          Problem("Entity set 'NextGenInventories_2_0Context.MeasurementType'  is null.");
        }

        // GET: MeasurementTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MeasurementType == null)
            {
                return NotFound();
            }

            var measurementType = await _context.MeasurementType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (measurementType == null)
            {
                return NotFound();
            }

            return View(measurementType);
        }

        // GET: MeasurementTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MeasurementTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] MeasurementType measurementType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(measurementType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(measurementType);
        }

        // GET: MeasurementTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MeasurementType == null)
            {
                return NotFound();
            }

            var measurementType = await _context.MeasurementType.FindAsync(id);
            if (measurementType == null)
            {
                return NotFound();
            }
            return View(measurementType);
        }

        // POST: MeasurementTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] MeasurementType measurementType)
        {
            if (id != measurementType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(measurementType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeasurementTypeExists(measurementType.Id))
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
            return View(measurementType);
        }

        // GET: MeasurementTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MeasurementType == null)
            {
                return NotFound();
            }

            var measurementType = await _context.MeasurementType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (measurementType == null)
            {
                return NotFound();
            }

            return View(measurementType);
        }

        // POST: MeasurementTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MeasurementType == null)
            {
                return Problem("Entity set 'NextGenInventories_2_0Context.MeasurementType'  is null.");
            }
            var measurementType = await _context.MeasurementType.FindAsync(id);
            if (measurementType != null)
            {
                _context.MeasurementType.Remove(measurementType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeasurementTypeExists(int id)
        {
          return (_context.MeasurementType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
