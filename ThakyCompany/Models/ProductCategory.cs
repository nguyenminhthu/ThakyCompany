﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ThakyCompany.Models
{
    public class ProductCategory
    {
        public int ID { get; set; }

        [Display(Name = "Tiêu đề")]
        public string EnTitle { get; set; }

        [Display(Name = "Tiêu đề")]
        public string ViTitle { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
    }
}