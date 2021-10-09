using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YovyInventario.Models;

namespace YovyInventario.Pages
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Mensaje { get; set; } //Mensaje temporal para mostrar el error en el inicio de sesion
        private YovyDBContext _context { get; set; }
        public Usuario usuario { get; set; }
        public IndexModel(YovyDBContext context)
        {
            _context = context;
    
        }

        public void OnGet()
        {
            HttpContext.Session.SetInt32("_id", -1);//Inicia el ID en la sesion en-1
        }

        public ActionResult OnPost(string user, string password)
        {
            try
            {
                int pass = Convert.ToInt32(password);
                usuario = _context.Usuarios.Where(e => e.NUsuario == user).Where(e => e.Contrasena == pass).FirstOrDefault();//Busca el usuario en al DB
            } catch(Exception e)
            {
                Mensaje = "Contraseña invalida";
                return Page(); //Si la contraseña tiene caracteres retorna a la misma pagina
            }
            
            
            if (usuario!=null)
            {
                int id = usuario.IdUsuario;
                HttpContext.Session.SetInt32("_id",id);
                return RedirectToPage("/Empleado/Index1"); //Si el usuario es correcto pasa a la página index
            }
            else
            {
                Mensaje = "Usuario No encontrado";
                return Page();
            }
        }
    }
}
