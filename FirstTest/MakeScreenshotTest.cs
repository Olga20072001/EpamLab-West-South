using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace FirstTest
{
    [TestClass]
    public class MakeScreenshotTest
    {
        [TestMethod]
        public void MakeScreenshot()
        {
            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Window.Maximize();
            try
            {
                driver.Navigate().GoToUrl("https://www.google.com.ua/");
                driver.FindElement(By.XPath("//input[@name='q']")).SendKeys("butterfly" + Keys.Enter);
                IWebElement imageButton = wait.Until(e => e.FindElement(By.XPath("//a[contains(text(),'Зображення')]")));
                imageButton.Click();
                IList<IWebElement> elements = wait.Until(e => e.FindElements(By.XPath("//img[@class='rg_i Q4LuWd']")));
                IWebElement webElement = elements[5];
                webElement.Click();
                Screenshot screenshot = (driver as ITakesScreenshot).GetScreenshot();
                screenshot.SaveAsFile("screenshot.png", ScreenshotImageFormat.Png);
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
