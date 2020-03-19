using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using UICore.Common;

namespace UITest
{
    [TestClass]
    public class AbsaAccessUITests
    {
        [TestMethod]
        public void RatesAreAvailableOnTheFrontend()
        {
            using (var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                string url = "url";

                AbsaAccessHelper.Login(driver, url);

                AbsaAccessHelper.WaitForDashboard(driver);

                string tileName = "FX Trading";
                var isVisible = AbsaAccessHelper.IsTileAvailable(driver, tileName);

                Assert.IsTrue(isVisible, $"{tileName} is not available. Check to make sure user has this tile");
            }
        }
    }
}
