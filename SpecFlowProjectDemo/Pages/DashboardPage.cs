using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectDemo.Pages
{
    public class DashboardPage
    {
        private IWebDriver driver;
        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//p[@class='oxd-text oxd-text--p' and text()='My Actions']")]
        private IWebElement dashboardPgText;
        
        public string getDashboardText()
        {
            WebDriverWait waitTillDashPg = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            waitTillDashPg.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//p[@class='oxd-text oxd-text--p' and text()='My Actions']")));
            string textOnDash = dashboardPgText.Text;
            return textOnDash;
        }
    }
}
