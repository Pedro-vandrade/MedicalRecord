using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedicalRecord.Data;
using MedicalRecord.Models;
using MedicalRecord.Models.Enums; // Still needed for PhysicianSpecialty for FullDocName

namespace MedicalRecord.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly MedicalRecordContext _context;

        public AppointmentsController(MedicalRecordContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var medicalRecordContext = _context.Appointments.Include(a => a.Patient).Include(a => a.Physician);
            return View(await medicalRecordContext.ToListAsync());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var appointment = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Physician)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null) return NotFound();

            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewBag.PatientId = new SelectList(_context.Patients.OrderBy(p => p.FullName), "Id", "FullName");
            ViewBag.PhysicianId = new SelectList(_context.Physicians.OrderBy(d => d.FullDocName), "Id", "FullDocName");
            return View();
        }

        // POST: Appointments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientId,PhysicianId,AppointmentDate,ReasonForVisit,Notes")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Reload lookups on failure
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FullName", appointment.PatientId);
            ViewData["PhysicianId"] = new SelectList(_context.Physicians, "Id", "FullDocName", appointment.PhysicianId);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null) return NotFound();

            // Reload lookups for view
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FullName", appointment.PatientId);
            ViewData["PhysicianId"] = new SelectList(_context.Physicians, "Id", "FullDocName", appointment.PhysicianId);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientId,PhysicianId,AppointmentDate,ReasonForVisit,Notes")] Appointment appointment)
        {
            if (id != appointment.Id) return NotFound();

            // NOTE: ModelState will pass now if the user selects valid Patient/Physician IDs
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }

            // Reload lookups on failure
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FullName", appointment.PatientId);
            ViewData["PhysicianId"] = new SelectList(_context.Physicians, "Id", "FullDocName", appointment.PhysicianId);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var appointment = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Physician)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null) return NotFound();

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.Id == id);
        }
    }
}