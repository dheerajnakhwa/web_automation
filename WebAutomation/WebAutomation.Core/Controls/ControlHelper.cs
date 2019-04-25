using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebAutomation.Core.Controls
{
    public static class ControlHelper
    {
        public static void MoveToElement(this IWebElement webElement,IWebDriver driver)
        {
            RetryIfStaleElementReferenceException<object>(() =>
            {
                var actions = new Actions(driver);
                actions.MoveToElement(webElement).Build().Perform();
                return null;
            });
        }

        public static void WaitUntilNotDisplayed(this IWebElement webElement,IWebDriver driver,int timeout=30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            var element = wait.Until(condition =>
            {
                try
                {
                    return !webElement.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return true;
                }
                catch (NoSuchElementException)
                {
                    return true;
                }
            });
        }
        public static void WaitUntilDisplayed(this IWebElement webElement, IWebDriver driver, int timeout = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            var element = wait.Until(condition =>
            {
                try
                {
                    return webElement.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        private static TReturn RetryIfStaleElementReferenceException<TReturn>(Func<TReturn> function)
        {
            var attempted = 0;
            while (true)
            {
                try
                {
                    attempted++;
                    return function.Invoke();
                }
                catch (StaleElementReferenceException)
                {
                    if (attempted > 1)
                    {
                        throw;
                    }
                    else
                    {
                        Console.WriteLine("Swallowed StaleElementReferenceException. Times attempted: {0}", attempted);
                    }
                }
            }
        }
    }
}
