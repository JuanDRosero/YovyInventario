using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public  YovyDBContext _contex { get; set; }
        [BindProperty]
        public IEnumerable<Inventario> inventario { get; set; }
        [BindProperty]
        public IEnumerable<Ventum> ventas { get; set; }
        [BindProperty]
        public IEnumerable<Producto> productos { get; set; }
        [DataType(DataType.Date)][BindProperty]
        public DateTime fechaInv { get; set; }
        [DataType(DataType.Date)]
        [BindProperty]
        public DateTime fechaVentas { get; set; }
        public IndexModel(YovyDBContext contex)
        {
            _contex = contex;
            productos = _contex.Productos.ToList();
           
        }
        public ActionResult OnGet()
        {
           
            if (HttpContext.Session.GetInt32("_id") != -1)
            {
                int id = (int)HttpContext.Session.GetInt32("_id");
                //inventario = _contex.Inventarios.ToList().Where(e => e.Fkusuario == id);
                ventas = _contex.Venta.ToList().Where(e => e.Fkvendedor == id);
                return Page();
            }
            else
            {
                return RedirectToPage("/Index");
            }
            
            
        }
        public ActionResult OnPost()
        {
            int id = (int)HttpContext.Session.GetInt32("_id");
            if
            inventario = _contex.Inventarios.ToList().Where(e => e.Fkusuario == id).Where(e=>e.Fecha==fechaInv);
            return Page();
        }
    }
}
