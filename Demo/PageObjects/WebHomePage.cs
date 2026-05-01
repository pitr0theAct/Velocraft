using Demo.BaseFramework;
using Demo.SeleniumFramework;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Input;
using OpenQA.Selenium.DevTools.V143.Emulation;
using OpenQA.Selenium.DevTools.V143.Page;
using OpenQA.Selenium.DevTools.V144.DOM;

namespace Demo.PageObjects
{
    public class WebHomePage
    {
        public IWebDriver Driver { get; }

        public WebHomePage(IWebDriver driver = default)
        {   
            Driver = driver;
        }

        public SiteLeftMenu SideMenu => new SiteLeftMenu(Driver);
    }
}
