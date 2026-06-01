using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ScholarshipService _service = new ScholarshipService();

        // 1. TRANG XÉT HỌC BỔNG (DỰ ÁN)
        public ActionResult Index()
        {
            return View();
        }

        // Đón nhận dữ liệu khi người dùng bấm nút "Kiểm tra" trên giao diện
        [HttpPost]
        public ActionResult Index(double? gpa, int? trainingPoint)
        {
            if (gpa != null && trainingPoint != null)
                ViewBag.Result = _service.EvaluateScholarship(gpa.Value, trainingPoint.Value);
            return View();
        }
        // 2. TRANG SỰ KIỆN
        public ActionResult Events() => View();

        [HttpPost]
        public ActionResult Events(int? age, string ticketType, string promoCode)
        {
            if (age != null)
                ViewBag.Result = _service.RegisterEvent(age.Value, ticketType, promoCode);
            return View();
        }

        // 3. TRANG LIÊN HỆ
        public ActionResult Contact() => View();

        [HttpPost]
        public ActionResult Contact(string name, string email, string phone, string message)
        {
            ViewBag.Result = _service.ValidateContactForm(name, email, phone, message);
            return View();
        }
    }
}