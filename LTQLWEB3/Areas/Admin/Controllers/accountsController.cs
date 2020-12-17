using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using LTQLWEB3.Models;

namespace LTQLWEB3.Areas.Admin.Controllers
{
    public class accountsController : BaseController
    {
        private DBConnect db = new DBConnect();

        // GET: Admin/accounts
        public ActionResult Index()
        {
            var accounts = db.accounts.Include(a => a.NHANVIEN).Include(a => a.Role);
            return View(accounts.ToList());
        }

        // GET: Admin/accounts/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            account account = db.accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Admin/accounts/Create
        public ActionResult Create()
        {
            ViewBag.NHANVIEN_MaNV = new SelectList(db.NHANVIENs, "MaNV", "TenNV");
            ViewBag.Role_MaVaiTro = new SelectList(db.Roles, "MaVaiTro", "TenVaiTro");
            return View();
        }

        // POST: Admin/accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(account account)
        {
            if (ModelState.IsValid)
            {
                account.Password = GetMD5(account.Password);
                db.Configuration.ValidateOnSaveEnabled = false;
                db.accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NHANVIEN_MaNV = new SelectList(db.NHANVIENs, "MaNV", "TenNV", account.NHANVIEN_MaNV);
            ViewBag.Role_MaVaiTro = new SelectList(db.Roles, "MaVaiTro", "TenVaiTro", account.Role_MaVaiTro);
            return View(account);
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string mk_da_ma_hoa = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                mk_da_ma_hoa += targetData[i].ToString("x2");

            }
            return mk_da_ma_hoa;
        }


        // GET: Admin/accounts/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            account account = db.accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            ViewBag.NHANVIEN_MaNV = new SelectList(db.NHANVIENs, "MaNV", "TenNV", account.NHANVIEN_MaNV);
            ViewBag.Role_MaVaiTro = new SelectList(db.Roles, "MaVaiTro", "TenVaiTro", account.Role_MaVaiTro);
            return View(account);
        }

        // POST: Admin/accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(account account, int id)
        {
            if (ModelState.IsValid)
            {
                //gán giá trị modify thủ công thay cho "db.Entry(account).State = EntityState.Modified"
                account acctInDatabase = db.accounts.Find(id);
                acctInDatabase.MaTk = account.MaTk;
                acctInDatabase.NHANVIEN_MaNV = account.NHANVIEN_MaNV;
                acctInDatabase.Role_MaVaiTro = account.Role_MaVaiTro;
                //vì không biết convert từ mã hóa MD5 về password ban đầu nên check logic
                //kiểm tra nếu password  thay đổi
                if (acctInDatabase.Password != account.Password)
                {
                    acctInDatabase.Password = GetMD5(account.Password);
                }
                //nếu không thay đổi
                else 
                {
                    acctInDatabase.Password = account.Password;
                }
                db.Configuration.ValidateOnSaveEnabled = false;
                //db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NHANVIEN_MaNV = new SelectList(db.NHANVIENs, "MaNV", "TenNV", account.NHANVIEN_MaNV);
            ViewBag.Role_MaVaiTro = new SelectList(db.Roles, "MaVaiTro", "TenVaiTro", account.Role_MaVaiTro);
            return View(account);
        }

        // GET: Admin/accounts/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            account account = db.accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Admin/accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            account account = db.accounts.Find(id);
            db.accounts.Remove(account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
