using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using turnos.Models;

namespace turnos.Controllers
{
    public class PacienteController : Controller
    {
        private readonly TurnosContext _context;

        public PacienteController(TurnosContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Paciente.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Paciente = await _context.Paciente.FirstOrDefaultAsync(p => p.IdPaciente == id);

            if (Paciente == null)
            {
                return NotFound();
            }

            return View(Paciente);
        }

        public IActionResult Create()
        {
            return View();
        }

        //Modelo crear Paciente
        [HttpPost]
        //Valida que el formulario no se acceda atraves de una url , Sino desde el formulario
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPaciente,Nombre,Apellido,Direccion,Telefono,Email")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}