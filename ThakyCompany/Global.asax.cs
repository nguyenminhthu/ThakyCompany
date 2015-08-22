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

            //Application["visitors_online"] = 0;
            //Application["today"] = 0;
            //Application["Date"] = DateTime.Now.Date;
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
            //try
            //{
            Session.Timeout = 1;
            Helper.VisitorHelper.CountVisitor();

            //Application.Lock();
            //if (DateTime.Parse(Application["Date"].ToString()).Date == DateTime.Now.Date)
            //{
            //    Application["visitors_online"] = Convert.ToInt32(Application["visitors_online"]) + 1;
            //    Application["today"] = Convert.ToInt32(Application["today"]) + 1;
            //}
            //else
            //{
            //    ThakyCompany.Helper.VisitorHelper.AddVisitorOnline(int.Parse(Application["today"].ToString()));
            //    Application["visitors_online"] = 1;
            //    Application["Date"] = DateTime.Now.Date;
            //    Application["today"] = 1;
            //}

            //Application.UnLock();
            //}
            //catch
            //{
            //    throw new MyException("Chuong trinh bi loi");
            //}
        }

        [Serializable]
        public class MyException : Exception
        {
            public MyException()
            {
            }

            public MyException(string message)
                : base(message)
            {
            }

            public MyException(string message, Exception inner)
                : base(message, inner)
            {
            }

            protected MyException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context)
                : base(info, context) { }
        }

        //protected void Application_Start()
        //{
        //    AreaRegistration.RegisterAllAreas();
        //    RegisterGlobalFilters(GlobalFilters.Filters);
        //    RegisterRoutes(RouteTable.Routes);
        //    BundleTable.Bundles.RegisterTemplateBundles();
        //    // Code that runs on application startup
        //    Application["HomNay"] = 0;
        //    Application["HomQua"] = 0;
        //    Application["TuanNay"] = 0;
        //    Application["TuanTruoc"] = 0;
        //    Application["ThangNay"] = 0;
        //    Application["ThangTruoc"] = 0;
        //    Application["TatCa"] = 0;
        //    Application["visitors_online"] = 0;
        //}

        //private void Session_Start(object sender, EventArgs e)
        //{
        //    Session.Timeout = 150;
        //    Application.Lock();
        //    Application["visitors_online"] = Convert.ToInt32(Application["visitors_online"]) + 1;
        //    Application.UnLock();
        //    try
        //    {
        //        DataBindSQL EGroupsThongKe = new DataBindSQL();
        //        System.Data.DataTable dtb = EGroupsThongKe.TableEGThongKe();
        //        if (dtb.Rows.Count > 0)
        //        {
        //            Application["HomNay"] = long.Parse("0" + dtb.Rows[0]["HomNay"]).ToString("#,###");
        //            Application["HomQua"] = long.Parse("0" + dtb.Rows[0]["HomQua"]).ToString("#,###");
        //            Application["TuanNay"] = long.Parse("0" + dtb.Rows[0]["TuanNay"]).ToString("#,###");
        //            Application["TuanTruoc"] = long.Parse("0" + dtb.Rows[0]["TuanTruoc"]).ToString("#,###");
        //            Application["ThangNay"] = long.Parse("0" + dtb.Rows[0]["ThangNay"]).ToString("#,###");
        //            Application["ThangTruoc"] = long.Parse("0" + dtb.Rows[0]["ThangTruoc"]).ToString("#,###");
        //            Application["TatCa"] = long.Parse("0" + dtb.Rows[0]["TatCa"]).ToString("#,###");
        //        }
        //        dtb.Dispose();
        //        EGroupsThongKe = null;
        //    }
        //    catch { }
        //}

        private void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["visitors_online"] = Convert.ToUInt32(Application["visitors_online"]) - 1;
            Application.UnLock();
        }
    }
}