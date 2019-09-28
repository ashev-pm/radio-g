using Feed.Domain.Component;
using Feed.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Feed.Domain.API
{
    public interface IFeedFetcher<TId>
    {
        Task<IEnumerable<Post>> FetchPostNewestAsync(FeedFetch<TId> fetch);
        Task<IEnumerable<Comment>> FetchCommentNewestAsync(FeedFetch<TId> fetch);

        Task<IEnumerable<Post>> FetchPostPopularAsync(FeedFetch<TId> fetch);
        Task<IEnumerable<Comment>> FetchCommentPopularAsync(FeedFetch<TId> fetch);

    }
}
