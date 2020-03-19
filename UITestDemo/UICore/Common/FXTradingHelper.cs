using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace UICore.Common
{
    public static class FXTradingHelper
    {
        public static string IsRatesUp(ChromeDriver driver)
        {
            IClock clock = new SystemClock();
            var wait = new WebDriverWait(clock, driver, TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(60));
            wait.Until(d => d.FindElement(By.ClassName("selectedTenor")).Text.Length > 2);
            IWebElement rate = driver.FindElementByClassName("selectedRate");

            return rate.Text;
        }
    }
}
