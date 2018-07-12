using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThakyCompany.Models;

namespace ThakyCompany.Controllers
{
    public class QuyTrinhController : Controller
    {
        private ThakyCompany.Models.ThakyContext database = new Models.ThakyContext();

        public ActionResult Index()
        {
            var quyTrinh = database.QuyTrinhs.Where(x=>x.Actived).FirstOrDefault();
            return RedirectToAction("Detail", new { id = quyTrinh.ID });
        }
        public ActionResult LoadQuyTrinh()
        {
            List<QuyTrinhDto> QuyTrinhList = new List<QuyTrinhDto>();
            if (Request.Cookies["language"] != null && Request.Cookies["language"].Value == "vi")
            {
                foreach (var item in database.QuyTrinhs.Where(x => x.Actived == true).OrderByDescending(x => x.PostDate))
                {
                    QuyTrinhList.Add(new QuyTrinhDto() { ID = item.ID, Title = item.ViTitle, Detail = item.ViDetail });
                }
            }
            else
            {
                foreach (var item in database.QuyTrinhs.Where(x => x.Actived == true).OrderByDescending(x => x.PostDate))
                {
                    QuyTrinhList.Add(new QuyTrinhDto() { ID = item.ID, Title = item.EnTitle, Detail = item.EnDetail });
                }
            }
            return PartialView("_QuyTrinhMenu", QuyTrinhList);
        }

        public ActionResult Detail(int id)
        {
            var quyTrinh = database.QuyTrinhs.Where(x => x.ID == id && x.Actived).Select(x => x).FirstOrDefault();

            QuyTrinhDto dtoQuyTrinhDetail = new QuyTrinhDto();
            if (quyTrinh != null)
            {
                if (Request.Cookies["language"] != null && Request.Cookies["language"].Value == "vi")
                {
                    dtoQuyTrinhDetail.Title = quyTrinh.ViTitle;
                    dtoQuyTrinhDetail.Detail = quyTrinh.ViDetail;
                }
                else
                {
                    dtoQuyTrinhDetail.Title = quyTrinh.EnTitle;
                    dtoQuyTrinhDetail.Detail = quyTrinh.EnDetail;
                }
            }
            return View(dtoQuyTrinhDetail);
        }
    }
}