using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThakyCompany.Models
{
    public class VisitorOnline
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public int Online { get; set; }
    }

    public class VisitorOnlineDto
    {
        public int Online { get; set; }

        public int Today { get; set; }

        public int Yesterday { get; set; }

        public int LastWeek { get; set; }

        public int LastMonth { get; set; }

        public int Total { get; set; }
    }
}