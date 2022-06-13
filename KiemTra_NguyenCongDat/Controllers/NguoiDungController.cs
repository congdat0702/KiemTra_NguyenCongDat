using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KiemTra_NguyenCongDat.Models;


namespace KiemTra_NguyenCongDat.Controllers
{
    public class NguoiDungController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        [HttpGet]
        // GET: NguoiDung
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection collection, SinhVien sinhVien)
        {
            var masv = collection["MaSV"];
            var hoten = collection["HoTen"];
            var gioitinh = collection["GioiTinh"];
            var ngaysinh = Convert.ToDateTime(collection["NgaySinh"]);
            var hinh = collection["Hinh"];
            var manganh = collection["MaNganh"];
            var tendangnhap = collection["TenDangNhap"];
            var matkhau = collection["MatKhau"];
            var MatKhauXacNhan = collection["MatKhauXacNhan"];
            if (string.IsNullOrEmpty(MatKhauXacNhan))
            {
                ViewData["NhapMKXN"] = " Phải nhập mật khẩu xác nhận !!!";
            }
            else
            {
                if(!matkhau.Equals(MatKhauXacNhan))
                {
                    ViewData["MatKhauGiongNhau"] = "Mật khẩu và mật khẩu xác nhận phải giống nhau !!!!";
                }
                else
                {
                    sinhVien.MaSV = masv;
                    sinhVien.HoTen = hoten;
                    sinhVien.GioiTinh = gioitinh;
                    sinhVien.NgaySinh = ngaysinh;
                    sinhVien.Hinh = hinh;
                    sinhVien.MaNganh = manganh;
                    sinhVien.TenDangNhap = tendangnhap;
                    sinhVien.MatKhau = matkhau;

                    data.SinhViens.InsertOnSubmit(sinhVien);
                    data.SubmitChanges();
                    return RedirectToAction("DangNhap");
                }
            }
            return this.DangKy();
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var tendangnhap = collection["tendangnhap"];
            SinhVien sv = data.SinhViens.SingleOrDefault(m => m.TenDangNhap == tendangnhap);
            if (sv!= null)
            {
                ViewBag.ThongBao = "Chúc mừng bạn đăng nhập thành công";
                Session["TaiKhoan"] = sv;
            }    
            else
            {
                ViewBag.ThongBao = "Mã sinh viên nhập không đúng";
            }
            return RedirectToAction("Index", "SinhVien");
        }
    }
}