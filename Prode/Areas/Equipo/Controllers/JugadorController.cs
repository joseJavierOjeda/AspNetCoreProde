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
    public class JugadorController : Controller
    {
        #region Atributos
        private readonly IJugadorNegocio jugadorNegocio;
        private readonly ProdeContext _context;
        #endregion

        #region Constructor
        public JugadorController(IJugadorNegocio jugadorNegocio,
            ProdeContext context)
        {
            this.jugadorNegocio = jugadorNegocio;
            _context = context;
        }
        #endregion
        

        // GET: Equipo/Jugador
        public async Task<IActionResult> Index()
        {
            return View(await jugadorNegocio.GetJugadoresAsync());
        }

        // GET: Equipo/Jugador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await jugadorNegocio.GetJugadorPorIdAsync(id.Value);

            if (jugador == null)
            {
                return NotFound();
            }

            return View(jugador);
        }

        // GET: Equipo/Jugador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Equipo/Jugador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JugadorId,Apellido,Nombre")] Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jugador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jugador);
        }

        // GET: Equipo/Jugador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugador.SingleOrDefaultAsync(m => m.JugadorId == id);
            if (jugador == null)
            {
                return NotFound();
            }
            return View(jugador);
        }

        // POST: Equipo/Jugador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JugadorId,Apellido,Nombre")] Jugador jugador)
        {
            if (id != jugador.JugadorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jugador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JugadorExists(jugador.JugadorId))
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
            return View(jugador);
        }

        // GET: Equipo/Jugador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugador
                .SingleOrDefaultAsync(m => m.JugadorId == id);
            if (jugador == null)
            {
                return NotFound();
            }

            return View(jugador);
        }

        // POST: Equipo/Jugador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jugador = await _context.Jugador.SingleOrDefaultAsync(m => m.JugadorId == id);
            _context.Jugador.Remove(jugador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JugadorExists(int id)
        {
            return _context.Jugador.Any(e => e.JugadorId == id);
        }
    }
}
