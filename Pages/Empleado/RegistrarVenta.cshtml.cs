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
    public class RegistrarVentaModel : PageModel
    {
        private YovyDBContext _context { get; set; }
        [BindProperty]
        public Ventum venta { get; set; }
        [BindProperty]
        public IEnumerable<Producto> productos { get; set; }
        public RegistrarVentaModel(YovyDBContext contex)
        {
            _context = contex;
            
        }
        public void OnGet()
        {
            productos = _context.Productos.ToList();
        }
        public async Task<ActionResult> OnPost()
        {
            if (!ModelState.IsValid)    //Verifica que el modelo enviado sea valido.. si no lo es, se retorna  al amisma p�gina
            {
                return Page();
            }
            int id = (int)HttpContext.Session.GetInt32("_id"); ;
            venta.Fkvendedor = id;
            var fkid = venta.Fkproducto;
            var producto = _context.Productos.Find(fkid);
            venta.PrecioTotal = producto.PrecioVenta * venta.Cantidad;
            _context.Add(venta);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index"); //Una vez que se guarda en la base de datos, se redirige a la pagina index
        }
    }
}