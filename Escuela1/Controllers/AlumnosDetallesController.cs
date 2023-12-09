using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Escuela1.Models;

namespace Escuela1.Controllers
{
    public class AlumnosDetallesController : Controller
    {
        private readonly SchoolDbContext _context;

        public AlumnosDetallesController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: AlumnosDetalles
        public async Task<IActionResult> Index()
        {
            var schoolDbContext = _context.AlumnosDetalles.Include(a => a.IdAlumnoNavigation).Include(a => a.IdMateriaNavigation);
            return View(await schoolDbContext.ToListAsync());
        }

        // GET: AlumnosDetalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumnosDetalle = await _context.AlumnosDetalles
                .Include(a => a.IdAlumnoNavigation)
                .Include(a => a.IdMateriaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alumnosDetalle == null)
            {
                return NotFound();
            }

            return View(alumnosDetalle);
        }

        // GET: AlumnosDetalles/Create
        public IActionResult Create()
        {
            
            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "IdAlumno", "Nombre");
            ViewData["IdMateria"] = new SelectList(_context.Materias, "IdMateria", "Nombre");
            return View();
        }

        // POST: AlumnosDetalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdAlumno,IdMateria,Calificacion")] AlumnosDetalle alumnosDetalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alumnosDetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "IdAlumno", "Nombre");
            ViewData["IdMateria"] = new SelectList(_context.Materias, "IdMateria", "Nombre", alumnosDetalle.IdMateria);
            return View(alumnosDetalle);
        }

        // GET: AlumnosDetalles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumnosDetalle = await _context.AlumnosDetalles.FindAsync(id);
            if (alumnosDetalle == null)
            {
                return NotFound();
            }
            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "IdAlumno", "IdAlumno",alumnosDetalle.IdAlumno);
            ViewData["IdMateria"] = new SelectList(_context.Materias, "IdMateria", "IdMateria", alumnosDetalle.IdMateria);
            return View(alumnosDetalle); 
        }

        // POST: AlumnosDetalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdAlumno,IdMateria,Calificacion")] AlumnosDetalle alumnosDetalle)
        {
            if (id != alumnosDetalle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumnosDetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlumnosDetalleExists(alumnosDetalle.Id))
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
            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "IdAlumno", "Nombre", alumnosDetalle.IdAlumno);
            ViewData["IdMateria"] = new SelectList(_context.Materias, "IdMateria", "IdMateria", alumnosDetalle.IdMateria);
            
            return View(alumnosDetalle);
        }

        // GET: AlumnosDetalles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumnosDetalle = await _context.AlumnosDetalles
                .Include(a => a.IdAlumnoNavigation)
                .Include(a => a.IdMateriaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alumnosDetalle == null)
            {
                return NotFound();
            }

            return View(alumnosDetalle);
        }

        // POST: AlumnosDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alumnosDetalle = await _context.AlumnosDetalles.FindAsync(id);
            if (alumnosDetalle != null)
            {
                _context.AlumnosDetalles.Remove(alumnosDetalle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlumnosDetalleExists(int id)
        {
            return _context.AlumnosDetalles.Any(e => e.Id == id);
        }
    }
}
