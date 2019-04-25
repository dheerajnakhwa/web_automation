using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using WebAutomation.Core;

namespace WebAutomation.Tests.Framework
{
    public class BaseTest
    {
        private Control _webControl;
        public IWebDriver Driver { get; set; }
        public string TestName;

        private TestContext testContextInstance;

        /// <summary>
        ///  Gets or sets the test context which provides
        ///  information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
        public Control Control
        {
            get
            {
                var isnewBrowser = this._webControl != null ? this._webControl.Driver != this.Driver : true;
                if (isnewBrowser)
                {
                    this._webControl = new Control(this.Driver);
                    this.Control.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                }
                return this._webControl;
            }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            TestName = string.Format("{0}\\{1}.txt", Directory.GetCurrentDirectory() ,TestContext.TestName);
            if (File.Exists(TestName))
                File.Delete(TestName);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.Driver.Quit();
            this.Driver.Dispose();
            this.testContextInstance.AddResultFile(TestName);
        }

        public void AddOutputText(string message)
        {
            using (var sw = new StreamWriter(TestName, true))
            {
                sw.WriteLine(message);
            }
        }

        public void StartDriver()
        {
            if (Driver == null)
            {
                var driverPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("no-sandbox");
                chromeOptions.AddAdditionalCapability("useAutomationExtension", false);
                Driver = new ChromeDriver(driverPath, chromeOptions, TimeSpan.FromSeconds(30));
            }
            else
            {
                Driver.Quit();
                Driver = null;
                StartDriver();
            }
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //sets global implicit wait
            Driver.Manage().Window.Maximize();
        }
    }
}
