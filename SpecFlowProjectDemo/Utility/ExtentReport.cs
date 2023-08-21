using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBDDAutomationFramework.Utility
{
    public class ExtentReport
    {
        public static ExtentReports _extentReports;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;

        public static string dir = AppDomain.CurrentDomain.BaseDirectory;        
        public static string testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestResults");
        
        public static void ExtentReportInit()
        {
            var htmlReporter = new ExtentHtmlReporter(testResultPath);
            htmlReporter.Config.ReportName = "Automation status report";
            htmlReporter.Config.DocumentTitle = "Automation status report";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            htmlReporter.Start();

            _extentReports = new ExtentReports();            
            _extentReports.AttachReporter(htmlReporter);
            _extentReports.AddSystemInfo("Application", "YouTube");
            _extentReports.AddSystemInfo("Browser", "Chrome");
            _extentReports.AddSystemInfo("OS", "Windows");
        }

        public static void ExtentReportTearDown()
        {
            _extentReports.Flush();
        }

        public string addScreenShot(IWebDriver driver, ScenarioContext name)
        {
            ITakesScreenshot sc = (ITakesScreenshot)driver;
            Screenshot screenshot = sc.GetScreenshot();
            string screenshotPath = Path.Combine(testResultPath, name.ScenarioInfo.Title + ".png");
            screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
            return screenshotPath;

        }

    }
}
