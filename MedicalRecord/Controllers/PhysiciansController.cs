using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicalRecord.Data;
using MedicalRecord.Models;
using MedicalRecord.Models.Enums;

namespace MedicalRecord.Controllers
{
    public class PhysiciansController : Controller
    {
        private readonly MedicalRecordContext _context;

        public PhysiciansController(MedicalRecordContext context)
        {
            _context = context;
        }

        // Helper method to populate ViewBag for dropdowns
        private void PopulateEnumViewBags()
        {
            ViewBag.PhysicianSpecialties = Enum.GetValues(typeof(PhysicianSpecialty));
        }

        // 1. READ (List)
        // GET: Physicians
        public async Task<IActionResult> Index()
        {
            return View(await _context.Physicians.ToListAsync());
        }

        // 2. READ (Details)
        // GET: Physicians/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointments = _context.Appointments.Include("Patient").Where(appt => appt.PhysicianId == id).ToList();

            //verifcar como usar viewbag para não precisar criar uma classe auxiliar viewmodel

            // Use PhysicianId as the primary key reference
            var physician = await _context.Physicians
                .FirstOrDefaultAsync(m => m.Id == id);
            if (physician == null)
            {
                return NotFound();
            }

            return View(physician);
        }

        // 3. CREATE
        // GET: Physicians/Create
        public IActionResult Create()
        {
            PopulateEnumViewBags(); // FIX: Load Enums
            return View();
        }

        // POST: Physicians/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullDocName,PhysicianSpecialty,CRM,PhoneNumber")] Physician physician)
        {
            if (ModelState.IsValid)
            {
                _context.Add(physician);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            PopulateEnumViewBags(); // Reload Enums if validation fails
            return View(physician);
        }

        // 4. UPDATE (Edit)
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

            PopulateEnumViewBags(); // Load Enums for the View
            return View(physician);
        }

        // POST: Physicians/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Ensure PhysicianId is bound to track the record
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullDocName,PhysicianSpecialty,CRM,PhoneNumber")] Physician physician)
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
                    if (!_context.Physicians.Any(e => e.Id == physician.Id))
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

            PopulateEnumViewBags(); // Reload Enums if validation fails
            return View(physician);
        }

        // 5. DELETE
        // GET: Physicians/Delete/5 (Confirmation)
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

        // POST: Physicians/Delete/5 (Execution)
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
    }
}