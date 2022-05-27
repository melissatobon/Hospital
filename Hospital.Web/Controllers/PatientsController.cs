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
                .Include(c => c.LaboratoryExams)
                .Include(c => c.Orders)
                .Include(c => c.MedicalNotes)
                .Include(c => c.VitalSigns)
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
                .Include(c => c.LaboratoryExams)
                .Include(c => c.Orders)
                .Include(c => c.MedicalNotes)
                .Include(c => c.VitalSigns)


                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }


        public IActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Documento, Name, Age, Diagnosis, Entity, DateBirth, Record")] Patient patient)
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
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
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
                .Include(c => c.LaboratoryExams)
                .Include(c => c.Orders)
                .Include(c => c.MedicalNotes)
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
                    .Include(c => c.MedicalNotes)
                    .Include(c => c.LaboratoryExams)
                    .Include(c => c.Orders)
                    .FirstOrDefaultAsync(c => c.Id == vitalSign.IdPatient);
                if (patient == null)
                {
                    return NotFound();
                }

                try
                {
                    vitalSign.Id = 0;
                    patient.VitalSigns.Add(vitalSign);
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new
                    {
                        Id = patient.Id
                    });
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
                    return RedirectToAction(nameof(Details), new { Id = vitalSign.IdPatient });
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
           .FirstOrDefaultAsync(m => m.Id == id);
            if (vitalSign == null)
            {
                return NotFound();
            }

            Patient patient = await _context.Patients.FirstOrDefaultAsync(d
            => d.VitalSigns.FirstOrDefault(c => c.Id == vitalSign.Id) != null);
            _context.VitalSigns.Remove(vitalSign);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new
            {
                Id = patient.Id
            });
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
                    .Include(d => d.LaboratoryExams)
                    .Include(d => d.MedicalNotes)
                    .Include(d => d.Orders)
                    .FirstOrDefaultAsync(c => c.Id == medicalNote.IdPatient);
                if (patient == null)
                {
                    return NotFound();
                }

                try
                {
                    medicalNote.Id = 0;
                    patient.MedicalNotes.Add(medicalNote);
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(AddMedicalNote), new
                    {
                        Id = patient.Id
                    });
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
                    return RedirectToAction(nameof(Details), new { Id = medicalNote.IdPatient });
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

                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicalNote == null)
            {
                return NotFound();
            }

            Patient patient = await _context.Patients.FirstOrDefaultAsync(c =>
        c.MedicalNotes.FirstOrDefault(d => d.Id == medicalNote.Id) != null);
            _context.MedicalNotes.Remove(medicalNote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new
            {
                Id = patient.Id
            });


        }

        public async Task<IActionResult> AddLaboratoryExam(int? id)
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

            LaboratoryExam model = new LaboratoryExam { IdPatient = patient.Id };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddLaboratoryExam(LaboratoryExam laboratoryExam)
        {
            if (ModelState.IsValid)
            {
                Patient patient = await _context.Patients
                    .Include(d => d.MedicalNotes)
                    .Include(d => d.LaboratoryExams)
                    .Include(d => d.MedicalNotes)
                    .Include(d => d.Orders)
                    .FirstOrDefaultAsync(c => c.Id == laboratoryExam.IdPatient);
                if (patient == null)
                {
                    return NotFound();
                }

                try
                {
                    laboratoryExam.Id = 0;
                    patient.LaboratoryExams.Add(laboratoryExam);
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new
                    {
                        Id = patient.Id
                    });
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

            return View(laboratoryExam);
        }



        public async Task<IActionResult> EditLaboratoryExam(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LaboratoryExam laboratoryExam = await _context.LaboratoryExams.FindAsync(id);
            if (laboratoryExam == null)
            {
                return NotFound();
            }

            Patient patient = await _context.Patients.FirstOrDefaultAsync(c =>
        c.LaboratoryExams.FirstOrDefault(d => d.Id == laboratoryExam.Id) != null);
            laboratoryExam.IdPatient = patient.Id;
            return View(laboratoryExam);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditLaboratoryExam(LaboratoryExam laboratoryExam)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laboratoryExam);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new { Id = laboratoryExam.IdPatient });
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
            return View(laboratoryExam);
        }

        public async Task<IActionResult> DeleteLaboratoryExam(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LaboratoryExam laboratoryExam = await _context.LaboratoryExams

                .FirstOrDefaultAsync(m => m.Id == id);
            if (laboratoryExam == null)
            {
                return NotFound();
            }

            Patient patient = await _context.Patients.FirstOrDefaultAsync(c =>
        c.LaboratoryExams.FirstOrDefault(d => d.Id == laboratoryExam.Id) != null);
            _context.LaboratoryExams.Remove(laboratoryExam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new
            {
                Id = patient.Id
            });


        }

        public async Task<IActionResult> AddOrder(int? id)
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

            Order model = new Order { IdPatient = patient.Id };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                Patient patient = await _context.Patients
                    .Include(d => d.MedicalNotes)
                    .Include(d => d.LaboratoryExams)
                    .Include(d => d.MedicalNotes)
                    .Include(d => d.Orders)
                    .FirstOrDefaultAsync(c => c.Id == order.IdPatient);
                if (patient == null)
                {
                    return NotFound();
                }

                try
                {
                    order.Id = 0;
                    patient.Orders.Add(order);
                    _context.Update(patient);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new
                    {
                        Id = patient.Id
                    });
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

            return View(order);
        }



        public async Task<IActionResult> EditOrder(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            Patient patient = await _context.Patients.FirstOrDefaultAsync(c =>
        c.Orders.FirstOrDefault(d => d.Id == order.Id) != null);
            order.IdPatient = patient.Id;
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new { Id = order.IdPatient });
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
            return View(order);
        }

        public async Task<IActionResult> DeleteOrder(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order order = await _context.Orders

                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            Patient patient = await _context.Patients.FirstOrDefaultAsync(c =>
        c.Orders.FirstOrDefault(d => d.Id == order.Id) != null);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new
            {
                Id = patient.Id
            });


        }
    }
}
