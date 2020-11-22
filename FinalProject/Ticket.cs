using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Ticket
    {
        public int Id { get; set; }
        public DateTime Purchase_date_time { get; set; }
        public int ShowTimeId { get; set; }
        public int UserId { get; set; }

        public Ticket()
        {

        }
    }
}
