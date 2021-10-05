using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using YovyInventario.Models;

namespace YovyInventario.Pages.Empleado
{
    public class RegistrarInventarioModel : PageModel
    {
        private YovyDBContext _context { get; set; }
        [BindProperty]
        public Inventario inventario { get; set; }
        [BindProperty]
        public IEnumerable<Producto> productos{ get; set; }
        public RegistrarInventarioModel(YovyDBContext context)
        {
            _context = context;
            
        }
        public void OnGet()
        {
            productos = _context.Productos.ToList();
        }
        public async Task<ActionResult> OnPost()
        {
            if (!ModelState.IsValid)    //Verifica que el modelo enviado sea valido.. si no lo es, se retorna  al amisma página
            {
                return Page();
            }
            int id = (int)HttpContext.Session.GetInt32("_id"); ;
            inventario.Fkusuario = id;
            _context.Add(inventario);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index"); //Una vez que se guarda en la base de datos, se redirige a la pagina index
        }
    }
}
