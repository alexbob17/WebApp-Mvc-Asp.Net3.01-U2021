using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using turnos.Models;

namespace turnos.Controllers
{
    public class LoginController : Controller
    {
        private readonly TurnosContext _context;
        
        public LoginController(TurnosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login (Login login)
        {
            if(ModelState.IsValid){

                string passwordEncriptado = Encriptar(login.Password);
                var loginUsuario= _context.Login.Where(l => l.Usuario == login.Usuario && l.Password == passwordEncriptado)
                .FirstOrDefault();

                if(loginUsuario != null)
                {
                    HttpContext.Session.SetString("usuario",loginUsuario.Usuario);
                    return RedirectToAction("Index", "Home");
                }else{
                    ViewData["errorLogin"]="Los datos ingresados son incorrectos";
                    return View("Index");
                    
                }
            }
         return View("Index");
        }

        public string Encriptar(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder stringBuilder = new StringBuilder();

                for(int i=0; i< bytes.Length; i++)
                {
                    stringBuilder.Append(bytes[i].ToString("x2"));
                }

                return stringBuilder.ToString();
                
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }
    }
}