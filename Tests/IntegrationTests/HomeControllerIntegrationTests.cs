using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using WebApplication1.Controllers;

namespace WebApplication1.Tests.IntegrationTests
{
    /// <summary>
    /// Integration Tests for HomeController
    /// Test Controller + Service + ViewBag flow
    /// Total: 10 Tests
    /// </summary>
    [TestClass]
    public class HomeControllerIntegrationTests
    {
        private HomeController _controller;
        private TestContext _testContext;

        public TestContext TestContext
        {
            get { return _testContext; }
            set { _testContext = value; }
        }

        [TestInitialize]
        public void Setup()
        {
            _controller = new HomeController();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _controller?.Dispose();
            _controller = null;
        }

        #region ============ Index Integration Tests (3 Tests) ============

        [TestMethod]
        [TestCategory("Integration")]
        [Priority(1)]
        public void Index_PostWithValidScholarshipData_ReturnsExcellentResult()
        {
            // Arrange
            double gpa = 3.8;
            int trainingPoint = 95;

            // Act
            var result = _controller.Index(gpa, trainingPoint) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(_controller.ModelState.IsValid);
            Assert.IsNotNull(_controller.ViewBag.Result);
            Assert.AreEqual("Xuất sắc (Học bổng loại 1)", _controller.ViewBag.Result);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [Priority(1)]
        public void Index_PostWithGoodScholarshipData_ReturnsGoodResult()
        {
            // Arrange
            double gpa = 3.5;
            int trainingPoint = 85;

            // Act
            var result = _controller.Index(gpa, trainingPoint) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(_controller.ViewBag.Result);
            Assert.AreEqual("Giỏi (Học bổng loại 2)", _controller.ViewBag.Result);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [Priority(1)]
        public void Index_PostWithInvalidGPA_ReturnsErrorMessage()
        {
            // Arrange
            double gpa = 4.5; // Invalid
            int trainingPoint = 90;

            // Act
            var result = _controller.Index(gpa, trainingPoint) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(_controller.ViewBag.Result);
            Assert.AreEqual("Dữ liệu nhập vào không hợp lệ!", _controller.ViewBag.Result);
        }

        #endregion

        #region ============ Events Integration Tests (4 Tests) ============

        [TestMethod]
        [TestCategory("Integration")]
        [Priority(1)]
        public void Events_PostWithValidVIPTicket_ReturnsSuccessWithPrice()
        {
            // Arrange
            int age = 25;
            string ticketType = "VIP";

            // Act
            var result = _controller.Events(age, ticketType, null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(_controller.ModelState.IsValid);
            Assert.IsNotNull(_controller.ViewBag.Result);
            Assert.IsTrue(_controller.ViewBag.Result.ToString().Contains("Đăng ký thành công"));
            Assert.IsTrue(_controller.ViewBag.Result.ToString().Contains("500,000"));
        }

        [TestMethod]
        [TestCategory("Integration")]
        [Priority(2)]
        public void Events_PostWithStudentPromo_AppliesDiscountCorrectly()
        {
            // Arrange
            int age = 20;
            string ticketType = "VIP";
            string promoCode = "STUDENT";

            // Act
            var result = _controller.Events(age, ticketType, promoCode) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(_controller.ViewBag.Result);
            Assert.IsTrue(_controller.ViewBag.Result.ToString().Contains("400,000"));
        }

        [TestMethod]
        [TestCategory("Integration")]
        [Priority(2)]
        public void Events_PostWithGroup4Promo_AppliesGroup4Discount()
        {
            // Arrange
            int age = 25;
            string ticketType = "STANDARD";
            string promoCode = "GROUP4";

            // Act
            var result = _controller.Events(age, ticketType, promoCode) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(_controller.ViewBag.Result);
            Assert.IsTrue(_controller.ViewBag.Result.ToString().Contains("180,000"));
        }

        [TestMethod]
        [TestCategory("Integration")]
        [Priority(1)]
        public void Events_PostWithInvalidAge_ReturnsErrorMessage()
        {
            // Arrange
            int age = 14; // < 15
            string ticketType = "VIP";

            // Act
            var result = _controller.Events(age, ticketType, null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(_controller.ViewBag.Result);
            Assert.AreEqual("Độ tuổi tham gia phải từ 15 đến 60!", _controller.ViewBag.Result);
        }

        #endregion

        #region ============ Contact Integration Tests (3 Tests) ============

        [TestMethod]
        [TestCategory("Integration")]   
        [Priority(1)]
        public void Contact_PostWithValidData_SendsSuccessfully()
        {
            // Arrange
            string name = "John Doe";
            string email = "john@example.com";
            string phone = "0912345678";
            string message = "Tôi cần hỗ trợ liên quan";

            // Act
            var result = _controller.Contact(name, email, phone, message) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(_controller.ModelState.IsValid);
            Assert.IsNotNull(_controller.ViewBag.Result);
            Assert.IsTrue(_controller.ViewBag.Result.ToString().Contains("thành công"));
        }

        [TestMethod]
        [TestCategory("Integration")]
        [Priority(1)]
        public void Contact_PostWithInvalidEmailFormat_ReturnsEmailError()
        {
            // Arrange
            string name = "John Doe";
            string email = "invalidemail"; // Invalid format
            string phone = "0912345678";
            string message = "Nội dung liên hệ";

            // Act
            var result = _controller.Contact(name, email, phone, message) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(_controller.ViewBag.Result);
            Assert.AreEqual("Định dạng Email không hợp lệ!", _controller.ViewBag.Result);
        }

        [TestMethod]
        [TestCategory("Integration")]
        [Priority(1)]
        public void Contact_PostWithAllInvalidFields_ReturnsNameErrorFirst()
        {
            // Arrange - All fields invalid, should prioritize name validation
            string name = "A"; // Too short
            string email = "invalidemail";
            string phone = "123";
            string message = "short";

            // Act
            var result = _controller.Contact(name, email, phone, message) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(_controller.ViewBag.Result);
            // Validation happens in order: name → email → phone → message
            Assert.AreEqual("Họ tên phải từ 2 đến 50 ký tự!", _controller.ViewBag.Result);
        }

        #endregion
    }
}
