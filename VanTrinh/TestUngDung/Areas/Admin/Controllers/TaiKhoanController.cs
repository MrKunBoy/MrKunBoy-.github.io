using ModelEF.DAO;
using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Common;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class TaiKhoanController : BaseController
    {
        // GET: Admin/TaiKhoan
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var ad = new AccountDAO();
            var model = ad.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var ad = new AccountDAO();
            var model = ad.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpGet]
        public ActionResult Create(string tendn)
        {
            var dao = new AccountDAO();
            var result = dao.FindTenDN(tendn);
            if (result != null)
                return View(result);
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserAccount model)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountDAO();
                var pass = Encryptor.EncryptMD5(model.Password);
                model.Password = pass;
                int result;
                result = dao.Insert(model);
                if (result ==1)
                {
                    SetAlert("Thêm mới tài khoản thành công !!!", "success");
                    return RedirectToAction("Index", "TaiKhoan");

                }
                else if(result == 0)
                {
                    SetAlert("Tên tài khoản đã tồn tại. Mời nhập tên khác !!!", "error");
                }
                else
                {
                    SetAlert("Lỗi thêm mới tài khoản !!!", "error");
                }
            }
            return View();
        }

        [HttpDelete]

        public ActionResult Delete(string id)
        {
            var dao = new AccountDAO();
            if (dao.ListAll().Count() == 1)
            {
                return RedirectToAction("Index");

            }
            else
            {
                dao.Delete(id);
                return RedirectToAction("Index");
            }
        }
    }
}