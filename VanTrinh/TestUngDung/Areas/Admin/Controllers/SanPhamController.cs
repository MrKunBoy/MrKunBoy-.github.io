using ModelEF.DAO;
using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class SanPhamController : BaseController
    {
        // GET: Admin/SanPham
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var ad = new SanPhamDAO();
            var model = ad.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var ad = new SanPhamDAO();
            var model = ad.ListWhereAll(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpGet]
        public ActionResult Create(string ten)
        {
            SetViewBag();
            var dao = new SanPhamDAO();
            var result = dao.FindTenSP(ten);
            if (result != null)
                return View(result);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="Name,UnitCost,Quantity,Description,Status,CategoryID")]Product model,HttpPostedFileBase image)
        {
            SetViewBag();
            if(image != null && image.ContentLength > 0)
            {
                //model.Image = new byte[image.ContentLength];
                string fileName = System.IO.Path.GetFileName(image.FileName);
                string urlImage = Server.MapPath("~/Image/" + fileName);
                image.SaveAs(urlImage);

                model.Image = "Image/" + fileName;
            }

            if (ModelState.IsValid)
            {
                var dao = new SanPhamDAO();
                int result;
                result = dao.Insert(model);
                if (result == 1)
                {
                    SetAlert("Thêm mới sản phẩm thành công !!!", "success");
                    return RedirectToAction("Index", "SanPham");

                }
                else if (result == 0)
                {
                    SetAlert("Tên sản phẩm đã tồn tại. Mời nhập tên khác !!!", "error");
                }
                else
                {
                    SetAlert("Lỗi thêm mới sản phẩm !!!", "error");
                }
            }
            return View();
        }

        public void SetViewBag(int? selectedID = null)
        {
            var dao = new CategoryDAO();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name", selectedID);
        }

        [HttpDelete]

        public ActionResult Delete(int id)
        {
            var dao = new SanPhamDAO();
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

        public ActionResult ChiTietSP(int id)
        {
            var model = new CategoryDAO().ViewDetail(id);
            ViewBag.Category = new CategoryDAO().ViewDetail(model.CategoryID.Value);
            
            return View(model);
        }

        

    }
}