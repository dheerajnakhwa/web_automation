using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebAutomation.Core
{
    public class Control
    {
        public IWebDriver Driver { get; set; }

        public Control(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public IWebElement FindElementByClassName(string className)
        {
            return this.Driver.FindElement(By.ClassName(className));
        }

        public IWebElement FindElementById(string id)
        {
            return this.Driver.FindElement(By.Id(id));
        }

        public IWebElement FindElementByCssSelector(string cssSelector)
        {
            return this.Driver.FindElement(By.CssSelector(cssSelector));
        }

        public IWebElement FindElementByLinkText(string linkText)
        {
            return this.Driver.FindElement(By.LinkText(linkText));
        }

        public IWebElement FindElementByXPath(string xPath)
        {
            return this.Driver.FindElement(By.XPath(xPath));
        }

        public IEnumerable<IWebElement> FindElementsByCssSelector(string cssSelector)
        {
            return this.Driver.FindElements(By.CssSelector(cssSelector));
        }

        public IWebElement FindElementByName(string name)
        {
            return this.Driver.FindElement(By.Name(name));
        }

        public IEnumerable<IWebElement> FindElementsByClassName(string className)
        {
            return this.Driver.FindElements(By.ClassName(className));
        }

        public IEnumerable<IWebElement> FindElementsById(string id)
        {
            return this.Driver.FindElements(By.Id(id));
        }

        public IEnumerable<IWebElement> FindElementsByXPath(string xPath)
        {
            return this.Driver.FindElements(By.XPath(xPath));
        }
    }
}
