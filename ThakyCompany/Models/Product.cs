using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ThakyCompany.Models
{
    public class Product : BaseModel
    {
        public string Image { get; set; }

        public DateTime PostDate { get; set; }

        public bool Actived { get; set; }

        public string Price { get; set; }

        [ForeignKey("ID")]
        public virtual ProductCategory Category { get; set; }
    }
}