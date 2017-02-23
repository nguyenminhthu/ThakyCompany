using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ThakyCompany.Models
{
    public class ProcedureCategory
    {
        public int ID { get; set; }

        [Display(Name = "Tiêu đề")]
        public string EnTitle { get; set; }

        [Display(Name = "Tiêu đề")]
        public string ViTitle { get; set; }
        public bool Actived { get; set; }
        public virtual ICollection<Procedure> Products { get; set; }
    }
}