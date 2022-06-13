using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiemTra_NguyenCongDat.Models;

namespace KiemTra_NguyenCongDat.Controllers
{
    public class HocPhanController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        // GET: HocPhan
        [HttpGet]
        public ActionResult DangKyHocPhan()
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString()=="")
            {
                return RedirectToAction("DangNhap","NguoiDung");
            }
            if (Session["HocPhan"]==null)
            {
                return RedirectToAction("Index", "SinhVien");
            }
            List<HocPhan> hocPhans = LayHocPhan();
            ViewBag.
        }
    }
}