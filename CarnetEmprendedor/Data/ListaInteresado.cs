using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarnetEmprendedor.Data
{
    public class ListaInteresado
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Matrícula")]
        public int Matricula { get; set; }
       
        public int EventoId { get; set; }

        [ForeignKey("EventoId")]
        public virtual Evento Evento { get; set; }
    }
}
