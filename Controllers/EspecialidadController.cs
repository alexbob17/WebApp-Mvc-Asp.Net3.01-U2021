using System.Linq;
using Microsoft.AspNetCore.Mvc;
using turnos.Models;

namespace turnos.Controllers

{

    public class EspecialidadController : Controller
    {
        private readonly TurnosContext _context;
        public EspecialidadController(TurnosContext context){

            _context = context;
        }

        public IActionResult Index()
        {
            // Devuelve la tabla de especialidad
            return View(_context.Especialidad.ToList());
        }
    }
}