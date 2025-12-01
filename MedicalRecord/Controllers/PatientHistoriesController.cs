using MedicalRecord.Data;
using MedicalRecord.Models;
using MedicalRecord.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using MedicalRecord.ViewModels;

namespace MedicalRecord.Controllers
{
    public class PatientHistoriesController : Controller
    {
        private readonly MedicalRecordContext _context;

        public PatientHistoriesController(MedicalRecordContext context)
        {
            _context = context;
        }

        // 🌟 CORRECTION 1: Using unique ViewBag keys for each Enum 🌟
        private void PopulateEnumViewBags() { 
            ViewBag.BloodTypes = Enum.GetValues(typeof(Models.Enums.BloodType));
            ViewBag.Diseases = Enum.GetValues(typeof(Models.Enums.DiseasesConditions)); // Renamed key
            ViewBag.Surgeries = Enum.GetValues(typeof(Models.Enums.SurgicalProcedures)); // Renamed key
            ViewBag.ExerciseActivityEnum = Enum.GetValues(typeof(Models.Enums.Exercise)); // Renamed key
            ViewBag.ExerciseFrequencyEnum = Enum.GetValues(typeof(Models.Enums.ExFrequency)); // Renamed key
            ViewBag.AlcoholConsumptionEnum = Enum.GetValues(typeof(Models.Enums.AlcConsumption)); // Renamed key
            ViewBag.SmokingStatusEnum = Enum.GetValues(typeof(Models.Enums.SmokingStatus)); // Renamed key
        }



        // GET: PatientHistories
        public async Task<IActionResult> Index()
        {

            var medicalRecordContext = _context.PatientHistories;
            var patientHistories = await medicalRecordContext.ToListAsync();
            return View(patientHistories);
        }


        // GET: PatientHistories/Create
        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FullName");
            PopulateEnumViewBags(); // 🌟 CORRECTION 2: Call the method to populate ViewBags 🌟
            return View();
        }

        // POST: PatientHistories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientId,BloodType,KnownConditionsAndDiseases,SurgicalHistory,ExerciseActivity,ExerciseFrequency,Smoker,AlcoholConsumption")] PatientHistory patientHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FullName", patientHistory.PatientId);
            PopulateEnumViewBags(); // Call method again if validation fails, to re-populate the dropdowns
            return View(patientHistory);
        }

        // GET: PatientHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientHistory = await _context.PatientHistories.FindAsync(id);
            if (patientHistory == null)
            {
                return NotFound();
            }
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FullName", patientHistory.PatientId);
            PopulateEnumViewBags(); // Call method for Edit View too
            return View(patientHistory);
        }

        // ... (other controller methods omitted for brevity)
    }
}