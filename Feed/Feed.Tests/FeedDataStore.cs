using Feed.Domain.API;
using Feed.Domain.Component;
using Feed.Domain.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace Feed.Tests
{
    internal class FeedDataStore : IFeedDataStore<Guid>
    {
        public static ConcurrentDictionary<Guid, Post> Posts { get; } = new ConcurrentDictionary<Guid, Post>();

        public static ConcurrentDictionary<Guid, Comment> Comments { get; } = new ConcurrentDictionary<Guid, Comment>();

        public async Task<Either<string, Guid>> SavePostAsync(Post post)
        {
            if (Posts.TryUpdate(post.Id, post, post))
            {
                return await Task.FromResult(post.Id);
            }
            var guid = Guid.NewGuid();
            if (Posts.TryAdd(guid, post))
            {
                return await Task.FromResult(guid);
            }
            return await Task.FromResult("Value was not saved");
        }

        public async Task<Either<string, Guid>> SaveCommentAsync(Comment comment)
        {
            if (Comments.TryUpdate(comment.Id, comment, comment))
            {
                return await Task.FromResult(comment.Id);
            }
            var guid = Guid.NewGuid();
            if (Comments.TryAdd(guid, comment))
            {
                return await Task.FromResult(guid);
            }
            return await Task.FromResult("Value was not saved");
        }

        public Task<IEnumerable<Comment>> LoadCommentsAsync(FeedFetch<Guid> fetch)
            => fetch.Category == FeedFetch<Guid>.ECategory.Newest ?
            LoadNewsetComments(fetch) :
            LoadPopularComments(fetch);

        private async Task<IEnumerable<Comment>> LoadPopularComments(FeedFetch<Guid> fetch)
            => await Task.FromResult(
                Comments.TryGetValue(fetch.Latest.Id, out var latest) ?
                    Comments.Values
                    .OrderBy(x => x.Likes.Count())
                    .Where(x => x.Likes.Count() > latest.Likes.Count())
                    .Take(fetch.Step)
                    .ToArray() :
                    Array.Empty<Comment>()
            );

        private async Task<IEnumerable<Comment>> LoadNewsetComments(FeedFetch<Guid> fetch)
            => await Task.FromResult(
                    Comments.Values
                    .OrderBy(x => x.CreateAt)
                    .Where(x => x.CreateAt > fetch.Latest.CreateAt)
                    .Take(fetch.Step)
                );

        public Task<IEnumerable<Post>> LoadPostsAsync(FeedFetch<Guid> fetch)
            => fetch.Category == FeedFetch<Guid>.ECategory.Newest ?
            LoadNewsetPosts(fetch) :
            LoadPopularPosts(fetch);

        private async Task<IEnumerable<Post>> LoadPopularPosts(FeedFetch<Guid> fetch)
            => await Task.FromResult(
                Posts.TryGetValue(fetch.Latest.Id, out var latest) ?
                    Posts.Values
                    .OrderBy(x => x.Likes.Count())
                    .Where(x => x.Likes.Count() > latest.Likes.Count())
                    .Take(fetch.Step)
                    .ToArray() :
                    Array.Empty<Post>()
            );

        private async Task<IEnumerable<Post>> LoadNewsetPosts(FeedFetch<Guid> fetch)
            => await Task.FromResult(
                    Posts.Values
                    .OrderBy(x => x.CreateAt)
                    .Where(x => x.CreateAt > fetch.Latest.CreateAt)
                    .Take(fetch.Step)
                );

        public async Task<Either<string, Comment>> LoadCommentAsync(Guid id)
        {
            if (Comments.TryGetValue(id, out var comment))
                return await Task.FromResult(comment);
            return await Task.FromResult("Element nof found");
        }

        public async Task<Either<string, Post>> LoadPostAsync(Guid id)
        {
            if (Posts.TryGetValue(id, out var post))
                return await Task.FromResult(post);
            return await Task.FromResult("Element nof found");
        }
    }
}
