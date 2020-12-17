using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTQLWEB3.Areas.Admin.Controllers
{
    //kế thử base controller để nếu chưa login thì trả về trang login
    public class TrangChuController : BaseController
    {
        // GET: Admin/TrangChu
        public ActionResult Index()
        {
            return View();
        }
    }
}