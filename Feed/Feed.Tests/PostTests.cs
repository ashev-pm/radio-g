using Xunit;
using Feed.Domain.Model;
using System;

namespace Feed.Tests
{
    public class FeedInteractiveTest
    {
        [Fact]
        public void Create_Post_With_OneMessage_And_OneImage()
        {
            var post = Post.WithContent(ContentHolder.Create()
                 .AddMessage(new Message())
                 .AddImage(new Image()));

            Assert.Single(post.Content.GetContentOf<Message>());
            Assert.Single(post.Content.GetContentOf<Image>());
        }

        [Fact]
        public void Create_Post_With_OneLike_And_TwoDislikes()
        {
            var post = Post.WithContent(ContentHolder.Create()
                 .AddMessage(new Message())
                 .AddImage(new Image()))
                 .AddLike(React.From(new FeedUser()).At(DateTime.UtcNow).IsPostLike());

        }
    }
}
