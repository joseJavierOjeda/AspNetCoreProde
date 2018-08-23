using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Negocio.Interface.Equipo;
using Prode.Models;

namespace Prode.Areas.Equipo.Controllers
{
    [Area("Equipo")]
    [ResponseCache(Duration =60)]
    public class PartidoController : Controller
    {
        #region Atributos
        private readonly IPartidoNegocio partidoNegocio;
        private readonly ProdeContext _context;
        private readonly IMemoryCache memoryCache;
        #endregion

        #region Constructor
        public PartidoController(IPartidoNegocio partidoNegocio,
            ProdeContext context,
            IMemoryCache memoryCache)
        {
            this.partidoNegocio = partidoNegocio;
            _context = context;
            this.memoryCache = memoryCache;
        }
        #endregion
        
        // GET: Equipo/Partido
        public async Task<IActionResult> Index()
        {
            var torneo = memoryCache.GetOrCreate("TorneoSelecter", e => {

                Torneo torneoDefault = new Torneo {
                    TorneoId = 1,
                    Descripcion = "Libertadores"
                };

                return torneoDefault;
            });

            ViewBag.Torneo = torneo;

            return View(await partidoNegocio.BuscarPartido(null,null,null,null));
        }

        // GET: Equipo/Partido/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var Partido = await partidoNegocio.GetJugadorPorIdAsync(id.Value);

            var partido = new Partido();

            if (partido == null)
            {
                return NotFound();
            }

            return View(partido);
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
