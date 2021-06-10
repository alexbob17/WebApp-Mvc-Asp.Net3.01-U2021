using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using turnos.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace turnos.Controllers
{
    public class MedicoController : Controller
    {
        private readonly TurnosContext _context;

        public MedicoController(TurnosContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Medico.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Medico = await _context.Medico.FirstOrDefaultAsync(m => m.IdMedico == id);

            if (Medico == null)
            {
                return NotFound();
            }

            return View(Medico);
        }

        public IActionResult Create()
        {
            ViewData["ListaEspecialidades"] = new SelectList(_context.Especialidad, "IdEspecialidad", "Descripcion");
            return View();
        }

        //Modelo crear Medico
        [HttpPost]
        //Valida que el formulario no se acceda atraves de una url , Sino desde el formulario
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMedico,Nombre,Apellido,Direccion,Telefono,Email,HorarioAtencionDesde,HorarioAtencionHasta")] Medico medico, int IdEspecialidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medico);
                await _context.SaveChangesAsync();

                var medicoEspecialidad = new MedicoEspecialidad();
                medicoEspecialidad.IdMedico = medico.IdMedico;
                medicoEspecialidad.IdEspecialidad = IdEspecialidad;

                _context.Add(medicoEspecialidad);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(medico);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var medico = await _context.Medico.Where(m => m.IdMedico == id)
            .Include(me => me.MedicoEspecialidad).FirstOrDefaultAsync();

            if (medico == null)
            {
                return NotFound();
            }

        ViewData["ListaEspecialidades"] = new SelectList(
            _context.Especialidad, "IdEspecialidad","Descripcion", medico.MedicoEspecialidad[0].IdEspecialidad);
            
            return View(medico);
        }

        //Modelo crear Medico
        [HttpPost]
        //Valida que el formulario no se acceda atraves de una url , Sino desde el formulario
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMedico,Nombre,Apellido,Direccion,Telefono,Email,HorarioAtencionDesde,HorarioAtencionHasta")] Medico medico, int IdEspecialidad)
        {
            if (id != medico.IdMedico)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Update(medico);
                await _context.SaveChangesAsync();

                var medicoEspecialidad = await _context.MedicoEspecialidad
                .FirstOrDefaultAsync(me => me.IdMedico == id);

                _context.Remove(medicoEspecialidad);
                await _context.SaveChangesAsync();

                medicoEspecialidad.IdEspecialidad = IdEspecialidad;

                _context.Add(medicoEspecialidad);
                await _context.SaveChangesAsync();

                RedirectToAction(nameof(Index));
            }
            return View(medico);
        }

        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var medico = await _context.Medico.FirstOrDefaultAsync(m => m.IdMedico == id);
            if (medico == null)
            {
                return NotFound();
            }
            return View(medico);
        }

        //Modelo crear Medico
        [HttpPost, ActionName("Delete")]
        //Valida que el formulario no se acceda atraves de una url , Sino desde el formulario
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {

            var medicoEspecialidad = await _context.MedicoEspecialidad
            .FirstOrDefaultAsync(me => me.IdMedico ==id);

            _context.MedicoEspecialidad.Remove(medicoEspecialidad);
            await _context.SaveChangesAsync();

            if (id == null)
            {
                return NotFound();
            }
            var medico = await _context.Medico.FindAsync(id);
            if (medico == null)
            {
                return NotFound();
            }
            
            _context.Medico.Remove(medico);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}