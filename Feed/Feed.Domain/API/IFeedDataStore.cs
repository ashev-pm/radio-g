using Feed.Domain.Component;
using Feed.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utils;

namespace Feed.Domain.API
{
    public interface IFeedDataStore<TId>
    {
        Task<Either<string, TId>> SavePostAsync(Post post);
        Task<Either<string, TId>> SaveCommentAsync(Comment post);

        Task<IEnumerable<Comment>> LoadCommentsAsync(FeedFetch<TId> fetch);
        Task<IEnumerable<Post>> LoadPostsAsync(FeedFetch<TId> fetch);

        Task<Either<string, Comment>> LoadCommentAsync(TId id);
        Task<Either<string, Post>> LoadPostAsync(TId id);
    }
}
