
using TextCopy;
namespace Demo.BaseFramework
{
    /// <summary>
    /// Для взаимодействия с буфером обмена
    /// </summary>
    public class ClipboardWrapper
    {
        /// <summary>
        /// Отдаёт текущий текст в буфере обмена
        /// </summary>
        /// <returns></returns>
        public static string GetText()
        {
            return ClipboardService.GetText();
        }
    }
}