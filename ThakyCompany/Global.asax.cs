using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ThakyCompany
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Visitor online
            Application["Today"] = 0;
            Application["Online"] = 0;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string culture = "vi";//ngon ngu mac dinh
            var httpCookie = Request.Cookies["language"];
            if (httpCookie != null)
            {
                culture = httpCookie.Value;
            }
            else
            {
                HttpCookie langage = new HttpCookie("language");
                langage.Value = culture;
                langage.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(langage);
            }

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;
        }

        private void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 15;
            Application.Lock();
            Application["Online"] = Convert.ToInt32(Application["Online"]) + 1;
            Application["Today"] = Convert.ToInt32(Application["Today"]) + 1;
            Application.UnLock();
        }

        private void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["Online"] = Convert.ToUInt32(Application["Online"]) - 1;
            Application.UnLock();
        }
    }
}