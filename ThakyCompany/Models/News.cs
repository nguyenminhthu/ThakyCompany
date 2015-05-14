using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThakyCompany.Models
{
    public class News : BaseModel
    {
        public DateTime PostDate { get; set; }

        public bool Actived { get; set; }

        public string UserName { get; set; }
    }
}