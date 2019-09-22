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

        public async Task<IEnumerable<Comment>> FetchCommentAsync(FeedFetch<Guid> fetch) => await dataStore.LoadCommentsAsync(fetch);

        public async Task<IEnumerable<Post>> FetchPostAsync(FeedFetch<Guid> fetch) => await dataStore.LoadPostsAsync(fetch);
    }
}
