using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1;

namespace WebApplication1.Tests
{
    /// <summary>
    /// Unit Tests for ScholarshipService
    /// Test Coverage: 
    ///   - Feature 1: EvaluateScholarship (13 tests)
    ///   - Feature 2: RegisterEvent (16 tests)
    ///   - Feature 3: ValidateContactForm (26 tests)
    /// Total: 55 Service Unit Tests
    /// </summary>
    [TestClass]
    public class ScholarshipServiceTests
    {
        private ScholarshipService _service;
        private TestContext _testContext;

        public TestContext TestContext
        {
            get { return _testContext; }
            set { _testContext = value; }
        }

        [TestInitialize]
        public void Setup()
        {
            _service = new ScholarshipService();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _service = null;
        }

        #region ============ FEATURE 1: EvaluateScholarship (13 Tests) ============

        /// <summary>
        /// VALID CASES: Test các input hợp lệ
        /// </summary>

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ScholarshipEvaluation")]
        [Priority(1)]
        public void EvaluateScholarship_HighGPAAndTrainingPoint_ReturnsExcellent()
        {
            // Arrange
            double gpa = 3.8;
            int trainingPoint = 95;
            string expected = "Xuất sắc (Học bổng loại 1)";

            // Act
            string result = _service.EvaluateScholarship(gpa, trainingPoint);

            // Assert
            Assert.AreEqual(expected, result);
            TestContext.WriteLine($"✓ PASS: GPA={gpa}, Points={trainingPoint} → {result}");
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ScholarshipEvaluation")]
        [Priority(1)]                                                                                                                                                                                                                       
        public void EvaluateScholarship_MinimumExcellentValues_ReturnsExcellent()
        {
            // Boundary test: Min values for Excellent (3.6, 90)
            var result = _service.EvaluateScholarship(3.6, 90);
            Assert.AreEqual("Xuất sắc (Học bổng loại 1)", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ScholarshipEvaluation")]
        [Priority(1)]
        public void EvaluateScholarship_GoodGPAAndTrainingPoint_ReturnsGood()
        {
            var result = _service.EvaluateScholarship(3.5, 85);
            Assert.AreEqual("Giỏi (Học bổng loại 2)", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ScholarshipEvaluation")]
        [Priority(1)]
        public void EvaluateScholarship_MinimumGoodValues_ReturnsGood()
        {
            // Boundary test: Min values for Good (3.2, 80)
            var result = _service.EvaluateScholarship(3.2, 80);
            Assert.AreEqual("Giỏi (Học bổng loại 2)", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ScholarshipEvaluation")]
        [Priority(2)]
        public void EvaluateScholarship_BelowMinimumGood_ReturnsNoScholarship()
        {
            var result = _service.EvaluateScholarship(3.1, 79);
            Assert.AreEqual("Không đạt học bổng", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ScholarshipEvaluation")]
        [Priority(2)]
        public void EvaluateScholarship_PerfectScore_ReturnsExcellent()
        {
            var result = _service.EvaluateScholarship(4.0, 100);
            Assert.AreEqual("Xuất sắc (Học bổng loại 1)", result);
        }

        /// <summary>
        /// BOUNDARY CASES: Test các giới hạn biên
        /// </summary>

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ScholarshipEvaluation")]
        [Priority(1)]
        public void EvaluateScholarship_ZeroValues_ReturnsNoScholarship()
        {
            var result = _service.EvaluateScholarship(0, 0);
            Assert.AreEqual("Không đạt học bổng", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ScholarshipEvaluation")]
        [Priority(1)]
        public void EvaluateScholarship_HighGPALowPoints_ReturnsNoScholarship()
        {
            // GPA cao nhưng điểm rèn luyện thấp → không đạt
            var result = _service.EvaluateScholarship(4.0, 50);
            Assert.AreEqual("Không đạt học bổng", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ScholarshipEvaluation")]
        [Priority(1)]
        public void EvaluateScholarship_LowGPAHighPoints_ReturnsNoScholarship()
        {
            // GPA thấp nhưng điểm rèn luyện cao → không đạt
            var result = _service.EvaluateScholarship(2.0, 100);
            Assert.AreEqual("Không đạt học bổng", result);
        }

        /// <summary>
        /// INVALID CASES: Test các input không hợp lệ
        /// </summary>

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ScholarshipEvaluation")]
        [Priority(1)]
        public void EvaluateScholarship_NegativeGPA_ReturnsInvalid()
        {
            var result = _service.EvaluateScholarship(-1.0, 90);
            Assert.AreEqual("Dữ liệu nhập vào không hợp lệ!", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ScholarshipEvaluation")]
        [Priority(1)]
        public void EvaluateScholarship_GPAAbove4_ReturnsInvalid()
        {
            var result = _service.EvaluateScholarship(4.5, 90);
            Assert.AreEqual("Dữ liệu nhập vào không hợp lệ!", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ScholarshipEvaluation")]
        [Priority(1)]
        public void EvaluateScholarship_NegativeTrainingPoint_ReturnsInvalid()
        {
            var result = _service.EvaluateScholarship(3.8, -5);
            Assert.AreEqual("Dữ liệu nhập vào không hợp lệ!", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ScholarshipEvaluation")]
        [Priority(1)]
        public void EvaluateScholarship_TrainingPointAbove100_ReturnsInvalid()
        {
            var result = _service.EvaluateScholarship(3.8, 101);
            Assert.AreEqual("Dữ liệu nhập vào không hợp lệ!", result);
        }

        #endregion

        #region ============ FEATURE 2: RegisterEvent (16 Tests) ============

        /// <summary>
        /// VALID CASES: Test đăng ký sự kiện hợp lệ
        /// </summary>

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("EventRegistration")]
        [Priority(1)]
        public void RegisterEvent_VIPTicketValidAge_ReturnsSuccess()
        {
            var result = _service.RegisterEvent(25, "VIP", null);
            Assert.IsTrue(result.Contains("Đăng ký thành công"));
            Assert.IsTrue(result.Contains("500,000"));
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("EventRegistration")]
        [Priority(1)]
        public void RegisterEvent_StandardTicketValidAge_ReturnsSuccess()
        {
            var result = _service.RegisterEvent(30, "STANDARD", null);
            Assert.IsTrue(result.Contains("Đăng ký thành công"));
            Assert.IsTrue(result.Contains("200,000"));
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("EventRegistration")]
        [Priority(1)]
        public void RegisterEvent_MinimumAge_ReturnsSuccess()
        {
            var result = _service.RegisterEvent(15, "VIP", null);
            Assert.IsTrue(result.Contains("Đăng ký thành công"));
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("EventRegistration")]
        [Priority(1)]
        public void RegisterEvent_MaximumAge_ReturnsSuccess()
        {
            var result = _service.RegisterEvent(60, "STANDARD", null);
            Assert.IsTrue(result.Contains("Đăng ký thành công"));
        }

        /// <summary>
        /// PROMO CODE TESTS: Test mã giảm giá
        /// </summary>

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("EventRegistration")]
        [Priority(2)]
        public void RegisterEvent_StudentPromoCode_ValidAge_DiscountApplied()
        {
            // STUDENT: 20% giảm cho tuổi <= 22
            var result = _service.RegisterEvent(20, "VIP", "STUDENT");
            Assert.IsTrue(result.Contains("Đăng ký thành công"));
            Assert.IsTrue(result.Contains("400,000")); // 500000 * 0.8
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("EventRegistration")]
        [Priority(2)]
        public void RegisterEvent_StudentPromoCode_OverAge_DiscountNotApplied()
        {
            // STUDENT promo chỉ áp dụng cho tuổi <= 22
            var result = _service.RegisterEvent(23, "VIP", "STUDENT");
            Assert.AreEqual("Mã giảm giá không hợp lệ hoặc không đủ điều kiện áp dụng!", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("EventRegistration")]
        [Priority(2)]
        public void RegisterEvent_Group4PromoCode_ReturnsSuccess()
        {
            // GROUP4: 10% giảm cho mọi tuổi
            var result = _service.RegisterEvent(25, "STANDARD", "GROUP4");
            Assert.IsTrue(result.Contains("Đăng ký thành công"));
            Assert.IsTrue(result.Contains("180,000")); // 200000 * 0.9
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("EventRegistration")]
        [Priority(1)]
        public void RegisterEvent_InvalidPromoCode_ReturnsError()
        {
            var result = _service.RegisterEvent(25, "VIP", "INVALID");
            Assert.AreEqual("Mã giảm giá không hợp lệ hoặc không đủ điều kiện áp dụng!", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("EventRegistration")]
        [Priority(1)]
        public void RegisterEvent_EmptyPromoCode_NoDiscount()
        {
            var result = _service.RegisterEvent(25, "VIP", "");
            Assert.IsTrue(result.Contains("500,000"));
        }

        /// <summary>
        /// INVALID AGE TESTS: Test tuổi không hợp lệ
        /// </summary>

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("EventRegistration")]
        [Priority(1)]
        public void RegisterEvent_AgeBelowMinimum_ReturnsError()
        {
            var result = _service.RegisterEvent(14, "VIP", null);
            Assert.AreEqual("Độ tuổi tham gia phải từ 15 đến 60!", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("EventRegistration")]
        [Priority(1)]
        public void RegisterEvent_AgeAboveMaximum_ReturnsError()
        {
            var result = _service.RegisterEvent(61, "VIP", null);
            Assert.AreEqual("Độ tuổi tham gia phải từ 15 đến 60!", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("EventRegistration")]
        [Priority(1)]
        public void RegisterEvent_ZeroAge_ReturnsError()
        {
            var result = _service.RegisterEvent(0, "VIP", null);
            Assert.AreEqual("Độ tuổi tham gia phải từ 15 đến 60!", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("EventRegistration")]
        [Priority(1)]
        public void RegisterEvent_NegativeAge_ReturnsError()
        {
            var result = _service.RegisterEvent(-5, "VIP", null);
            Assert.AreEqual("Độ tuổi tham gia phải từ 15 đến 60!", result);
        }

        /// <summary>
        /// INVALID TICKET TYPE TESTS: Test loại vé không hợp lệ
        /// </summary>

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("EventRegistration")]
        [Priority(1)]
        public void RegisterEvent_InvalidTicketType_ReturnsError()
        {
            var result = _service.RegisterEvent(25, "BASIC", null);
            Assert.AreEqual("Loại vé không hợp lệ!", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("EventRegistration")]
        [Priority(1)]
        public void RegisterEvent_NullTicketType_ReturnsError()
        {
            var result = _service.RegisterEvent(25, null, null);
            Assert.AreEqual("Loại vé không hợp lệ!", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("EventRegistration")]
        [Priority(1)]
        public void RegisterEvent_CaseSensitiveTicketType_ReturnsError()
        {
            // Ticket type phải uppercase
            var result = _service.RegisterEvent(25, "vip", null);
            Assert.AreEqual("Loại vé không hợp lệ!", result);
        }

        #endregion

        #region ============ FEATURE 3: ValidateContactForm (26 Tests) ============

        /// <summary>
        /// VALID CASES: Test các dữ liệu hợp lệ
        /// </summary>

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ContactForm")]
        [Priority(1)]
        public void ValidateContactForm_ValidInput_ReturnsSuccess()
        {
            var result = _service.ValidateContactForm("Nguyễn Văn A", "test@example.com", "0912345678", "Tôi cần hỗ trợ liên quan");
            Assert.AreEqual("Gửi thông tin liên hệ thành công! Chúng tôi sẽ phản hồi sớm nhất.", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ContactForm")]
        [Priority(1)]
        public void ValidateContactForm_MinimumNameLength_ReturnsSuccess()
        {
            // Min name length: 2 characters
            var result = _service.ValidateContactForm("AB", "test@example.com", "0912345678", "Nội dung hỗ trợ");
            Assert.AreEqual("Gửi thông tin liên hệ thành công! Chúng tôi sẽ phản hồi sớm nhất.", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ContactForm")]
        [Priority(1)]
        public void ValidateContactForm_MaximumNameLength_ReturnsSuccess()
        {
            // Max name length: 50 characters
            var name = new string('A', 50);
            var result = _service.ValidateContactForm(name, "test@example.com", "0912345678", "Nội dung hỗ trợ");
            Assert.AreEqual("Gửi thông tin liên hệ thành công! Chúng tôi sẽ phản hồi sớm nhất.", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ContactForm")]
        [Priority(2)]
        public void ValidateContactForm_ComplexEmail_ReturnsSuccess()
        {
            // Email format: user.name+tag@example.co.uk
            var result = _service.ValidateContactForm("John Doe", "user.name+tag@example.co.uk", "0912345678", "Nội dung hỗ trợ");
            Assert.AreEqual("Gửi thông tin liên hệ thành công! Chúng tôi sẽ phản hồi sớm nhất.", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ContactForm")]
        [Priority(1)]
        public void ValidateContactForm_MinimumMessageLength_ReturnsSuccess()
        {
            // Min message length: 10 characters
            var result = _service.ValidateContactForm("John Doe", "test@example.com", "0912345678", "1234567890");
            Assert.AreEqual("Gửi thông tin liên hệ thành công! Chúng tôi sẽ phản hồi sớm nhất.", result);
        }

        /// <summary>
        /// INVALID NAME TESTS: Test tên không hợp lệ
        /// </summary>

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ContactForm")]
        [Priority(1)]
        public void ValidateContactForm_NameTooShort_ReturnsError()
        {
            var result = _service.ValidateContactForm("A", "test@example.com", "0912345678", "Nội dung hỗ trợ");
            Assert.AreEqual("Họ tên phải từ 2 đến 50 ký tự!", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ContactForm")]
        [Priority(1)]
        public void ValidateContactForm_NameTooLong_ReturnsError()
        {
            var name = new string('A', 51);
            var result = _service.ValidateContactForm(name, "test@example.com", "0912345678", "Nội dung hỗ trợ");
            Assert.AreEqual("Họ tên phải từ 2 đến 50 ký tự!", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ContactForm")]
        [Priority(1)]
        public void ValidateContactForm_EmptyName_ReturnsError()
        {
            var result = _service.ValidateContactForm("", "test@example.com", "0912345678", "Nội dung hỗ trợ");
            Assert.AreEqual("Họ tên phải từ 2 đến 50 ký tự!", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ContactForm")]
        [Priority(1)]
        public void ValidateContactForm_NullName_ReturnsError()
        {
            var result = _service.ValidateContactForm(null, "test@example.com", "0912345678", "Nội dung hỗ trợ");
            Assert.AreEqual("Họ tên phải từ 2 đến 50 ký tự!", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ContactForm")]
        [Priority(1)]
        public void ValidateContactForm_WhitespaceName_ReturnsError()
        {
            var result = _service.ValidateContactForm("   ", "test@example.com", "0912345678", "Nội dung hỗ trợ");
            Assert.AreEqual("Họ tên phải từ 2 đến 50 ký tự!", result);
        }

        /// <summary>
        /// INVALID EMAIL TESTS: Test email không hợp lệ
        /// </summary>

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ContactForm")]
        [Priority(1)]
        public void ValidateContactForm_InvalidEmailMissingAt_ReturnsError()
        {
            var result = _service.ValidateContactForm("John Doe", "testexample.com", "0912345678", "Nội dung hỗ trợ");
            Assert.AreEqual("Định dạng Email không hợp lệ!", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ContactForm")]
        [Priority(1)]
        public void ValidateContactForm_InvalidEmailMissingDomain_ReturnsError()
        {
            var result = _service.ValidateContactForm("John Doe", "test@.com", "0912345678", "Nội dung hỗ trợ");
            Assert.AreEqual("Định dạng Email không hợp lệ!", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ContactForm")]
        [Priority(1)]
        public void ValidateContactForm_InvalidEmailMissingExtension_ReturnsError()
        {
            var result = _service.ValidateContactForm("John Doe", "test@example", "0912345678", "Nội dung hỗ trợ");
            Assert.AreEqual("Định dạng Email không hợp lệ!", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ContactForm")]
        [Priority(1)]
        public void ValidateContactForm_EmptyEmail_ReturnsError()
        {
            var result = _service.ValidateContactForm("John Doe", "", "0912345678", "Nội dung hỗ trợ");
            Assert.AreEqual("Định dạng Email không hợp lệ!", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ContactForm")]
        [Priority(1)]
        public void ValidateContactForm_NullEmail_ReturnsError()
        {
            var result = _service.ValidateContactForm("John Doe", null, "0912345678", "Nội dung hỗ trợ");
            Assert.AreEqual("Định dạng Email không hợp lệ!", result);
        }

        /// <summary>
        /// INVALID PHONE TESTS: Test số điện thoại không hợp lệ
        /// </summary>

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ContactForm")]
        [Priority(1)]
        public void ValidateContactForm_PhoneNotStartingWith0_ReturnsError()
        {
            var result = _service.ValidateContactForm("John Doe", "test@example.com", "1912345678", "Nội dung hỗ trợ");
            Assert.AreEqual("Số điện thoại phải gồm 10 chữ số và bắt đầu bằng số 0!", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ContactForm")]
        [Priority(1)]
        public void ValidateContactForm_PhoneTooShort_ReturnsError()
        {
            var result = _service.ValidateContactForm("John Doe", "test@example.com", "091234567", "Nội dung hỗ trợ");
            Assert.AreEqual("Số điện thoại phải gồm 10 chữ số và bắt đầu bằng số 0!", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ContactForm")]
        [Priority(1)]
        public void ValidateContactForm_PhoneTooLong_ReturnsError()
        {
            var result = _service.ValidateContactForm("John Doe", "test@example.com", "09123456789", "Nội dung hỗ trợ");
            Assert.AreEqual("Số điện thoại phải gồm 10 chữ số và bắt đầu bằng số 0!", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ContactForm")]
        [Priority(1)]
        public void ValidateContactForm_PhoneWithLetters_ReturnsError()
        {
            var result = _service.ValidateContactForm("John Doe", "test@example.com", "091234567a", "Nội dung hỗ trợ");
            Assert.AreEqual("Số điện thoại phải gồm 10 chữ số và bắt đầu bằng số 0!", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ContactForm")]
        [Priority(1)]
        public void ValidateContactForm_EmptyPhone_ReturnsError()
        {
            var result = _service.ValidateContactForm("John Doe", "test@example.com", "", "Nội dung hỗ trợ");
            Assert.AreEqual("Số điện thoại phải gồm 10 chữ số và bắt đầu bằng số 0!", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ContactForm")]
        [Priority(1)]
        public void ValidateContactForm_NullPhone_ReturnsError()
        {
            var result = _service.ValidateContactForm("John Doe", "test@example.com", null, "Nội dung hỗ trợ");
            Assert.AreEqual("Số điện thoại phải gồm 10 chữ số và bắt đầu bằng số 0!", result);
        }

        /// <summary>
        /// INVALID MESSAGE TESTS: Test nội dung không hợp lệ
        /// </summary>

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ContactForm")]
        [Priority(1)]
        public void ValidateContactForm_MessageTooShort_ReturnsError()
        {
            var result = _service.ValidateContactForm("John Doe", "test@example.com", "0912345678", "123456789");
            Assert.AreEqual("Nội dung liên hệ phải có ít nhất 10 ký tự!", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ContactForm")]
        [Priority(1)]
        public void ValidateContactForm_EmptyMessage_ReturnsError()
        {
            var result = _service.ValidateContactForm("John Doe", "test@example.com", "0912345678", "");
            Assert.AreEqual("Nội dung liên hệ phải có ít nhất 10 ký tự!", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ContactForm")]
        [Priority(1)]
        public void ValidateContactForm_NullMessage_ReturnsError()
        {
            var result = _service.ValidateContactForm("John Doe", "test@example.com", "0912345678", null);
            Assert.AreEqual("Nội dung liên hệ phải có ít nhất 10 ký tự!", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ContactForm")]
        [Priority(1)]
        public void ValidateContactForm_WhitespaceMessage_ReturnsError()
        {
            var result = _service.ValidateContactForm("John Doe", "test@example.com", "0912345678", "          ");
            Assert.AreEqual("Nội dung liên hệ phải có ít nhất 10 ký tự!", result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("ContactForm")]
        [Priority(1)]
        public void ValidateContactForm_NullInput_ReturnsNameError()
        {
            // Prioritize name validation first
            var result = _service.ValidateContactForm(null, null, null, null);
            Assert.AreEqual("Họ tên phải từ 2 đến 50 ký tự!", result);
        }

        #endregion
    }
}
