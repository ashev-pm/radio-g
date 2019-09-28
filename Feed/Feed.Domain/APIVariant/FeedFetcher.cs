using Feed.Domain.API;
using Feed.Domain.Component;
using Feed.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Feed.Domain.APIVariant
{
    public class FeedFetcher : IFeedFetcher<Guid>
    {
        private readonly IFeedDataStore<Guid> dataStore;

        public FeedFetcher(IFeedDataStore<Guid> dataStore)
        {
            this.dataStore = dataStore;
        }

        public async Task<IEnumerable<Comment>> FetchCommentNewestAsync(FeedFetch<Guid> fetch) => await dataStore.LoadNewestComments(fetch);

        public async Task<IEnumerable<Comment>> FetchCommentPopularAsync(FeedFetch<Guid> fetch) => await dataStore.LoadNewestComments(fetch);

        public async Task<IEnumerable<Post>> FetchPostNewestAsync(FeedFetch<Guid> fetch) => await dataStore.LoadNewestPosts(fetch);

        public async Task<IEnumerable<Post>> FetchPostPopularAsync(FeedFetch<Guid> fetch) => await dataStore.LoadPopularPosts(fetch);
    }
}
