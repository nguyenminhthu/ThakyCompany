using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThakyCompany.Models;

namespace ThakyCompany.Controllers
{
    public class NewsController : Controller
    {
        private ThakyCompany.Models.ThakyContext database = new Models.ThakyContext();

        public ActionResult LoadNews()
        {
            List<NewsDto> newsList = new List<NewsDto>();
            if (Request.Cookies["language"] != null && Request.Cookies["language"].Value == "vi")
            {
                foreach (var item in database.News.Where(x => x.Actived == true).OrderByDescending(x => x.PostDate))
                {
                    newsList.Add(new NewsDto() { ID = item.ID, Title = item.ViTitle, Detail = item.ViDetail });
                }
            }
            else
            {
                foreach (var item in database.News.Where(x => x.Actived == true).OrderByDescending(x => x.PostDate))
                {
                    newsList.Add(new NewsDto() { ID = item.ID, Title = item.EnTitle, Detail = item.EnDetail });
                }
            }
            return PartialView("_NewsMenu", newsList);
        }

        public ActionResult Detail(int id)
        {
            var news = database.News.Where(x => x.ID == id && x.Actived).Select(x => x).FirstOrDefault();

            NewsDto dtoNewsDetail = new NewsDto();
            if (news != null)
            {
                if (Request.Cookies["language"] != null && Request.Cookies["language"].Value == "vi")
                {
                    dtoNewsDetail.Title = news.ViTitle;
                    dtoNewsDetail.Detail = news.ViDetail;
                }
                else
                {
                    dtoNewsDetail.Title = news.EnTitle;
                    dtoNewsDetail.Detail = news.EnDetail;
                }
            }
            return View(dtoNewsDetail);
        }
    }
}