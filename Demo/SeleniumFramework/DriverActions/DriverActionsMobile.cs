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
            appiumOpts.DeviceName = "Pixel 3a";
            appiumOpts.AutomationName = "UiAutomator2";//Driver for automation
            appiumOpts.AddAdditionalAppiumOption("appium:includePyramidElementTree", true);
            appiumOpts.AddAdditionalAppiumOption("appium:enableMultiWindows", true);
            appiumOpts.AddAdditionalAppiumOption("appium:ensureWebviewsHavePages", true);
            appiumOpts.AddAdditionalAppiumOption("appium:noSign", true);
            appiumOpts.AddAdditionalAppiumOption("appium:appPackage", "com.bitrix24.android");
            appiumOpts.AddAdditionalAppiumOption("appium:appActivity", ".BX24Activity");
            appiumOpts.AddAdditionalAppiumOption("appium:nativeWebScreenshot", true);
            appiumOpts.AddAdditionalAppiumOption("appium:connectHardwareKeyboard", true);
            appiumOpts.App = "D:\\Downloads\\bitrix24_univer (1).apk";//Path to the application
            appiumOpts.AddAdditionalAppiumOption(MobileCapabilityType.Udid, "emulator-5554");//Unique device identifie
            appiumOpts.AddAdditionalAppiumOption(MobileCapabilityType.NoReset, true);//Do not reset application state
            appiumOpts.AddAdditionalAppiumOption(MobileCapabilityType.FullReset, false);//Perform full state reset
            appiumOpts.AddAdditionalAppiumOption(MobileCapabilityType.NewCommandTimeout, 3600);//Timeout for new command
            appiumOpts.AddAdditionalAppiumOption(AndroidMobileCapabilityType.AutoGrantPermissions, true);//Automatically confirm notifications
            var appiumHost = "http://127.0.0.1:4723";
            AppiumDriver driver = new AndroidDriver(new Uri($"{appiumHost}/"), appiumOpts);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }
    }
}
