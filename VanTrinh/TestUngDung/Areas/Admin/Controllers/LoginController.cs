using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.Admin.Models;
using TestUngDung.Common;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountDAO();
                var result = dao.login(user.UserName, Encryptor.EncryptMD5(user.Password));
                if (result == "Admin")
                {
                    //ModelState.AddModelError("", "xin chao trinh");
                    Session.Add(Constants.USER_SESSION, user);
                    return RedirectToAction("Index", "Home" );
                }
                else if (result =="Customer")
                {
                    ModelState.AddModelError("", "Tài khoản không thuộc trang admin !!!");
                }
                else if (result =="Blocked")
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa !!!");
                }
                else 
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công !!!");
                }
            }
            return View("Index");
        }
    }
}