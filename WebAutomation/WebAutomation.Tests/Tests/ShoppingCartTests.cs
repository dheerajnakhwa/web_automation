using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAutomation.Tests.Framework;
using WebAutomation.Tests.Modules;
using WebAutomation.Tests.Helper;

namespace WebAutomation.Tests
{
    [TestClass]
    public class ShoppingCartTests : BaseTest
    {

        [TestMethod]
        public void AddIPhonesToShoppingCart()
        {
            //Arrange
            var loginId = string.Empty;
            var password = string.Empty;
            var technology = string.Empty;
            var devices = string.Empty;
            ExcelHelper.GetExcelData(out loginId, out password, out technology, out devices);

            //Act
            StartDriver();
            this.Driver.Navigate().GoToUrl(ConfigurationHelper.SiteUrl);
            var homePage = new HomePage(this.Driver);
            homePage.SelectNavigationMenu("Login");
            homePage.EnterLoginDetails(loginId, password);
            homePage.SelectMegaMenu("Technology");
            var technologyPage = new TechnologyPage(this.Driver);
            technologyPage.SelectTechnologyType(technology);
            technologyPage.SelectTechnologyType(devices);
            technologyPage.AddToCart(0);
            technologyPage.AddToCart(1);
            var expectedPhoneNames = technologyPage.ProductTitles.Take(2).Select(i => i.Text).ToList();
            AddOutputText("Phones Added " + string.Join(" ,", expectedPhoneNames));
            homePage.SelectNavigationMenu("Cart");
            var actualPhoneNames = homePage.CartItems.Select(i => i.Text).ToList();
            AddOutputText("Phones in Cart " + string.Join(", ", actualPhoneNames));

            //Assert
            CollectionAssert.AreEqual(expectedPhoneNames, actualPhoneNames);
        }
    }
}
