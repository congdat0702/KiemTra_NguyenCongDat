using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiemTra_NguyenCongDat.Models;

namespace KiemTra_NguyenCongDat.Controllers
{
    public class SinhVienController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();

        // GET: SinhVien
        public ActionResult Index()
        {
            var SinhViens = from ss in data.SinhViens select ss;
            return View(SinhViens);
        }
        public ActionResult Detail(string id)
        {
            var S_SinhVien = data.SinhViens.Where(m => m.MaSV == id).First();

            return View(S_SinhVien);
        }
        public ActionResult Create()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien s)
        {
            var S_MaSv = collection["MaSV"];
            var S_HoTen = collection["HoTen"];
            var S_GioiTinh = collection["GioiTinh"];
            var S_NgaySinh = Convert.ToDateTime(collection["NgaySinh"]);
            var S_Hinh = collection["Hinh"];
            var S_MaNganh = collection["MaNganh"];
            if (string.IsNullOrEmpty(S_MaSv))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.MaSV = S_MaSv.ToString();
                s.HoTen = S_HoTen.ToString();
                s.GioiTinh = S_GioiTinh.ToString();
                s.NgaySinh = S_NgaySinh;
                s.Hinh = S_Hinh.ToString();
                s.MaNganh = S_MaNganh.ToString();
                data.SinhViens.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
        public ActionResult Edit(string id)
        {
            var S_SinhVien = data.SinhViens.First(m => m.MaSV == id);
            return View(S_SinhVien);
        }
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var S_SinhVien = data.SinhViens.First(m => m.MaSV == id);
            var S_HoTen = collection["HoTen"];
            var S_GioiTinh = collection["GioiTinh"];
            var S_NgaySinh = Convert.ToDateTime(collection["NgaySinh"]);
            var S_Hinh = collection["Hinh"];
            var S_MaNganh = collection["MaNganh"];
            S_SinhVien.MaSV = id;
            if (string.IsNullOrEmpty(S_HoTen))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                S_SinhVien.HoTen = S_HoTen;
                S_SinhVien.GioiTinh = S_GioiTinh;
                S_SinhVien.NgaySinh = S_NgaySinh;
                S_SinhVien.Hinh = S_Hinh;
                S_SinhVien.MaNganh = S_MaNganh;
                UpdateModel(S_SinhVien);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        public ActionResult Delete(string id)
        {
            var D_sach = data.SinhViens.First(m => m.MaSV == id);
            return View(D_sach);
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var D_sach = data.SinhViens.Where(m => m.MaSV == id).First();
            data.SinhViens.DeleteOnSubmit(D_sach);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }

        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "/Content/images/" + file.FileName;
        }
    }
}