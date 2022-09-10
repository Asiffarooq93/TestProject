using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe");
            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability("app", @"C:\Users\Asif\Desktop\WPFApp\WPFTestApplication.exe");
            options.AddAdditionalCapability("DeviceName", "WindowsPC");
            var Driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
            var LoadEnscapeButton = Driver.FindElementByAccessibilityId("EnscapeWin");
            Driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
            LoadEnscapeButton.Click();
            Driver.SwitchTo().Window(Driver.WindowHandles.First());
            var TextBox = Driver.FindElementByClassName("TextBox");
            TextBox.Click();
            TextBox.SendKeys("Enscape");
            var AddNameButton = Driver.FindElementByAccessibilityId("btnAdd");
            AddNameButton.Click();
            TextBox.Click();
            TextBox.SendKeys("Chaos");
            AddNameButton.Click();
            Thread.Sleep(1000);
            var RemoveNameButton = Driver.FindElementByAccessibilityId("btnRemove");
            RemoveNameButton.Click();
            Thread.Sleep(1000);
            RemoveNameButton.Click();
            var EnscapeWindow = Driver.FindElementByAccessibilityId("EnscapeWindow");
            EnscapeWindow.FindElementByName("Close").Click();
            Thread.Sleep(1000);
            Driver.SwitchTo().Window(Driver.WindowHandles.First());
            var MainWindow = Driver.FindElementByAccessibilityId("TestApp");
            MainWindow.FindElementByName("Close").Click();
            
            
        }
    }
}