using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThakyCompany.Models;

namespace ThakyCompany.Controllers
{
    public class ProductController : Controller
    {
        private ThakyCompany.Models.ThakyContext database = new Models.ThakyContext();

        private List<ProductDto> GetProductList()
        {
            List<ProductDto> productList = new List<ProductDto>();
            if (Request.Cookies["language"] != null && Request.Cookies["language"].Value == "vi")
            {
                foreach (var item in database.Products.Where(x => x.Actived == true))
                {
                    productList.Add(new ProductDto() { ID = item.ID, Title = item.ViTitle, Detail = item.ViDetail, Image = item.Image });
                }
            }
            else
            {
                foreach (var item in database.Products.Where(x => x.Actived == true))
                {
                    productList.Add(new ProductDto() { ID = item.ID, Title = item.EnTitle, Detail = item.EnDetail, Image = item.Image });
                }
            }

            return productList;
        }

        public ActionResult LoadProductList()
        {
            List<ProductDto> productList = GetProductList();
            return PartialView("_ProductMenu", productList);
        }

        //
        // GET: /Product/
        public ActionResult Index()
        {
            List<ProductDto> productList = GetProductList();
            return View(productList);
        }

        public ActionResult Detail(int id)
        {
            Product product = database.Products.Where(x => x.ID == id).Select(x => x).FirstOrDefault();
            ProductDto detailProduct;
            if (Request.Cookies["language"] != null && Request.Cookies["language"].Value == "vi")
            {
                detailProduct = new ProductDto() { ID = product.ID, Title = product.ViTitle, Detail = product.ViDetail, Image = product.Image };
            }
            else
            {
                detailProduct = new ProductDto() { ID = product.ID, Title = product.EnTitle, Detail = product.EnDetail, Image = product.Image };
            }
            return View(detailProduct);
        }
    }
}