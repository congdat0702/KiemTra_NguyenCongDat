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
        public List<HocPhan> Layhocphan()
        {
            List<HocPhan> lstHocphan = Session["Đăng Ký"] as List<HocPhan>;
            if (lstHocphan == null)
            {
                lstHocphan = new List<HocPhan>();
                Session["Đăng Ký"] = lstHocphan;
            }
            return lstHocphan;
        }
        // GET: HocPhan
        public ActionResult Index()
        {
            var HocPhans = from ss in data.HocPhans select ss;
            return View(HocPhans);
        }
    }
}