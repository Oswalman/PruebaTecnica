using System;
using System.Collections.Generic;



namespace PruebaTecnica.Models
{
    public partial class Ticket
    {
        public int NoTicket { get; set; }
        public string Usuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public bool Estatus { get; set; }
    }
}
