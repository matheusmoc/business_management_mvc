using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcBusinessManagement.Data;
using MvcBusinessManagement.Models;

namespace MvcBusinessManagement.Controllers
{
    public class ManagementController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ManagementController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Management/Index
        public async Task<IActionResult> Index()
        {
            IEnumerable<ManagementModel> management = _db.Management.ToList();
            return  await Task.FromResult(View(management));
        }

        // GET: Management/Create
        public async Task<IActionResult> Create()
        {
            return await Task.FromResult(View());
        }

        // POST: Management/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ManagementModel management)
        {
            if (ModelState.IsValid)
            {
                _db.Add(management);
                await _db.SaveChangesAsync();
                TempData["Message"] = "Registros salvos";
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("", "Por favor complete todos os campos requeridos.");
            return View(management);
        }

        // GET: Management/Edit/`{Id}`
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var existingManagement = await _db.Management.FindAsync(id);

            if (existingManagement == null)
            {
                return NotFound();
            }

            return View(existingManagement);
        }

        // POST: Management/Edit/`{Id}`
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ManagementModel management)
        {
            if (id != management.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Entry(management).State = EntityState.Modified;
                    await _db.SaveChangesAsync();
                    TempData["Message"] = "Registro atualizados";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (management == null)
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
            return View(management);
        }

        // GET: Management/Delete/`{Id}`
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var managementFound = await _db.Management.FirstOrDefaultAsync(x => x.Id == id);
            if (managementFound == null)
            {
                return NotFound();
            }

            // Remove o registro do banco de dados
            _db.Management.Remove(managementFound);
            await _db.SaveChangesAsync();

            TempData["Message"] = "Registro excluído com sucesso.";

            return RedirectToAction(nameof(Index));
        }

    }
}
