using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using WebAutomation.Core;
using WebAutomation.Core.Controls;

namespace WebAutomation.Tests.Modules
{
    public class HomePage : Control
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        #region WebElements
        internal IEnumerable<IWebElement> NavigationMenu { get { return this.FindElementsByCssSelector("[class*='NavTiles__Tile']"); } }
        internal IWebElement LoginId { get { return this.FindElementByName("loginId"); } }
        internal IWebElement Password { get { return this.FindElementByName("password"); } }
        internal IEnumerable<IWebElement> MegaMenu { get { return this.FindElementsByCssSelector("[class*='MegaMenu__MenuItem']"); } }
        internal IEnumerable<IWebElement> CartItems { get { return this.FindElementsByCssSelector("[class*='MiniCart__StyledTitle']"); } }
        #endregion

        #region Helper Methods
        public void SelectNavigationMenu(string menu)
        {
            NavigationMenu.First(i => i.Text.Contains(menu)).Click();
        }

        public void EnterLoginDetails(string loginId,string password)
        {
            LoginId.SendKeys(loginId);
            Password.SendKeys(password);
            Password.Submit();
            Password.WaitUntilNotDisplayed(this.Driver);
        }

        public void SelectMegaMenu(string megaMenu)
        {
            MegaMenu.First(i => i.Text == megaMenu).Click();
        }
        #endregion
    }
}
