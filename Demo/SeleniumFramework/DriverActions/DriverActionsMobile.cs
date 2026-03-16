using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;

namespace Demo.SeleniumFramework.DriverActions
{
    public class DriverActionsMobile : DriverActionsBase
    {
        /// <summary>
        /// Creates a configured mobile driver object
        /// </summary>
        /// <returns></returns>
        public static AppiumDriver CreateNewMobileDriver()
        {
            var appiumOpts = new AppiumOptions();
            appiumOpts.PlatformName = "Android";
            appiumOpts.DeviceName = "Pixel_3a_API_36_extension_level_19_x86_64";
            appiumOpts.AutomationName = "UiAutomator2";//Driver for automation
            appiumOpts.AddAdditionalAppiumOption("appium:includePyramidElementTree", true);
            appiumOpts.AddAdditionalAppiumOption("appium:enableMultiWindows", true);
            appiumOpts.AddAdditionalAppiumOption("appium:ensureWebviewsHavePages", true);
            appiumOpts.App = "D:\\Downloads\\bitrix24_univer (1).apk";//Path to the application
            appiumOpts.AddAdditionalAppiumOption(MobileCapabilityType.Udid, "emulator-5554");//Unique device identifier
            appiumOpts.AddAdditionalAppiumOption(MobileCapabilityType.NoReset, false);//Do not reset application state
            appiumOpts.AddAdditionalAppiumOption(MobileCapabilityType.FullReset, false);//Perform full state reset
            appiumOpts.AddAdditionalAppiumOption(MobileCapabilityType.NewCommandTimeout, 60);//Timeout for new command
            appiumOpts.AddAdditionalAppiumOption(AndroidMobileCapabilityType.AutoGrantPermissions, true);//Automatically confirm notifications
            var appiumHost = "http://127.0.0.1:4723";
            AppiumDriver driver = new AndroidDriver(new Uri($"{appiumHost}/"), appiumOpts);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }
    }
}
