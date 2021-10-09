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
    public class IndexModel : PageModel
    {
        //Declaración de propiedades que usa la página
        public  YovyDBContext _contex { get; set; }
        [BindProperty]
        public IEnumerable<Inventario> inventario { get; set; }
        [BindProperty]
        public IEnumerable<Ventum> ventas { get; set; }
        [BindProperty]
        public IEnumerable<Producto> productos { get; set; }
        [BindProperty]
        public DateTime FechaInv{ get; set; }
        [BindProperty]
        public DateTime FechaVenta { get; set; }
        public IndexModel(YovyDBContext contex)
        {
            _contex = contex;
            productos = _contex.Productos.ToList();
           
        }
        public ActionResult OnGet() //Peticion Get que muestra todos los registros
        {
            if (HttpContext.Session.GetInt32("_id") != -1)
            {
                int id = (int)HttpContext.Session.GetInt32("_id");
                inventario = _contex.Inventarios.ToList().Where(e => e.Fkusuario == id);
                ventas = _contex.Venta.ToList().Where(e => e.Fkvendedor == id);
                return Page();
            }
            else
            {
                return RedirectToPage("/Index");
            }
            
        }
        public void OnPostBuscarInv() //Petición Post para el Handler BuscarInv
        {
            int id = (int)HttpContext.Session.GetInt32("_id");
            productos = _contex.Productos.ToList();
            inventario = _contex.Inventarios.ToList().Where(e => e.Fkusuario == id).Where(e=>e.Fecha==FechaInv);
        }
    public void OnPostBuscarVenta()//Petición Post para el Handler BuscarVenta
        {
            int id = (int)HttpContext.Session.GetInt32("_id");
            productos = _contex.Productos.ToList();
            ventas = _contex.Venta.ToList().Where(e => e.Fkvendedor == id).Where(e => e.Fecha == FechaVenta);
        }
    }
}
