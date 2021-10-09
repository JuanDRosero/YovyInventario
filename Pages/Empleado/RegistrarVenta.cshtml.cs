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
        //Propiedades que utiliza la página
        private YovyDBContext _context { get; set; }
        [BindProperty]
        public Ventum venta { get; set; }
        [BindProperty]
        public IEnumerable<Producto> productos { get; set; }
        public RegistrarVentaModel(YovyDBContext contex)
        {
            _context = contex;
            productos = _context.Productos.ToList();

        }
        public void OnGet()
        {
            
        }
        public async Task<ActionResult> OnPost() //Petición Post asincronica
        {
            if (!ModelState.IsValid)    //Verifica que el modelo enviado sea valido.. si no lo es, se retorna  al amisma página
            {
                productos = _context.Productos.ToList();
                return Page();
            }
            int id = (int)HttpContext.Session.GetInt32("_id"); ;
            venta.Fkvendedor = id;
            var fkid = venta.Fkproducto;
            var producto = _context.Productos.Find(fkid);
            venta.PrecioTotal = producto.PrecioVenta * venta.Cantidad;
            _context.Add(venta);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index1"); //Una vez que se guarda en la base de datos, se redirige a la pagina index
        }
    }
}
