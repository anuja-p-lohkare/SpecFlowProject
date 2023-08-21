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
    public class OrangeHRMLoginPage
    {
        private IWebDriver driver;
        public OrangeHRMLoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@name='username']")]
        private IWebElement username;

        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        private IWebElement password;

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        private IWebElement loginBtn;

        public DashboardPage Login(string userNm, string passwd)
        {
            WebDriverWait waitTillUser = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            waitTillUser.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//input[@name='username']")));
            username.SendKeys(userNm);
            password.SendKeys(passwd);
            loginBtn.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//input[@name='username']")));
            return new DashboardPage(driver);
        }

    }
}
