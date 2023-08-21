using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowProjectDemo.Pages;

namespace SpecFlowProjectDemo.StepDefinitions
{
    [Binding]
    public sealed class OrangeHRMStepDefinitions
    {
        private IWebDriver driver;
        OrangeHRMLoginPage OrgLoginPg;
        DashboardPage dashPg;

        public OrangeHRMStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"Navigate to OrangeHRM login page")]
        public void GivenNavigateToOrangeHRMLoginPage()
        {
            driver.Url = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";
        }

        [When(@"user enters (.*) and (.*)")]
        public void WhenUserEntersUsername(string user, string pass)
        {
            OrgLoginPg = new OrangeHRMLoginPage(driver);
            dashPg = OrgLoginPg.Login(user, pass);

        }

        [When(@"clicks on Login button")]
        public void WhenClicksOnLoginButton()
        {
            Console.WriteLine("Clicked on Login");
        }

        [Then(@"user should be logged in succesfully")]
        public void ThenUserShouldBeLoggedInSuccesfully()
        {
            string dashPgText = dashPg.getDashboardText();
            Assert.AreEqual("My Actions", dashPgText);
        }


    }
}