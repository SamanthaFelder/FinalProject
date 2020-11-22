using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FinalProject
{
    class ShowTime
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int MovieId { get; set; }
        public string RoomCode { get; set; }
        public double TicketPrice { get; set; }

        public ShowTime()
        {

        }
    }
}
