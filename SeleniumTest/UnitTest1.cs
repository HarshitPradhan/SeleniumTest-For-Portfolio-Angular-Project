using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("http://localhost:4200/");

                new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(
                    d => (IJavaScriptExecutor)d)
                    .ExecuteScript("return document.readyState").Equals("complete");
                ;
                var registerbutton = driver.FindElementById("test");
                Assert.IsNotNull(registerbutton);
                registerbutton.Click();

                var exampleInputText1 = driver.FindElementById("exampleInputText1");
                exampleInputText1.SendKeys("Harshit");

                
                var exampleInputEmail1 = driver.FindElementById("exampleInputEmail1");
                exampleInputEmail1.SendKeys("harshit344pradhan@gmail.com");


                var exampleInputPassword1 = driver.FindElementById("exampleInputPassword1");
                exampleInputPassword1.SendKeys("123456");

                var exampleInputPassword2 = driver.FindElementById("exampleInputPassword2");
                exampleInputPassword2.SendKeys("123456");


                var submitbutton = driver.FindElementByName("Register");
                submitbutton.Click();


                try
                {
                    var alert = driver.SwitchTo().Alert();
                    alert.Accept();
                    var home = driver.FindElementById("Home");
                    home.Click();
                }
                catch (NoAlertPresentException e)
                {
                    throw e;
                }
            }
        }
    }
}
