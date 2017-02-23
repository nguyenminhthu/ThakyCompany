using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ThakyCompany.Models;

namespace ThakyCompany.Controllers
{
    public class ProductController : Controller
    {
        private ThakyCompany.Models.ThakyContext database = new Models.ThakyContext();

        private List<ProductDto> GetProductList(int? productCategoryID)
        {
            if (productCategoryID == null)
            {
                productCategoryID = 1;
            }
            List<ProductDto> productList = new List<ProductDto>();
            var category = database.ProductCategory.Where(x => x.ID == productCategoryID).FirstOrDefault();
            if (Request.Cookies["language"] != null && Request.Cookies["language"].Value == "vi")
            {
                foreach (var item in database.Products.Where(x => x.Actived == true && x.Category.ID == productCategoryID))
                {
                    
                    ProductDto newProduct = new ProductDto()
                    {
                        ID = item.ID,
                        Title = item.ViTitle,
                        Detail = item.ViDetail,
                        Image = item.Image,
                        Price = item.Price,
                        Category = new ProductCategoryDto() { ID = category.ID, Title = category.ViTitle }
                    };
                    productList.Add(newProduct);
                }
            }
            else
            {
                foreach (var item in database.Products.Where(x => x.Actived == true))
                {
                    productList.Add(new ProductDto()
                    {
                        ID = item.ID,
                        Title = item.EnTitle,
                        Detail = item.EnDetail,
                        Image = item.Image,
                        Price = item.Price,
                        Category = new ProductCategoryDto() { ID = category.ID, Title = category.EnTitle }
                    });
                }
            }

            return productList;
        }

        public ActionResult LoadProductList()
        {
            int? productCategoryID;
            if (Session["productCategoryID"] == null)
            {
                productCategoryID = 1;
            }
            else
            {
                productCategoryID = int.Parse(Session["productCategoryID"].ToString());
            }
            List<ProductDto> productList = GetProductList(productCategoryID);
            return PartialView("_ProductMenu", productList);
        }

        //
        // GET: /Product/
        public ActionResult Index(int? id)
        {
            Session["productCategoryID"] = id;
            List<ProductDto> productList = GetProductList(id);
            return View(productList);
        }

        public ActionResult Detail(int id)
        {
            Product product = database.Products.Where(x => x.ID == id).Select(x => x).FirstOrDefault();
            ProductDto detailProduct;
            if (Request.Cookies["language"] != null && Request.Cookies["language"].Value == "vi")
            {
                detailProduct = new ProductDto() { ID = product.ID, Title = product.ViTitle, Detail = product.ViDetail, Image = product.Image, Price = product.Price };
            }
            else
            {
                detailProduct = new ProductDto() { ID = product.ID, Title = product.EnTitle, Detail = product.EnDetail, Image = product.Image, Price = product.Price };
            }
            return View(detailProduct);
        }
    }
}