using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplicationNumbers
{
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Session_Start(Object sender, EventArgs e)
        {
            Session["dummy"] = 0;
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
