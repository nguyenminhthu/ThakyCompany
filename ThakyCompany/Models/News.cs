using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ThakyCompany.Models
{
    public class News : BaseModel
    {
        public DateTime PostDate { get; set; }

        [Display(Name = "Hiển thị")]
        public bool Actived { get; set; }

        public string UserName { get; set; }
    }
}