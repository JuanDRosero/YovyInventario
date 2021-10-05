﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YovyInventario.Models;

namespace YovyInventario.Pages
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Mensaje { get; set; }
        private YovyDBContext _context { get; set; }
        public Usuario usuario { get; set; }
        public IndexModel(YovyDBContext context)
        {
            _context = context;
    
        }

        public void OnGet()
        {

        }

        public ActionResult OnPost(string user, string password)
        {
          
            usuario = _context.Usuarios.Where(e => e.NUsuario == user).Where(e =>e.Contrasena==Convert.ToInt32(password)).FirstOrDefault();
            
            if (usuario!=null)
            {
                int id = usuario.IdUsuario;
                HttpContext.Session.SetInt32("_id",id);
                return RedirectToPage("/Empleado/Index");
            }
            else
            {
                Mensaje = "Usuario No encontrado";
                return Page();
            }
        }
    }
}