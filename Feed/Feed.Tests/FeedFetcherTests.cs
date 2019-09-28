using Feed.Domain.API;
using Feed.Domain.APIVariant;
using Feed.Domain.Component;
using System;
using System.Linq;
using System.Threading.Tasks;
using Utils;
using Xunit;

namespace Feed.Tests
{
    public class FeedFetcherTests
    {
        [Fact]
        public async Task Post_Saved_With_Three_Likes()
        {
            IFeedDataStore<Guid> dataStore = new FeedDataStore();
            var firstLikeTime = new DateTime(2019, 09, 22, 20, 57, 0);
            var secondLikeTime = new DateTime(2019, 09, 22, 21, 57, 0);
            var thirdLikeTime = new DateTime(2019, 09, 22, 21, 35, 0);

            var id = (await Post.WithContent(ContentHolder.Create())
                .AddLikes(new[]{
                    PostReaction.FromUserAtTime<PostLike>(FeedUser.WithName("John"), firstLikeTime),
                    PostReaction.FromUserAtTime<PostLike>(FeedUser.WithName("Wu"), secondLikeTime),
                    PostReaction.FromUserAtTime<PostLike>(FeedUser.WithName("Rajish"), thirdLikeTime)
                })
                .SaveAsync(dataStore)).Reduce(error => Guid.Empty);

            var post = (await dataStore.LoadPostAsync(id)).Reduce(error => Post.Empty);

            Assert.Equal(3, post.Likes.Count());
           

        }
    }
}
