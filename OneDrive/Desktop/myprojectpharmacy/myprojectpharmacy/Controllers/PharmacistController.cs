using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myprojectpharmacy.Models;
using Microsoft.AspNetCore.Authorization;

namespace myprojectpharmacy.Controllers
{
    [Authorize]
    public class PharmacistController : Controller
    {
        private readonly AppDbContext _context;

        public PharmacistController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Pharmacist
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pharmacists.ToListAsync());
        }

        // GET: Pharmacist/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var pharmacist = await _context.Pharmacists.FindAsync(id);
            if (pharmacist == null) return NotFound();
            return View(pharmacist);
        }

        // GET: Pharmacist/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pharmacist/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pharmacist pharmacist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pharmacist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pharmacist);
        }

        // GET: Pharmacist/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var pharmacist = await _context.Pharmacists.FindAsync(id);
            if (pharmacist == null) return NotFound();
            return View(pharmacist);
        }

        // POST: Pharmacist/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Pharmacist pharmacist)
        {
            if (id != pharmacist.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pharmacist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Pharmacists.Any(e => e.Id == pharmacist.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pharmacist);
        }

        // GET: Pharmacist/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var pharmacist = await _context.Pharmacists.FindAsync(id);
            if (pharmacist == null) return NotFound();
            return View(pharmacist);
        }

        // POST: Pharmacist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pharmacist = await _context.Pharmacists.FindAsync(id);
            if (pharmacist != null)
            {
                _context.Pharmacists.Remove(pharmacist);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
