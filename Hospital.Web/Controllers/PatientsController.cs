using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Web.Data;
using Hospital.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace Hospital.Web.Controllers
{
    
    [Authorize(Roles = "Admin")]

    public class PatientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Patients
        public async Task<IActionResult> Index()
        {
              return View(await _context.Patients
                  
                  .ToListAsync());
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Patients == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients          
                  
                  
                  . Include(e => e.Orders)
                 
                  .Include(h => h.NurseNotes)
                 
                  .Include(i => i.MedicalNotes)
                 
                  .Include(j => j.VitalSigns)
                 
                  .Include(k => k.LaboratoryExams)

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
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Document,Name,Age,Diagnosis,Entity,DateBirth,IsActive")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    _context.Add(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "hay un registro con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty,
        dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return View(patient);
        }



        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Patients == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Patient patient)
        {
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
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty,dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return View(patient);
        }



        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient patient = await _context.Patients
                 .Include(c => c.VitalSigns)

                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
       
        public async Task<IActionResult> AddVitalSign(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            VitalSign model = new VitalSign { IdPatient = patient.Id };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVitalSign(VitalSign vitalSign)
        {
            if (ModelState.IsValid)
            {
                Patient patient = await _context.Patients
                    .Include(c => c.VitalSigns)
                    .FirstOrDefaultAsync(c => c.Id == vitalSign.IdPatient);
                if (patient == null)
                {
                    return NotFound();
                }

                try
                {
                   // vitalSign.Id = 0; 
            patient.VitalSigns.Add(vitalSign);
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"{nameof(Details)}/{patient.Id}");

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty,
        dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return View(vitalSign);
        }

        public async Task<IActionResult> EditVitalSign(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VitalSign vitalSign = await _context.VitalSigns.FindAsync(id);
            if (vitalSign == null)
            {
                return NotFound();
            }

            Patient patient = await _context.Patients.FirstOrDefaultAsync(c =>
        c.VitalSigns.FirstOrDefault(d => d.Id == vitalSign.Id) != null);
            vitalSign.IdPatient = patient.Id;
            return View(vitalSign);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditVitalSign(VitalSign vitalSign)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vitalSign);
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"{nameof(Details)}/{vitalSign.IdPatient}");

                }
                catch (DbUpdateException dbUpdateException)
                {
                    
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty,
        dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(vitalSign);
        }

        public async Task<IActionResult> DeleteVitalSign(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VitalSign vitalSign = await _context.VitalSigns
               // .Include(d => d.Cities)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vitalSign == null)
            {
                return NotFound();
            }

            Patient patient = await _context.Patients.FirstOrDefaultAsync(c =>
        c.VitalSigns.FirstOrDefault(d => d.Id == vitalSign.Id) != null);
            _context.VitalSigns.Remove(vitalSign);
            await _context.SaveChangesAsync();
            return RedirectToAction($"{nameof(Details)}/{patient.Id}");
        }

        public async Task<IActionResult> AddMedicalNote(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                
                return NotFound();
            }

            MedicalNote model = new MedicalNote { IdPatient = patient.Id };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMedicalNote(MedicalNote medicalNote)
        {
            if (ModelState.IsValid)
            {
                Patient patient = await _context.Patients
                    .Include(d => d.MedicalNotes)
                    .FirstOrDefaultAsync(c => c.Id == medicalNote.IdPatient);
                if (patient == null)
                {
                    return NotFound();
                }

                try
                {
                   // medicalNote.Id = 0;
                    patient.MedicalNotes.Add(medicalNote);
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"{nameof(Details)}/{patient.Id}");

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty,
        dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return View(medicalNote);
        }

        public async Task<IActionResult> AddNurseNote(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {

                return NotFound();
            }

            NurseNote model = new NurseNote { IdPatient = patient.Id };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNurseNote(NurseNote nurseNote)
        {
            if (ModelState.IsValid)
            {
                Patient patient = await _context.Patients
                    .Include(d => d.NurseNotes)
                    .FirstOrDefaultAsync(c => c.Id == nurseNote.IdPatient);
                if (patient == null)
                {
                    return NotFound();
                }

                try
                {
                    //nurseNote.Id = 0;
                    patient.NurseNotes.Add(nurseNote);
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"{nameof(Details)}/{patient.Id}");

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty,
        dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return View(nurseNote);
        }

        public async Task<IActionResult> EditMedicalNote(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MedicalNote medicalNote = await _context.MedicalNotes.FindAsync(id);
            if (medicalNote == null)
            {
                return NotFound();
            }

            Patient patient = await _context.Patients.FirstOrDefaultAsync(c =>
        c.MedicalNotes.FirstOrDefault(d => d.Id == medicalNote.Id) != null);
            medicalNote.IdPatient = patient.Id;
            return View(medicalNote);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMedicalNote(MedicalNote medicalNote)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalNote);
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"{nameof(Details)}/{medicalNote.IdPatient}");

                }
                catch (DbUpdateException dbUpdateException)
                {

                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty,
        dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(medicalNote);
        }

        public async Task<IActionResult> DeleteMedicalNote(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MedicalNote medicalNote = await _context.MedicalNotes
                // .Include(d => d.Cities)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicalNote == null)
            {
                return NotFound();
            }

            Patient patient = await _context.Patients.FirstOrDefaultAsync(c =>
        c.MedicalNotes.FirstOrDefault(d => d.Id == medicalNote.Id) != null);
            _context.MedicalNotes.Remove(medicalNote);
            await _context.SaveChangesAsync();
            return RedirectToAction($"{nameof(Details)}/{patient.Id}");
        }

        public async Task<IActionResult> EditNurseNote(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NurseNote nurseNote = await _context.NurseNotes.FindAsync(id);
            if (nurseNote == null)
            {
                return NotFound();
            }

            Patient patient = await _context.Patients.FirstOrDefaultAsync(c =>
        c.NurseNotes.FirstOrDefault(d => d.Id == nurseNote.Id) != null);
            nurseNote.IdPatient = patient.Id;
            return View(nurseNote);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditNurseNote(NurseNote nurseNote)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nurseNote);
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"{nameof(Details)}/{nurseNote.IdPatient}");

                }
                catch (DbUpdateException dbUpdateException)
                {

                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty,
        dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(nurseNote);
        }

        public async Task<IActionResult> DeleteNurseNote(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NurseNote nurseNote = await _context.NurseNotes
                // .Include(d => d.Cities)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nurseNote == null)
            {
                return NotFound();
            }

            Patient patient = await _context.Patients.FirstOrDefaultAsync(c =>
        c.NurseNotes.FirstOrDefault(d => d.Id == nurseNote.Id) != null);
            _context.NurseNotes.Remove(nurseNote);
            await _context.SaveChangesAsync();
            return RedirectToAction($"{nameof(Details)}/{patient.Id}");
        }

    }
}
