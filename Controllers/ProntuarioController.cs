using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sistema_Prontuario.Data;
using Sistema_Prontuario.Models;

namespace Sistema_Prontuario.Controllers
{
    [Authorize]
    public class ProntuarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProntuarioController(ApplicationDbContext context)
        {
            _context = context;
        }
        //[AllowAnonymous] //para permitir q essa parte seja acessada sem precisar de permissao
        // GET: Prontuario
        public async Task<IActionResult> Index()
        {
              return _context.Prontuarios != null ? 
                          View(await _context.Prontuarios.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Prontuarios'  is null.");
        }

        // GET: Prontuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prontuarios == null)
            {
                return NotFound();
            }

            var prontuario = await _context.Prontuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prontuario == null)
            {
                return NotFound();
            }

            return View(prontuario);
        }

        // GET: Prontuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prontuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CPF,RG,Nome,DataNascimento,Genero,Peso,Altura,Diagnostico,Tratamento,Observacoes")] Prontuario prontuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prontuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prontuario);
        }

        // GET: Prontuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prontuarios == null)
            {
                return NotFound();
            }

            var prontuario = await _context.Prontuarios.FindAsync(id);
            if (prontuario == null)
            {
                return NotFound();
            }
            return View(prontuario);
        }

        // POST: Prontuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CPF,RG,Nome,DataNascimento,Genero,Peso,Altura,Diagnostico,Tratamento,Observacoes")] Prontuario prontuario)
        {
            if (id != prontuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prontuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProntuarioExists(prontuario.Id))
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
            return View(prontuario);
        }

        // GET: Prontuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prontuarios == null)
            {
                return NotFound();
            }

            var prontuario = await _context.Prontuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prontuario == null)
            {
                return NotFound();
            }

            return View(prontuario);
        }

        // POST: Prontuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prontuarios == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Prontuarios'  is null.");
            }
            var prontuario = await _context.Prontuarios.FindAsync(id);
            if (prontuario != null)
            {
                _context.Prontuarios.Remove(prontuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProntuarioExists(int id)
        {
          return (_context.Prontuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
