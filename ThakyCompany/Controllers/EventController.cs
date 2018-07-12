using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThakyCompany.Models;

namespace ThakyCompany.Controllers
{
    public class EventController : Controller
    {
        private ThakyCompany.Models.ThakyContext database = new Models.ThakyContext();

        public ActionResult Index()
        {
            var tempEvent = database.Events.Where(x=>x.Actived).FirstOrDefault();
            return RedirectToAction("Detail", new { id = tempEvent.ID });
        }
        public ActionResult LoadEvent()
        {
            List<EventDto> EventList = new List<EventDto>();
            if (Request.Cookies["language"] != null && Request.Cookies["language"].Value == "vi")
            {
                foreach (var item in database.Events.Where(x => x.Actived == true).OrderByDescending(x => x.PostDate))
                {
                    EventList.Add(new EventDto() { ID = item.ID, Title = item.ViTitle, Detail = item.ViDetail });
                }
            }
            else
            {
                foreach (var item in database.Events.Where(x => x.Actived == true).OrderByDescending(x => x.PostDate))
                {
                    EventList.Add(new EventDto() { ID = item.ID, Title = item.EnTitle, Detail = item.EnDetail });
                }
            }
            return PartialView("_EventMenu", EventList);
        }

        public ActionResult Detail(int id)
        {
            var tempEvent = database.Events.Where(x => x.ID == id && x.Actived).Select(x => x).FirstOrDefault();

            EventDto dtoEventDetail = new EventDto();
            if (tempEvent != null)
            {
                if (Request.Cookies["language"] != null && Request.Cookies["language"].Value == "vi")
                {
                    dtoEventDetail.Title = tempEvent.ViTitle;
                    dtoEventDetail.Detail = tempEvent.ViDetail;
                }
                else
                {
                    dtoEventDetail.Title = tempEvent.EnTitle;
                    dtoEventDetail.Detail = tempEvent.EnDetail;
                }
            }
            return View(dtoEventDetail);
        }
    }
}