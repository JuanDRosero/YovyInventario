using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace YovyInventario.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Inventarios = new HashSet<Inventario>();
            Venta = new HashSet<Ventum>();
        }
        public int IdUsuario { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string NUsuario { get; set; }
        [Required]
        public int Contrasena { get; set; }

        public virtual ICollection<Inventario> Inventarios { get; set; }
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
