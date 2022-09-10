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
            System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe"); // Starts Windows Application Driver
            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability("app", @"C:\Users\Asif\Desktop\WPFApp\WPFTestApplication.exe"); // Points towards the .exe of the application you want to automate
            options.AddAdditionalCapability("DeviceName", "WindowsPC");
            var Driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
            var LoadEnscapeButton = Driver.FindElementByAccessibilityId("EnscapeWin"); // Finding button to spawn a new window
            Driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
            LoadEnscapeButton.Click();
            Driver.SwitchTo().Window(Driver.WindowHandles.First()); // Switching to the latest window after a new window is spawned
            var TextBox = Driver.FindElementByClassName("TextBox"); // Find the text box 
            TextBox.Click();
            TextBox.SendKeys("Enscape"); // Typing words in the text box
            var AddNameButton = Driver.FindElementByAccessibilityId("btnAdd"); // Finding button to add names 
            AddNameButton.Click();
            TextBox.Click();
            TextBox.SendKeys("Chaos");
            AddNameButton.Click();
            Thread.Sleep(1000);
            var RemoveNameButton = Driver.FindElementByAccessibilityId("btnRemove"); // Finding button to remove names
            RemoveNameButton.Click();
            Thread.Sleep(1000);
            RemoveNameButton.Click();
            var EnscapeWindow = Driver.FindElementByAccessibilityId("EnscapeWindow");
            EnscapeWindow.FindElementByName("Close").Click(); // Closing the child window
            Thread.Sleep(1000);
            Driver.SwitchTo().Window(Driver.WindowHandles.First()); // Switching to latest window after closing the child window
            var MainWindow = Driver.FindElementByAccessibilityId("TestApp");
            MainWindow.FindElementByName("Close").Click();
            
            
        }
    }
}
