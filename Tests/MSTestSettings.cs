using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace WebApplication1.Tests
{
    /// <summary>
    /// Global Test Configuration for CI/CD Automated Testing Pipeline
    /// Handles assembly-level initialization and cleanup
    /// </summary>
    [TestClass]
    public sealed class MSTestSettings
    {
        private static Stopwatch _suiteStopwatch;

        /// <summary>
        /// Executes once when test assembly initializes
        /// Setup: Configure test environment, logging, parallel execution
        /// </summary>
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            _suiteStopwatch = Stopwatch.StartNew();

            Console.WriteLine(new string('=', 80));
            Console.WriteLine("🚀 CI/CD AUTOMATED TEST SUITE - INITIALIZING");
            Console.WriteLine(new string('=', 80));
            Console.WriteLine($"   Start Time: {DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}");
            Console.WriteLine($"   Assembly: {typeof(MSTestSettings).Assembly.GetName().Name}");
            Console.WriteLine($"   Framework: .NET Framework 4.7.2");
            Console.WriteLine($"   Total Automated Tests: 83");
            Console.WriteLine($"   Unit Tests: 70 (55 Service + 15 Controller)");
            Console.WriteLine($"   Integration Tests: 10");
            Console.WriteLine($"   Performance Tests: 3");
            Console.WriteLine(new string('=', 80));
            Console.WriteLine();
        }

        /// <summary>
        /// Executes once when test assembly completes
        /// Cleanup: Log summary, dispose resources
        /// </summary>
        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            _suiteStopwatch?.Stop();

            Console.WriteLine();
            Console.WriteLine(new string('=', 80));
            Console.WriteLine("✅ CI/CD AUTOMATED TEST SUITE - COMPLETED");
            Console.WriteLine(new string('=', 80));
            Console.WriteLine($"   End Time: {DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}");
            Console.WriteLine($"   Total Duration: {_suiteStopwatch?.Elapsed.TotalSeconds:F2} seconds");
            Console.WriteLine(new string('=', 80));
        }
    }
}
