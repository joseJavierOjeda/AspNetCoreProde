using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Negocio.Interface.Equipo;
using Prode.Models;

namespace Prode.Areas.Equipo.Controllers
{
    [Area("Equipo")]
    public class PartidoController : Controller
    {
        #region Atributos
        private readonly IJugadorNegocio jugadorNegocio;
        private readonly ProdeContext _context;
        #endregion

        #region Constructor
        public PartidoController(IJugadorNegocio jugadorNegocio,
            ProdeContext context)
        {
            this.jugadorNegocio = jugadorNegocio;
            _context = context;
        }
        #endregion
        

        // GET: Equipo/Partido
        public async Task<IActionResult> Index()
        {
            return View(await jugadorNegocio.BuscarPartido(null,null,null,null));
        }

        // GET: Equipo/Partido/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Partido = await jugadorNegocio.GetJugadorPorIdAsync(id.Value);

            if (Partido == null)
            {
                return NotFound();
            }

            return View(Partido);
        }

        // GET: Equipo/Partido/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Equipo/Partido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PartidoId,Apellido,Nombre")] Partido Partido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Partido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Partido);
        }

        // GET: Equipo/Partido/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Partido = await _context.Partido.SingleOrDefaultAsync(m => m.PartidoId == id);
            if (Partido == null)
            {
                return NotFound();
            }
            return View(Partido);
        }

        // POST: Equipo/Partido/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PartidoId,Apellido,Nombre")] Partido Partido)
        {
            if (id != Partido.PartidoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Partido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartidoExists(Partido.PartidoId))
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
            return View(Partido);
        }

        // GET: Equipo/Partido/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Partido = await _context.Partido
                .SingleOrDefaultAsync(m => m.PartidoId == id);
            if (Partido == null)
            {
                return NotFound();
            }

            return View(Partido);
        }

        // POST: Equipo/Partido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Partido = await _context.Partido.SingleOrDefaultAsync(m => m.PartidoId == id);
            _context.Partido.Remove(Partido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartidoExists(int id)
        {
            return _context.Partido.Any(e => e.PartidoId == id);
        }
    }
}
