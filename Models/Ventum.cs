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
        [Required(ErrorMessage = "El Campo Nombre Cliente es requerido")] [Display(Name ="Nombre Cliente")]
        public string NombreCliente { get; set; }
        public double PrecioTotal { get; set; }
        [Required]
        public int Fkproducto { get; set; }
        [Required(ErrorMessage = "El Campo Nombre Cantidad es requerido")] [Display(Name ="Cantidad")]
        public int Cantidad { get; set; }
        [DataType(DataType.Date)] [Required (ErrorMessage = "El Campo Fecha es requerido")]
        public DateTime Fecha { get; set; }

        public virtual Producto FkproductoNavigation { get; set; }
        public virtual Usuario FkvendedorNavigation { get; set; }
    }
}
