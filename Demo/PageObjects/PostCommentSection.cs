


using OpenQA.Selenium;

namespace Demo.PageObjects
{
    public class PostCommentSection
    {
        public PostCommentSection FillCommentText(string Text)
        {
            return new PostCommentSection();
        }

        public FeedPage SendComment()
        {
            return new FeedPage();
        }

        public PostCommentSection CommentReply()
        {
            return new PostCommentSection();
        }
    }
}
