using Microsoft.AspNetCore.Mvc;
namespace turnos.Controllers

{

    public class EspecialidadController : Controller
    {
        public EspecialidadController(){

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}