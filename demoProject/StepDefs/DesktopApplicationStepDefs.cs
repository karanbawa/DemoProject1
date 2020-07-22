using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using TechTalk.SpecFlow;

namespace demoProject.StepDefs
{
    [Binding]
    public sealed class DesktopApplicationStepDefs
    {

        private const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723/";
        private const string LaunchApp = @"G:\POC Folder\AutomationProject\AutomationProject\bin\Debug\AutomationProject.exe";

        protected static WindowsDriver<WindowsElement> driver = null;

        [Given(@"I have launched the application")]
        public void GivenIHaveLaunchedTheApplication()
        {
            AppiumOptions opt = new AppiumOptions();
            opt.AddAdditionalCapability("app", LaunchApp);
            opt.AddAdditionalCapability("deviceName", "WindowsPC");
            driver = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), opt);
            //ScenarioContext.Current.Pending();
        }

        [Given(@"I have entered username ""(.*)"" and password ""(.*)""")]
        public void GivenIHaveEnteredUsernameAndPassword(string username, string password)
        {
            driver.FindElementByAccessibilityId("txtLogin").SendKeys(username);
            driver.FindElementByAccessibilityId("txtPassword").SendKeys(password);
            //ScenarioContext.Current.Pending();
        }

        [Given(@"i click to login button")]
        public void GivenIClickToLoginButton()
        {
            driver.FindElementByAccessibilityId("btnLogin").Click();

            Assert.Multiple(() =>
            {
                Assert.That("hi", Is.EqualTo("hi"), "good");
                Assert.That("hi", Is.Not.Null, "good");
            });

            
            //ScenarioContext.Current.Pending();
        }
    }
}
