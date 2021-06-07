using System.Linq;
using Microsoft.AspNetCore.Mvc;
using turnos.Models;

namespace turnos.Controllers

{

    public class EspecialidadController : Controller
    {
        private readonly TurnosContext _context;
        public EspecialidadController(TurnosContext context)
        {

            _context = context;
        }

        public IActionResult Index()
        {
            // Devuelve la tabla de especialidad
            return View(_context.Especialidad.ToList());
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var especialidad = _context.Especialidad.Find(id);

            if (especialidad == null)
            {
                return NotFound();
            }

            return View(especialidad);
        }

        [HttpPost] //Este envia el edit
        public IActionResult Edit(int id, [Bind("IdEspecialidad, Descripcion")] Especialidad especialidad)
        {
            if (id != especialidad.IdEspecialidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(especialidad);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var especialidad = _context.Especialidad.FirstOrDefault(e => e.IdEspecialidad == id);
            
            return View(especialidad);
        }
    }
}