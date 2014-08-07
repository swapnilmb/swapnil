using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Owin.Logging;
using WebApplication1.Controllers;

namespace WebApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            System.Data.Entity.Database.SetInitializer(new WebApplication1.Models.SampleData());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //if (!Request.IsAuthenticated) Response.Redirect(
            //                                "Error.cshtml"); 
        }

      

        //void Application_EndRequest(object sender, System.EventArgs e)
        //{
            

        //    // If the user is not authorised to see this page or access this function, send them to the error page.
        //    //if (Response.StatusCode == 401)
        //    //{
        //    //    Response.ClearContent();
        //    //    Response.RedirectToRoute("ErrorHandler", (RouteTable.Routes["ErrorHandler"] as Route).Defaults);
        //    //}
        //    //Exception exectionObject = Server.GetLastError();
        //    //Application[HttpContext.Current.Request.UserHostAddress.ToString()] = exectionObject;
        //}
        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    var ex = Server.GetLastError().GetBaseException();

        //    var routeData = new RouteData();

        //    if (ex.GetType() == typeof(HttpException))
        //    {
        //        var httpException = (HttpException)ex;

        //        switch (httpException.GetHttpCode())
        //        {
        //            case 401:
        //                routeData.Values.Add("action", "Unauthorised");
        //                break;
        //            case 403:
        //                routeData.Values.Add("Login", "Auth");
        //                break;
        //            case 404:
        //                routeData.Values.Add("action", "PageNotFound");
        //                break;
        //            default:
        //                routeData.Values.Add("action", "GeneralError");
        //                break;
        //        }
        //    }
        //    else
        //    {
        //        routeData.Values.Add("action", "GeneralError");
        //    }

        //    routeData.Values.Add("controller", "Error");
        //    routeData.Values.Add("error", ex);
        //    Response.TrySkipIisCustomErrors = true;
        //    IController errorController = new ErrorController();
        //    errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
        //}

        //protected void Application_EndRequest(Object sender, EventArgs e)
        //{
        //    HttpContext context = HttpContext.Current;
        //    if (context.Response.StatusCode.Equals(401))
        //    {//context.Response.Flush();
        //        // context.Response.ClearHeaders();
        //        context.Response.ClearContent();
        //        context.Response.Redirect("http://localhost:1938/Error/ee");

        //    }
        //}
        //protected void Application_EndRequest(object sender, EventArgs e)
        //{
        //    if (Context.Response.StatusCode == 401)
        //    {
        //        throw new HttpException(401, "You are not authorised");
        //    }
        //}
        //protected void Application_EndRequest()
        //{
        //    if (Context.Response.StatusCode == 302 && Context.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        //    {
        //        Context.Response.Clear();
        //        Context.Response.StatusCode = 401;
        //    }
        //}
        //protected void Application_EndRequest()
        //{
        //    if (Context.Response.StatusCode == 302 && Context.Request.RequestContext.HttpContext.Request.IsAjaxRequest())
        //    {
        //        Context.Response.Clear();
        //        Context.Response.StatusCode = 401;
        //    }
        //}
    }
}
