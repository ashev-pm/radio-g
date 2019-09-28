using Xunit;
using Feed.Domain.Component;
using System;
using System.Linq;

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
                 .AddLike(PostReaction.FromUserAtTime<PostLike>(new FeedUser(), DateTime.UtcNow))
                 .AddDislike(PostReaction.FromUserAtTime<PostDislike>(new FeedUser(), DateTime.UtcNow))
                 .AddDislike(PostReaction.FromUserAtTime<PostDislike>(new FeedUser(), DateTime.UtcNow));

            Assert.Single(post.Likes);
            Assert.Equal(2, post.Dislikes.Count());
        }
    }
}
