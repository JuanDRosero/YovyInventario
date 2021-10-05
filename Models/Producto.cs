using System;
using System.Collections.Generic;

#nullable disable

namespace YovyInventario.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Inventarios = new HashSet<Inventario>();
            Venta = new HashSet<Ventum>();
        }

        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public double PrecioVenta { get; set; }

        public virtual ICollection<Inventario> Inventarios { get; set; }
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
