using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myprojectpharmacy.Models;
using Microsoft.AspNetCore.Authorization;

namespace myprojectpharmacy.Controllers
{
    [Authorize]
    public class PrescriptionController : Controller
    {
        private readonly AppDbContext _context;

        public PrescriptionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Prescription
        public async Task<IActionResult> Index()
        {
            var prescriptions = _context.Prescriptions.Include(p => p.Patient).Include(p => p.Pharmacist);
            return View(await prescriptions.ToListAsync());
        }

        // GET: Prescription/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var prescription = await _context.Prescriptions
                .Include(p => p.Patient)
                .Include(p => p.Pharmacist)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prescription == null) return NotFound();
            return View(prescription);
        }

        // GET: Prescription/Create
        public IActionResult Create()
        {
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FullName");
            ViewData["PharmacistId"] = new SelectList(_context.Pharmacists, "Id", "FullName");
            return View();
        }

        // POST: Prescription/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FullName", prescription.PatientId);
            ViewData["PharmacistId"] = new SelectList(_context.Pharmacists, "Id", "FullName", prescription.PharmacistId);
            return View(prescription);
        }

        // GET: Prescription/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var prescription = await _context.Prescriptions.FindAsync(id);
            if (prescription == null) return NotFound();
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FullName", prescription.PatientId);
            ViewData["PharmacistId"] = new SelectList(_context.Pharmacists, "Id", "FullName", prescription.PharmacistId);
            return View(prescription);
        }

        // POST: Prescription/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Prescription prescription)
        {
            if (id != prescription.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Prescriptions.Any(e => e.Id == prescription.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "FullName", prescription.PatientId);
            ViewData["PharmacistId"] = new SelectList(_context.Pharmacists, "Id", "FullName", prescription.PharmacistId);
            return View(prescription);
        }

        // GET: Prescription/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var prescription = await _context.Prescriptions
                .Include(p => p.Patient)
                .Include(p => p.Pharmacist)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prescription == null) return NotFound();
            return View(prescription);
        }

        // POST: Prescription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prescription = await _context.Prescriptions.FindAsync(id);
            if (prescription != null)
            {
                _context.Prescriptions.Remove(prescription);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
