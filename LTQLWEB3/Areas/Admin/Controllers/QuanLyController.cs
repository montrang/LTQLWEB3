using LTQLWEB3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LTQLWEB3.Areas.Admin.Controllers
{
    public class QuanLyController : Controller
    {
        DBConnect db = new DBConnect();
        // GET: Admin/QuanLy
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string MaTk, string Password)
        {
            if (ModelState.IsValid)
            {
                var ma_hoa_du_lieu = GETMD5(Password);
                var kiem_tra_tai_khoan = db.accounts.Where(s => s.MaTk.Equals(MaTk) && s.Password.Equals(ma_hoa_du_lieu)).ToList();
                if (kiem_tra_tai_khoan.Count() > 0)
                {
                    Session["MaTK"] = kiem_tra_tai_khoan.FirstOrDefault().MaTk;
                    Session["TenNV"] = kiem_tra_tai_khoan.FirstOrDefault().NHANVIEN.TenNV;
                    return RedirectToAction("Index", "TrangChu");
                }
                else
                {
                    ViewBag.Error = "Đăng nhập không thành công";
                    return View();
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            // Đăng xuất khỏi tài khoản
            Session["MaTK"] = "";
            Session["TenNV"] = "";
            return RedirectToAction("Login");
        }


        public static string GETMD5(string pass)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(pass);
            byte[] targetData = md5.ComputeHash(fromData);
            string mk_da_ma_hoa = null;
            for (int i = 0; i < targetData.Length; i++)
            {
                mk_da_ma_hoa += targetData[i].ToString("x2");
            }
            return mk_da_ma_hoa;
        }
    }
}