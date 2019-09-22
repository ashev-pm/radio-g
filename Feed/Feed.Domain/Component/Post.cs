using Feed.Domain.API;
using Feed.Domain.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utils;

namespace Feed.Domain.Component
{
    public class Post : ILoadable<Guid>
    {
        public Guid Id { get; private set; }

        public DateTime CreateAt { get; private set; }
        public FeedUser OriginalPoster { get; private set; }
        public ContentHolder Content { get; private set; }

        public IEnumerable<PostLike> Likes => maybeLikes.Reduce(Array.Empty<PostLike>);
        private Option<IEnumerable<PostLike>> maybeLikes;

        public IEnumerable<PostDislike> Dislikes => maybeDislikes.Reduce(Array.Empty<PostDislike>);

        public static Post Empty => new Post();

        private Option<IEnumerable<PostDislike>> maybeDislikes;


        protected Post(ContentHolder content)
        {
            Content = content;
        }

        protected Post()
        {
        }

        public static Post WithContent(ContentHolder content) => new Post(content);

        public Post AddDislike(PostDislike postDislike)
        {
            maybeDislikes = maybeDislikes.AppendUnique(postDislike);
            return this;
        }

        public Post AddDislikes(IEnumerable<PostDislike> postDislikes)
        {
            maybeDislikes = maybeDislikes.ConcatDistinct(postDislikes);
            return this;
        }

        public Post AddLike(PostLike like)
        {
            maybeLikes = maybeLikes.AppendUnique(like);
            return this;
        }

        public Post AddLikes(IEnumerable<PostLike> likes)
        {
            maybeLikes = maybeLikes.ConcatDistinct(likes);
            return this;
        }

        public async Task<Either<string, Guid>> SaveAsync(IFeedDataStore<Guid> dataStore)
            => await dataStore.SavePostAsync(this);
    }
}
