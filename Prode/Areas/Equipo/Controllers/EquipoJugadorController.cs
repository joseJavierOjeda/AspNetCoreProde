using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Prode.Areas.Equipo.Controllers
{
    [Area("Equipo")]
    public class EquipoJugadorController : Controller
    {
        private readonly ProdeContext _context;

        public EquipoJugadorController(ProdeContext context)
        {
            _context = context;
        }

        // GET: EquipoJugador/EquipoJugador
        public async Task<IActionResult> Index()
        {
            var prodeContext = _context.EquipoJugador.Include(e => e.Equipo).Include(e => e.Jugador);
            return View(await prodeContext.ToListAsync());
        }

        // GET: EquipoJugador/EquipoJugador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipoJugador = await _context.EquipoJugador
                .Include(e => e.Equipo)
                .Include(e => e.Jugador)
                .SingleOrDefaultAsync(m => m.EquipoJugadorId == id);
            if (equipoJugador == null)
            {
                return NotFound();
            }

            return View(equipoJugador);
        }

        // GET: EquipoJugador/EquipoJugador/Create
        public IActionResult Create()
        {
            ViewData["EquipoId"] = new SelectList(_context.Equipo, "EquipoId", "Codigo");
            ViewData["JugadorId"] = new SelectList(_context.Jugador, "JugadorId", "Apellido");
            return View();
        }

        // POST: EquipoJugador/EquipoJugador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EquipoJugadorId,EquipoId,JugadorId,FechaVigenciaDesde,FechaVigenciaHasta")] EquipoJugador equipoJugador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipoJugador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipoId"] = new SelectList(_context.Equipo, "EquipoId", "Codigo", equipoJugador.EquipoId);
            ViewData["JugadorId"] = new SelectList(_context.Jugador, "JugadorId", "Apellido", equipoJugador.JugadorId);
            return View(equipoJugador);
        }

        // GET: EquipoJugador/EquipoJugador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipoJugador = await _context.EquipoJugador.SingleOrDefaultAsync(m => m.EquipoJugadorId == id);
            if (equipoJugador == null)
            {
                return NotFound();
            }
            ViewData["EquipoId"] = new SelectList(_context.Equipo, "EquipoId", "Codigo", equipoJugador.EquipoId);
            ViewData["JugadorId"] = new SelectList(_context.Jugador, "JugadorId", "Apellido", equipoJugador.JugadorId);
            return View(equipoJugador);
        }

        // POST: EquipoJugador/EquipoJugador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EquipoJugadorId,EquipoId,JugadorId,FechaVigenciaDesde,FechaVigenciaHasta")] EquipoJugador equipoJugador)
        {
            if (id != equipoJugador.EquipoJugadorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipoJugador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipoJugadorExists(equipoJugador.EquipoJugadorId))
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
            ViewData["EquipoId"] = new SelectList(_context.Equipo, "EquipoId", "Codigo", equipoJugador.EquipoId);
            ViewData["JugadorId"] = new SelectList(_context.Jugador, "JugadorId", "Apellido", equipoJugador.JugadorId);
            return View(equipoJugador);
        }

        // GET: EquipoJugador/EquipoJugador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipoJugador = await _context.EquipoJugador
                .Include(e => e.Equipo)
                .Include(e => e.Jugador)
                .SingleOrDefaultAsync(m => m.EquipoJugadorId == id);
            if (equipoJugador == null)
            {
                return NotFound();
            }

            return View(equipoJugador);
        }

        // POST: EquipoJugador/EquipoJugador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipoJugador = await _context.EquipoJugador.SingleOrDefaultAsync(m => m.EquipoJugadorId == id);
            _context.EquipoJugador.Remove(equipoJugador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipoJugadorExists(int id)
        {
            return _context.EquipoJugador.Any(e => e.EquipoJugadorId == id);
        }
    }
}
