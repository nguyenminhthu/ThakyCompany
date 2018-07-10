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
            var quyTrinh = database.QuyTrinhs.FirstOrDefault();
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
            var QuyTrinh = database.QuyTrinhs.Where(x => x.ID == id).Select(x => x).FirstOrDefault();

            QuyTrinhDto dtoQuyTrinhDetail = new QuyTrinhDto();

            if (Request.Cookies["language"] != null && Request.Cookies["language"].Value == "vi")
            {
                dtoQuyTrinhDetail.Title = QuyTrinh.ViTitle;
                dtoQuyTrinhDetail.Detail = QuyTrinh.ViDetail;
            }
            else
            {
                dtoQuyTrinhDetail.Title = QuyTrinh.EnTitle;
                dtoQuyTrinhDetail.Detail = QuyTrinh.EnDetail;
            }

            return View(dtoQuyTrinhDetail);
        }
    }
}