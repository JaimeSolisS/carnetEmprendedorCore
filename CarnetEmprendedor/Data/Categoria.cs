using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarnetEmprendedor.Data
{
    public class Categoria
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Categoría del evento")]
        public string CategoriaEvento { get; set; }

        [Required]
        [Display(Name = "Puntos del evento")]
        public int Puntos { get; set; }
    }
}
