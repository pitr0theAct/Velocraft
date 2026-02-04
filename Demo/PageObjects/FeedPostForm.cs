using Demo.BaseFramework;
using Demo.SeleniumFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Demo.PageObjects
{
    /// <summary>
    /// Форма добавления нового сообщения в ленту
    /// </summary>
    public class FeedPostForm
    {
        //фрейм котроый содержит текстовое поле
        WebItemWrap PostEditorFrame => new WebItemWrap("//iframe[@class='bx-editor-iframe']", "Фрейм редактирования поста");
        //body[@contenteditable='true'] - текстове поле
        WebItemWrap PostTextField => new WebItemWrap("//body[@contenteditable='true']", "Поле для написания текста поста");

        WebItemWrap SendPost => new WebItemWrap("//span[@id='blog-submit-button-save']", "Кнопка отправить в форме создания поста");


        public FeedPostForm(IWebDriver driver = default)
        {
            Driver = driver;
        }
        
        public IWebDriver Driver { get; }

        public bool IsRecipientPresent(string recipientName)
        {
            var recipientsArea = new WebItemWrap("//div[@id='entity-selector-oPostFormLHE" +
                "_blogPostForm']//div[@class='ui-tag-selector-items']",
                "Область получателей поста");
            bool isRecipientPresent = WaitersCore.WaitForConditionReached(() => recipientsArea.AssertTextContaining(recipientName, default, Driver), 2, 6,
                $"Ожидание появления '{recipientName}' " +
                $"в '{recipientsArea.Description}'");
            return isRecipientPresent;
        }

        public FeedPage CreatePost(string postText)
        {
            PostEditorFrame.SwitchToFrame(Driver);
            PostTextField.SendKeys(postText, Driver);
            //Перед нажатием на кнопку "отправить" нужно вернутся из фрейма
            PostTextField.SwitchToDefaultContent(Driver);
            SendPost.Click(Driver);
            return new FeedPage(Driver);
        }
    }
}
