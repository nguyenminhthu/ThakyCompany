using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThakyCompany.Models
{
    public class ProductDto
    {
        public int ID { get; set; }

        public string Image { get; set; }

        public string Title { get; set; }

        public string Detail { get; set; }

        public string Price { get; set; }

        public ProductCategoryDto Category { get; set; }
    }
}