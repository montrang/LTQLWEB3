using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTQLWEB3.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        //Kiểm tra nếu chưa login thì trở về trang login
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (Session["MaTK"].ToString() == "")
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(new { area = "Admin", Controller = "QuanLy", Action = "Login"})
                    ); ;
            base.OnActionExecuted(filterContext);
        }
    }
}