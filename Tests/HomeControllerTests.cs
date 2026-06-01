using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Controllers;

namespace WebApplication1.Tests
{
    /// <summary>
    /// Unit Tests for HomeController Actions
    /// Test Coverage: Index, Events, Contact actions
    /// Total: 15 Tests
    /// </summary>
    [TestClass]
    public class HomeControllerTests
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

        #region ============ Index Action Tests (5 Tests) ============

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("Controller")]
        [Priority(1)]
        public void Index_HttpGet_ReturnsViewResult()
        {
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result, "Index GET should return ViewResult");
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("Controller")]
        [Priority(1)]
        public void Index_HttpPost_ValidGPAAndPoints_SetsViewBagResult()
        {
            // Arrange
            double gpa = 3.8;
            int trainingPoint = 95;

            // Act
            var result = _controller.Index(gpa, trainingPoint) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(_controller.ViewBag.Result);
            Assert.AreEqual("Xuất sắc (Học bổng loại 1)", _controller.ViewBag.Result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("Controller")]
        [Priority(1)]
        public void Index_HttpPost_NullGPA_DoesNotSetViewBag()
        {
            // Act
            var result = _controller.Index(null, 95) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNull(_controller.ViewBag.Result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("Controller")]
        [Priority(1)]
        public void Index_HttpPost_NullPoints_DoesNotSetViewBag()
        {
            // Act
            var result = _controller.Index(3.8, null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNull(_controller.ViewBag.Result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("Controller")]
        [Priority(1)]
        public void Index_HttpPost_BothNull_DoesNotSetViewBag()
        {
            // Act
            var result = _controller.Index(null, null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNull(_controller.ViewBag.Result);
        }

        #endregion

        #region ============ Events Action Tests (5 Tests) ============

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("Controller")]
        [Priority(1)]
        public void Events_HttpGet_ReturnsViewResult()
        {
            // Act
            var result = _controller.Events() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("Controller")]
        [Priority(1)]
        public void Events_HttpPost_ValidAge_SetViewBag()
        {
            // Act
            var result = _controller.Events(25, "VIP", null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(_controller.ViewBag.Result);
            Assert.IsTrue(_controller.ViewBag.Result.ToString().Contains("Đăng ký thành công"));
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("Controller")]
        [Priority(1)]
        public void Events_HttpPost_NullAge_DoesNotSetViewBag()
        {
            // Act
            var result = _controller.Events(null, "VIP", null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNull(_controller.ViewBag.Result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("Controller")]
        [Priority(1)]
        public void Events_HttpPost_InvalidAge_SetViewBagError()
        {
            // Act
            var result = _controller.Events(14, "VIP", null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(_controller.ViewBag.Result);
            Assert.AreEqual("Độ tuổi tham gia phải từ 15 đến 60!", _controller.ViewBag.Result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("Controller")]
        [Priority(2)]
        public void Events_HttpPost_ValidPromoCode_AppliesDiscount()
        {
            // Act
            var result = _controller.Events(20, "VIP", "STUDENT") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(_controller.ViewBag.Result);
            Assert.IsTrue(_controller.ViewBag.Result.ToString().Contains("400,000"));
        }

        #endregion

        #region ============ Contact Action Tests (5 Tests) ============

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("Controller")]
        [Priority(1)]
        public void Contact_HttpGet_ReturnsViewResult()
        {
            // Act
            var result = _controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("Controller")]
        [Priority(1)]
        public void Contact_HttpPost_ValidData_ReturnsSuccess()
        {
            // Act
            var result = _controller.Contact("John Doe", "john@example.com", "0912345678", "Tôi cần giúp đỡ liên quan") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(_controller.ViewBag.Result);
            Assert.IsTrue(_controller.ViewBag.Result.ToString().Contains("Gửi thông tin liên hệ thành công"));
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("Controller")]
        [Priority(1)]
        public void Contact_HttpPost_InvalidEmail_ReturnsError()
        {
            // Act
            var result = _controller.Contact("John Doe", "invalidemail", "0912345678", "Nội dung liên hệ") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(_controller.ViewBag.Result);
            Assert.AreEqual("Định dạng Email không hợp lệ!", _controller.ViewBag.Result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("Controller")]
        [Priority(1)]
        public void Contact_HttpPost_InvalidPhone_ReturnsError()
        {
            // Act
            var result = _controller.Contact("John Doe", "john@example.com", "1234567890", "Nội dung liên hệ") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(_controller.ViewBag.Result);
            Assert.AreEqual("Số điện thoại phải gồm 10 chữ số và bắt đầu bằng số 0!", _controller.ViewBag.Result);
        }

        [TestMethod]
        [TestCategory("Unit")]
        [TestCategory("Controller")]
        [Priority(1)]
        public void Contact_HttpPost_ShortName_ReturnsError()
        {
            // Act
            var result = _controller.Contact("A", "john@example.com", "0912345678", "Nội dung liên hệ") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(_controller.ViewBag.Result);
            Assert.AreEqual("Họ tên phải từ 2 đến 50 ký tự!", _controller.ViewBag.Result);
        }

        #endregion
    }
}
