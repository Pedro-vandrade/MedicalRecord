using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedicalRecord.Data;
using MedicalRecord.Models;

namespace MedicalRecord.Controllers
{
    public class PhysiciansController : Controller
    {
        private readonly MedicalRecordContext _context;

        public PhysiciansController(MedicalRecordContext context)
        {
            _context = context;
        }

        // GET: Physicians
        public async Task<IActionResult> Index()
        {
            return View(await _context.Physicians.ToListAsync());
        }

        // GET: Physicians/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var physician = await _context.Physicians
                .FirstOrDefaultAsync(m => m.Id == id);
            if (physician == null)
            {
                return NotFound();
            }

            return View(physician);
        }

        // GET: Physicians/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Physicians/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,CRM,PhoneNumber")] Physician physician)
        {
            if (ModelState.IsValid)
            {
                _context.Add(physician);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(physician);
        }

        // GET: Physicians/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var physician = await _context.Physicians.FindAsync(id);
            if (physician == null)
            {
                return NotFound();
            }
            return View(physician);
        }

        // POST: Physicians/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,CRM,PhoneNumber")] Physician physician)
        {
            if (id != physician.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(physician);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhysicianExists(physician.Id))
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
            return View(physician);
        }

        // GET: Physicians/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var physician = await _context.Physicians
                .FirstOrDefaultAsync(m => m.Id == id);
            if (physician == null)
            {
                return NotFound();
            }

            return View(physician);
        }

        // POST: Physicians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var physician = await _context.Physicians.FindAsync(id);
            if (physician != null)
            {
                _context.Physicians.Remove(physician);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhysicianExists(int id)
        {
            return _context.Physicians.Any(e => e.Id == id);
        }
    }
}
