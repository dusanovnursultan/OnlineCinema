using Newtonsoft.Json;
using OnlineCinema.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCinema.Models
{
    public class TicketModels
    {
        [JsonProperty("IdTicket")]
        public int IdTicket { get; set; }
        [JsonProperty("Status")]
        public bool Status { get; set; }
        [JsonProperty("Row")]
        public string Row { get; set; }
        [JsonProperty("Col")]
        public string Col { get; set; }
        public TicketModels()
        {

        }

        public TicketModels(Tickets ticket)
        {
            this.Col = ticket.Col;
            this.IdTicket = ticket.IdTicket;
            this.Row = ticket.Row;
            this.Status = ticket.Status;
        }
    }
}