using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarnetEmprendedor.Data
{
    public class Usuario
    {

        [Required]
        public int Id { get; set; }

        [Display(Name = "Matrícula")]
        public string Matricula { get; set; }

        [Display(Name = "Nombre completo")]
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }

        [NotMapped]
        public string NombreCompleto { get { return Nombre + " " + ApellidoP + " " + ApellidoM; } }

        [Display(Name = "Carrera")]
        public int MateriaId { get; set; }

        [ForeignKey("MateriaId")]
        public virtual Materia Materia { get; set; }

        [Display(Name = "Semestre")]
        public string Semestre { get; set; }
        public enum ESemestre { Primero = 0, Segundo = 1, Tercero = 2, Cuarto = 3, Quinto = 4, Sexto = 5, Septimo = 6, Octavo = 7, Noveno = 8 }

        public int Puntos { get; set; }
    }
}
