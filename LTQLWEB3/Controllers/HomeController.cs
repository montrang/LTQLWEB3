using LTQLWEB3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LTQLWEB3.Controllers
{
    public class HomeController : Controller
    {
        DBConnect db = new DBConnect();
        public ActionResult Index()
        {
            return View(db.SANPHAMs.ToList());
        }
            
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Email, string password)
        {
            if (ModelState.IsValid)
            {
                var ma_hoa_du_lieu = GETMD5(password);
                var kiem_tra_tai_khoan = db.KHACHHANGs.Where(s => s.Email.Equals(Email) && s.PassWord.Equals(ma_hoa_du_lieu)).ToList();
                if (kiem_tra_tai_khoan.Count() > 0)
                {
                    Session["MaKH"] = kiem_tra_tai_khoan.FirstOrDefault().MaKH;
                    Session["TenKH"] = kiem_tra_tai_khoan.FirstOrDefault().TenKH;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Đăng nhập không thành công";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();// Đăng xuất khỏi tài khoản
            return RedirectToAction("Index");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(KHACHHANG kh)
        {
            if (ModelState.IsValid)
            {
                var checkEmail = db.KHACHHANGs.FirstOrDefault(m => m.Email == kh.Email);
                if (checkEmail == null)
                {
                    kh.PassWord = GETMD5(kh.PassWord);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.KHACHHANGs.Add(kh);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.EmailError = "Email đã tồn tại";
                    return RedirectToAction("Register");
                }
            }
            return View();
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