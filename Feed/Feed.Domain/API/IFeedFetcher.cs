using Feed.Domain.Component;
using Feed.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Feed.Domain.API
{
    public interface IFeedFetcher<TId>
    {
        Task<IEnumerable<Post>> FetchPostAsync(FeedFetch<TId> fetch);
        Task<IEnumerable<Comment>> FetchCommentAsync(FeedFetch<TId> fetch);
    }
}
