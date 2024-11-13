﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vapers_Club.Models.ViewModels
{
    public class cActualizarEntrega
    {
        public int id { set; get; }
        [Required]
        [Display(Name = "Fecha de solicitud | Formato: YYYY-MM-DD HH-MM-SS")]
        public DateTime fecha { set; get; }
        [Required]
        [Display(Name = "Producto")]
        public string idp { set; get; }
        [Required]
        [Display(Name = "Cantidad")]
        public int cantidad { set; get; }
        [Required]
        [Display(Name = "Estado")]
        public int estado { set; get; }
    }
}