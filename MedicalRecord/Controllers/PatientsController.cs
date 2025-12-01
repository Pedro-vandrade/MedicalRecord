using MedicalRecord.Data;
using MedicalRecord.Models.Enums; // 👈 Include the Enums namespace
using MedicalRecord.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalRecord.Controllers
{
    public class PatientsController : Controller
    {
        private readonly MedicalRecordContext _context;

        public PatientsController(MedicalRecordContext context)
        {
            _context = context;
        }

        // Helper method to populate ViewBags with Enum values for dropdowns
        private void PopulateEnumViewBags()
        {
            ViewBag.GenderIdentities = Enum.GetValues(typeof(GenderIdentity));
            ViewBag.MaritalStatuses = Enum.GetValues(typeof(MaritalStatus));
            ViewBag.BloodTypes = Enum.GetValues(typeof(BloodType));
        }

        // GET: Patients
        public async Task<IActionResult> Index()
        {
            return View(await _context.Patients.ToListAsync());
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // ⚠️ Changed m.Id to m.PatientId
            var patient = await _context.Patients
                // Add Includes here if you want to display related data (History, Allergies, etc.)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            PopulateEnumViewBags(); // 👈 Populate Enums for the View
            return View();
        }

        // POST: Patients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullName,DateOfBirth,Gender,MaritalStatus,BloodType,PhoneNumber,Email,Address,City,PostalCode")] Patient patient)
        {
            // 👈 Set the required DateRegistered field here, as it's not a form input
           // patient.DateRegistered = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            PopulateEnumViewBags(); // 👈 Repopulate if validation fails
            return View(patient);
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            PopulateEnumViewBags(); // 👈 Populate Enums for the View
            return View(patient);
        }

        // POST: Patients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        // ⚠️ Updated Bind list to include all new enum properties and the PK (PatientId)
        // DateRegistered is included to prevent EF from resetting it, but should not be editable by the user.
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,DateOfBirth,Gender,MaritalStatus,BloodType,PhoneNumber,Email,Address,City,PostalCode")] Patient patient)
        {
            // ⚠️ Check against PatientId, not Id
            if (id != patient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // ⚠️ Check against PatientId, not Id
                    if (!PatientExists(patient.Id))
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

            PopulateEnumViewBags(); // 👈 Repopulate if validation fails
            return View(patient);
        }

        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // ⚠️ Changed m.Id to m.PatientId
            var patient = await _context.Patients
                .FirstOrDefaultAsync(m => m.Id == id);

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientExists(int id)
        {
            // ⚠️ Changed e.Id to e.PatientId
            return _context.Patients.Any(e => e.Id == id);
        }
    }
}