using CarnetEmprendedor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarnetEmprendedor.Pages.ViewModel
{
    public class EventoViewModel
    {
        public Evento Evento { get; set; }
        public IEnumerable<Categoria> Categoria { get; set; }
    }
}
