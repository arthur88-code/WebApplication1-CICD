using System;
    using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1;

namespace WebApplication1.Tests.PerformanceTests
{
    /// <summary>
    /// Performance Tests for ScholarshipService
    /// Verify response time and throughput
    /// Total: 3 Tests
    /// </summary>
    [TestClass]
    public class ServicePerformanceTests
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

        #region ============ Performance Tests (3 Tests) ============

        [TestMethod]
        [TestCategory("Performance")]
        [Timeout(5000)] // 5 seconds timeout
        public void EvaluateScholarship_1000Iterations_CompletesWithin1Second()
        {
            // Arrange
            var stopwatch = Stopwatch.StartNew();
            int iterations = 1000;
            int maxAllowedMs = 1000;

            // Act
            for (int i = 0; i < iterations; i++)
            {
                _service.EvaluateScholarship(3.8, 90);
            }
            stopwatch.Stop();

            // Assert
            long elapsedMs = stopwatch.ElapsedMilliseconds;
            Assert.IsTrue(elapsedMs < maxAllowedMs,
                $"Performance FAILED: Expected < {maxAllowedMs}ms but got {elapsedMs}ms for {iterations} iterations");

            TestContext.WriteLine($"✓ Performance PASSED: {iterations} iterations in {elapsedMs}ms " +
                $"(Average: {(double)elapsedMs / iterations:F4}ms per call)");
        }

        [TestMethod]
        [TestCategory("Performance")]
        [Timeout(5000)]
        public void RegisterEvent_1000Iterations_CompletesWithin1Second()
        {
            // Arrange
            var stopwatch = Stopwatch.StartNew();
            int iterations = 1000;
            int maxAllowedMs = 1000;

            // Act
            for (int i = 0; i < iterations; i++)
            {
                _service.RegisterEvent(25, "VIP", null);
            }
            stopwatch.Stop();

            // Assert
            long elapsedMs = stopwatch.ElapsedMilliseconds;
            Assert.IsTrue(elapsedMs < maxAllowedMs,
                $"Performance FAILED: Expected < {maxAllowedMs}ms but got {elapsedMs}ms for {iterations} iterations");

            TestContext.WriteLine($"✓ Performance PASSED: {iterations} iterations in {elapsedMs}ms " +
                $"(Average: {(double)elapsedMs / iterations:F4}ms per call)");
        }

        [TestMethod]
        [TestCategory("Performance")]
        [Timeout(5000)]
        public void ValidateContactForm_1000Iterations_CompletesWithin1Second()
        {
            // Arrange
            var stopwatch = Stopwatch.StartNew();
            int iterations = 1000;
            int maxAllowedMs = 1000;

            // Act
            for (int i = 0; i < iterations; i++)
            {
                _service.ValidateContactForm("John Doe", "test@example.com", "0912345678", "Nội dung liên hệ hỗ trợ");
            }
            stopwatch.Stop();

            // Assert
            long elapsedMs = stopwatch.ElapsedMilliseconds;
            Assert.IsTrue(elapsedMs < maxAllowedMs,
                $"Performance FAILED: Expected < {maxAllowedMs}ms but got {elapsedMs}ms for {iterations} iterations");

            TestContext.WriteLine($"✓ Performance PASSED: {iterations} iterations in {elapsedMs}ms " +
                $"(Average: {(double)elapsedMs / iterations:F4}ms per call)");
        }

        #endregion
    }
}
