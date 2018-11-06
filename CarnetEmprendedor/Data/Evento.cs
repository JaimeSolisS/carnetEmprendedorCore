using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarnetEmprendedor.Data
{
    public class Evento
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "Categoría del evento")]
        public int CategoriaEventoId { get; set; }

        [ForeignKey("CategoriaEventoId")]
        public virtual Categoria Categoria { get; set; }

        [Required]
        [Display(Name = "Puntos del evento")]
        [Range(1,20,ErrorMessage ="La cantidad de puntos debe ser mayor a {1}")]
        public int PuntosEvento { get; set; }

        [Required]
        [Display(Name = "Nombre del evento")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Descripción del evento")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Inicio del evento")]
        public DateTime Inicio { get; set; }

        [Required]
        [Display(Name = "Fin del evento")]
        public DateTime Fin { get; set; }

        [Required]
        [Display(Name = "Lugar del evento")]
        public string Lugar { get; set; }

        [Display(Name = "Imagen del evento")]
        public string Imagen { get; set; }

        [Required]
        [Display(Name = "Número de boletos")]
        public int NumBoletos { get; set; }
    }
}
