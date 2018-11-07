using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarnetEmprendedor.Data
{
    public class ListaAsistencia
    {
       [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Matrícula")]
        public int Matricula  { get; set; }
        [Required]
        public string Tag { get; set; }

        public int EventoId { get; set; }

        [ForeignKey("EventoId")]
        public virtual Evento Evento { get; set; }

    }
}
