using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThakyCompany.Models
{
    public class BaseModel
    {
        public int ID { get; set; }

        public string EnTitle { get; set; }

        public string EnDetail { get; set; }

        public string ViTitle { get; set; }

        public string ViDetail { get; set; }
    }
}