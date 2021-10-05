﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace YovyInventario.Models
{
    public partial class Inventario
    {
        public int IdInventario { get; set; }
        [Required]
        public int Fkusuario { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public int Fkproducto { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        public virtual Producto FkproductoNavigation { get; set; }
        public virtual Usuario FkusuarioNavigation { get; set; }
    }
}