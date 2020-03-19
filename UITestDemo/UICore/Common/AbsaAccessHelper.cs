using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UICore.Common
{
    public static class AbsaAccessHelper
    {
        public static void Login(ChromeDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
            IClock clock = new SystemClock();
            var wait = new WebDriverWait(clock, driver, TimeSpan.FromSeconds(30), TimeSpan.FromSeconds(30));
            wait.Until(d => d.FindElement(By.CssSelector("button.btn")).Enabled.Equals(true));


            IWebElement username = driver.FindElementById("Username");
            IWebElement password = driver.FindElementById("Password");

            username.SendKeys("username");
            password.SendKeys("password");

            password.Submit();
        }

        public static void WaitForDashboard(ChromeDriver driver)
        {
            IClock clock = new SystemClock();
            var wait = new WebDriverWait(clock, driver, TimeSpan.FromSeconds(30), TimeSpan.FromSeconds(30));
            wait.Until(d => d.FindElement(By.ClassName("sol-jumbo__title")).Text.Equals("Your dashboard"));
        }

        public static bool IsTileAvailable(ChromeDriver driver, string tileName)
        {
            IReadOnlyCollection<IWebElement> tiles = driver.FindElementsByClassName("wgt-static__title-text");

            var isVisible = tiles.Any(x => x.Text.Equals(tileName));

            return isVisible;
        }

        public static void ClickOnTile(ChromeDriver driver, int elementIndex)
        {                        
            IReadOnlyCollection<IWebElement> buttons = driver.FindElementsByLinkText("Launch");

            var button = buttons.ElementAt(elementIndex);

            button.Click();
        }

        public static void BrowseToConnectedExperience(ChromeDriver driver, string url, string tileName, int elementIndex)
        {
            Login(driver, url);
            WaitForDashboard(driver);
            IsTileAvailable(driver, tileName);
            ClickOnTile(driver, elementIndex);
        }
    }
}
