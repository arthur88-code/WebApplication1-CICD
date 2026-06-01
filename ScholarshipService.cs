using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebApplication1
{
    public class ScholarshipService
    {
        // =========================================================================
        // FEATURE 1: XÉT HỌC BỔNG (13 automated unit tests)
        // =========================================================================
        public string EvaluateScholarship(double gpa, int trainingPoint)
        {
            if (gpa < 0 || gpa > 4.0 || trainingPoint < 0 || trainingPoint > 100)
            {
                return "Dữ liệu nhập vào không hợp lệ!";
            }

            if (gpa >= 3.6 && trainingPoint >= 90) return "Xuất sắc (Học bổng loại 1)";
            if (gpa >= 3.2 && trainingPoint >= 80) return "Giỏi (Học bổng loại 2)";

            return "Không đạt học bổng";
        }

        // =========================================================================
        // FEATURE 2: ĐĂNG KÝ SỰ KIỆN (16 automated unit tests)
        // =========================================================================
        public string RegisterEvent(int age, string ticketType, string promoCode)
        {
            if (age < 15 || age > 60) return "Độ tuổi tham gia phải từ 15 đến 60!";

            double basePrice = 0;
            if (ticketType == "VIP") basePrice = 500000;
            else if (ticketType == "STANDARD") basePrice = 200000;
            else return "Loại vé không hợp lệ!";

            // Xử lý mã giảm giá
            if (!string.IsNullOrEmpty(promoCode))
            {
                if (promoCode == "STUDENT" && age <= 22) basePrice *= 0.8; // Giảm 20%
                else if (promoCode == "GROUP4") basePrice *= 0.9; // Giảm 10%
                else return "Mã giảm giá không hợp lệ hoặc không đủ điều kiện áp dụng!";
            }

            return $"Đăng ký thành công! Số tiền cần thanh toán: {basePrice:N0} VNĐ";
        }

        // =========================================================================
        // FEATURE 3: FORM LIÊN HỆ (26 automated unit tests)
        // =========================================================================
        public string ValidateContactForm(string name, string email, string phone, string message)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 2 || name.Length > 50)
                return "Họ tên phải từ 2 đến 50 ký tự!";

            // Kiểm tra định dạng Email chuẩn bằng Regex
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, emailPattern))
                return "Định dạng Email không hợp lệ!";

            // Kiểm tra số điện thoại (Phải bắt đầu bằng 0, đủ 10 số)
            string phonePattern = @"^0[0-9]{9}$";
            if (string.IsNullOrEmpty(phone) || !Regex.IsMatch(phone, phonePattern))
                return "Số điện thoại phải gồm 10 chữ số và bắt đầu bằng số 0!";

            if (string.IsNullOrWhiteSpace(message) || message.Length < 10)
                return "Nội dung liên hệ phải có ít nhất 10 ký tự!";

            return "Gửi thông tin liên hệ thành công! Chúng tôi sẽ phản hồi sớm nhất.";
        }
    }
}
