using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace YovyInventario.Models
{
    public partial class Ventum
    {
        public int IdVenta { get; set; }
        [Required]
        public int Fkvendedor { get; set; }
        [Required (ErrorMessage ="El campo Nombre Cliente es requerido")] [Display(Name ="Nombre Cliente")]
        public string NombreCliente { get; set; }
        public double PrecioTotal { get; set; }
        [Required]
        public int Fkproducto { get; set; }
        [Required (ErrorMessage ="El capo Cantidad es reuqerido")] [Display(Name ="Cantidad")]
        public int Cantidad { get; set; }
        [DataType(DataType.Date)] [Display(Name ="Fecha")]
        public DateTime Fecha { get; set; }

        public virtual Producto FkproductoNavigation { get; set; }
        public virtual Usuario FkvendedorNavigation { get; set; }
    }
}
