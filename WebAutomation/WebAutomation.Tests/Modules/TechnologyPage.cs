using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WebAutomation.Core;
using WebAutomation.Core.Controls;

namespace WebAutomation.Tests.Modules
{
    public class TechnologyPage : Control
    {
        public TechnologyPage(IWebDriver driver) : base(driver)
        {
        }

        #region WebElements
        public IEnumerable<IWebElement> TechnologyType { get { return this.FindElementsByCssSelector("[class*='TreeMenu__TreeNodeWrapper'] a"); } }
        public IEnumerable<IWebElement> AddToCartBtn { get { return this.FindElementsByCssSelector("[class*='AddToCart__AddToCartButtonWrapper']"); } }
        public IEnumerable<IWebElement> ProductTitles { get { return this.FindElementsByCssSelector("[class*='ProductTile__ProductInfoWrapper'] a"); } }
        public IWebElement Header { get { return this.FindElementByCssSelector("[class*='PageHeader__Title']"); } }
        #endregion

        #region Helper Methods
        public void SelectTechnologyType(string technologyType)
        {
            Header.WaitUntilDisplayed(this.Driver, 10);
            var technology = TechnologyType.First(i => i.Text == technologyType);
            technology.MoveToElement(this.Driver);
            technology.Click();
        }

        public void AddToCart(int index)
        {
            AddToCartBtn.ElementAt(index).Click();
        }
        #endregion
    }
}
