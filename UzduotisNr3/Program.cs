using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace UzduotisNr3
{
    class Program
    {
        static void Main()
        {
            Random rnd = new Random();
            int skaicius = rnd.Next(1, 1000000);
            IWebDriver driver = new ChromeDriver(@"C:\Users\Lukas\Desktop\ChromeDriver");
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver.FindElement(By.XPath("//*[@id=\"header\"]/div[2]/div/div/nav/div[1]/a")).Click();
            driver.FindElement(By.XPath("//*[@id=\"email_create\"]")).SendKeys("antanasantanas"+ skaicius + "@gmail.com");
            driver.FindElement(By.XPath("//button[@id='SubmitCreate']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.Id("id_gender1")).Click();
            driver.FindElement(By.Id("customer_firstname")).SendKeys("Antanas");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("Antanavicius");
            driver.FindElement(By.Id("email")).Click();
            driver.FindElement(By.Id("passwd")).SendKeys("antanas123");
            driver.FindElement(By.Id("days")).Click();
            new SelectElement(driver.FindElement(By.Id("days"))).SelectByIndex(6);
            driver.FindElement(By.Id("months")).Click();
            new SelectElement(driver.FindElement(By.Id("months"))).SelectByIndex(8);
            driver.FindElement(By.Id("years")).Click();
            new SelectElement(driver.FindElement(By.Id("years"))).SelectByIndex(22);
            driver.FindElement(By.Id("address1")).SendKeys("Antano g. 45");
            driver.FindElement(By.Id("city")).SendKeys("Vilnius");
            driver.FindElement(By.Id("id_state")).Click();
            new SelectElement(driver.FindElement(By.Id("id_state"))).SelectByIndex(3);
            driver.FindElement(By.Id("postcode")).SendKeys("09128");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("862333333");
            driver.FindElement(By.XPath("//button[@id='submitAccount']")).Click();

            string teisingas = "Antanas Antanavicius";
            string test = driver.FindElement(By.XPath("//*[@id=\"header\"]/div[2]/div/div/nav/div[1]/a/span")).Text;

            Assert.AreEqual(teisingas, test);

            driver.Quit();

            Test2();
        }

        static void Test2()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\Lukas\Desktop\ChromeDriver");
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=my-account");
            driver.FindElement(By.Id("email")).SendKeys("antanasantanas123@gmail.com");
            driver.FindElement(By.Id("passwd")).SendKeys("antanas123");
            driver.FindElement(By.XPath("//button[@id='SubmitLogin']")).Click();

            string teisingas = "Antanas Antanavicius";
            string test = driver.FindElement(By.XPath("//*[@id=\"header\"]/div[2]/div/div/nav/div[1]/a/span")).Text;

            Assert.AreEqual(teisingas, test);

            driver.Quit();

        }
    }
}
