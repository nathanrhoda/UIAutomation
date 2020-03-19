using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using UICore.Common;

namespace UITest
{
    [TestClass]
    public class FXTradingUITests
    {
        [TestMethod]
        public void FxTrading_Rates_AreAvailable()
        {
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                string url = "https://absaaccess.co.za/";
                string tileName = "FX Trading";
                int elementIndex = 1;
                AbsaAccessHelper.BrowseToConnectedExperience(driver, url, tileName, elementIndex);
                var rateText = FXTradingHelper.IsRatesUp(driver);

                Assert.IsTrue(rateText.Length > 0, "Rates are not ticking");
            }
        }
    }
}
