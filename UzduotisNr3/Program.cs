using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;

namespace UzduotisNr3
{
    class Program
    {
        static void Main() //test 1
        {
            Random rnd = new Random();
            int skaicius = rnd.Next(1, 1000000);
            IWebDriver driver = new ChromeDriver(@"C:\Users\Lukas\Desktop\ChromeDriver");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver.FindElement(By.XPath("//*[@id=\"header\"]/div[2]/div/div/nav/div[1]/a")).Click();
            driver.FindElement(By.XPath("//*[@id=\"email_create\"]")).SendKeys("antanasantanas" + skaicius + "@gmail.com");
            driver.FindElement(By.XPath("//button[@id='SubmitCreate']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
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
            Test3();
            Test4();
            Test5();

            //ctrl shift /
        }

        static void Test2()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\Lukas\Desktop\ChromeDriver");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=my-account");
            driver.FindElement(By.Id("email")).SendKeys("antanasantanas123@gmail.com");
            driver.FindElement(By.Id("passwd")).SendKeys("antanas123");
            driver.FindElement(By.XPath("//button[@id='SubmitLogin']")).Click();

            string teisingas = "Antanas Antanavicius";
            string test = driver.FindElement(By.XPath("//*[@id=\"header\"]/div[2]/div/div/nav/div[1]/a/span")).Text;

            Assert.AreEqual(teisingas, test);

            driver.Quit();

        }

        static void Test3()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\Lukas\Desktop\ChromeDriver");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            Actions action = new Actions(driver);
            Actions action1 = new Actions(driver);
            IWebElement we = driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[2]/div/div[1]/ul[1]/li[1]/div/div[2]/h5/a"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            action.MoveToElement(we).MoveToElement(driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[2]/div/div[1]/ul[1]/li[1]/div/div[2]/div[2]/a[1]/span"))).Click().Build().Perform();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[3]/div/div/div[4]/div[1]/div[2]/div[4]/span/span")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IWebElement wee = driver.FindElement(By.XPath("//*[@id=\"homefeatured\"]/li[5]/div/div[1]/div/a[1]/img"));
            action1.MoveToElement(wee).MoveToElement(driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[2]/div/div[1]/ul[1]/li[5]/div/div[2]/div[2]/a[1]/span"))).Click().Build().Perform();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[3]/div/div/div[4]/div[1]/div[2]/div[4]/a/span")).Click();

            string teisingas = "$47.49";
            string test = driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div[2]/table/tfoot/tr[7]/td[2]/span")).Text;
            Assert.AreEqual(teisingas, test);
            Console.WriteLine(test);
            driver.Quit();

            IWebDriver driver1 = new ChromeDriver(@"C:\Users\Lukas\Desktop\ChromeDriver");
            driver1.Manage().Window.Maximize();
            driver1.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=my-account");
            driver1.FindElement(By.Id("email")).SendKeys("antanasantanas123@gmail.com");
            driver1.FindElement(By.Id("passwd")).SendKeys("antanas123");
            driver1.FindElement(By.XPath("//button[@id='SubmitLogin']")).Click();
            driver1.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver1.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Actions action2 = new Actions(driver1);
            Actions action3 = new Actions(driver1);
            IWebElement we1 = driver1.FindElement(By.XPath("/html/body/div/div[2]/div/div[2]/div/div[1]/ul[1]/li[1]/div/div[2]/h5/a"));
            driver1.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            action2.MoveToElement(we1).MoveToElement(driver1.FindElement(By.XPath("/html/body/div/div[2]/div/div[2]/div/div[1]/ul[1]/li[1]/div/div[2]/div[2]/a[1]/span"))).Click().Build().Perform();
            driver1.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver1.FindElement(By.XPath("/html/body/div/div[1]/header/div[3]/div/div/div[4]/div[1]/div[2]/div[4]/span/span")).Click();
            driver1.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IWebElement wee1 = driver1.FindElement(By.XPath("//*[@id=\"homefeatured\"]/li[5]/div/div[1]/div/a[1]/img"));
            action3.MoveToElement(wee1).MoveToElement(driver1.FindElement(By.XPath("/html/body/div/div[2]/div/div[2]/div/div[1]/ul[1]/li[5]/div/div[2]/div[2]/a[1]/span"))).Click().Build().Perform();
            driver1.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver1.FindElement(By.XPath("/html/body/div/div[1]/header/div[3]/div/div/div[4]/div[1]/div[2]/div[4]/a/span")).Click();

            Assert.AreEqual(teisingas, test);
            Console.WriteLine(test);
            driver1.Quit();
        }

        static void Test4()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\Lukas\Desktop\ChromeDriver");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver.FindElement(By.LinkText("Women")).Click();
            driver.FindElement(By.Id("layered_category_8")).Click();
            driver.FindElement(By.Id("layered_id_attribute_group_1")).Click();
            driver.FindElement(By.Id("layered_id_attribute_group_11")).Click();

            IWebElement checkBox1 = driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div[1]/div[2]/div[1]/form/div/div[1]/ul/li[2]/div/span/input"));
            IWebElement checkBox2 = driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div[1]/div[2]/div[1]/form/div/div[2]/ul/li[1]/div/span/input"));
            IWebElement checkBox3 = driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div[1]/div[2]/div[1]/form/div/div[3]/ul/li[3]/input"));
            bool checkBox1bool = false;
            bool checkBox2bool = false;
            //bool checkBox3bool = false;


            if (checkBox1.Selected)
            {
                Console.WriteLine("Dresses is checked");
                checkBox1bool = true;
            }
            else
            {
                Console.WriteLine("Dresses not checked");
                driver.FindElement(By.Id("layered_id_attribute_group_1")).Click();
                checkBox1bool = false;
            }
                
            if (checkBox2.Selected)
            {
                Console.WriteLine("Size S is checked");
                checkBox2bool = true;
            }
            else
            {
                Console.WriteLine("Size S is not checked");
                driver.FindElement(By.Id("layered_id_attribute_group_1")).Click();
                checkBox2bool = false;
            }
                

            if (checkBox3.Selected)
            {
                Console.WriteLine("Black color is selected");
            }
            else
            {
                Console.WriteLine("Black color not selected");
                driver.FindElement(By.Id("layered_id_attribute_group_11")).Click();
            }
            //Thread.Sleep(1000);
            Assert.IsTrue(checkBox1bool);
            Assert.IsTrue(checkBox2bool);
            driver.Quit();
        }

        static void Test5()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\Lukas\Desktop\ChromeDriver");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver.FindElement(By.XPath("//*[@id=\"block_various_links_footer\"]/ul/li[5]/a")).Click();
            driver.FindElement(By.Id("id_contact")).Click();
            new SelectElement(driver.FindElement(By.Id("id_contact"))).SelectByIndex(1);
            driver.FindElement(By.Id("email")).SendKeys("antanasantanas123@gmail.com");
            driver.FindElement(By.Id("id_order")).SendKeys("Testing");
            WebElement uploadElement = (WebElement)driver.FindElement(By.Id("fileUpload"));
            uploadElement.SendKeys("C:\\Users\\Lukas\\Desktop\\test.PNG");
            //driver.FindElement(By.Id("fileUpload")).Click();
            driver.FindElement(By.Id("message")).SendKeys("This is for testing purposes");
            driver.FindElement(By.XPath("//*[@id=\"submitMessage\"]")).Click();

            string teisingas = "Your message has been successfully sent to our team.";
            string test = driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/p")).Text;

            Assert.AreEqual(teisingas, test);
            driver.Quit();
        }

        static void Test6()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\Lukas\Desktop\ChromeDriver");
            driver.Manage().Window.Maximize();
        }

        static void Test7()
        {
            IWebDriver driver = new ChromeDriver(@"C:\Users\Lukas\Desktop\ChromeDriver");
            driver.Manage().Window.Maximize();
        }
    }
}
