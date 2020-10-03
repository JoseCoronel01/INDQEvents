using System;
using System.Collections.Generic;
using System.Text;

namespace ModeloClases
{
    public class ListadoEventos
    {
        public int page { get; set; }
        public int pages { get; set; }
        public List<Event> items { get; set; }
    }
}