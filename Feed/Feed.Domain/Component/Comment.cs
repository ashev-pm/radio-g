using Feed.Domain.API;
using Feed.Domain.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utils;

namespace Feed.Domain.Component
{
    public class Reply
    {
        public FeedUser ReplyTo { get; }
        public Comment Topic { get; }
        public Comment Comment { get; }

        protected Reply(ContentHolder content, DateTime at, FeedUser replyTo, Comment topic)
        {
            Comment = Comment.WithContentAt(content, at);
            ReplyTo = replyTo;
            Topic = topic;
        }

        public class Builder
        {
            private ContentHolder content;
            private DateTime at;
            private FeedUser to;
            private Comment topic;

            public Builder WithContent(ContentHolder content)
            {
                this.content = content;
                return this;
            }

            public Builder AtTime(DateTime at)
            {
                this.at = at;
                return this;
            }

            public Builder ToUser(FeedUser user)
            {
                this.to = user;
                return this;
            }

            public Builder UnderComment(Comment topic)
            {
                this.topic = topic;
                return this;
            }

            public Reply Create() => new Reply(content, at, to, topic);
        }
    }    

    public class Comment : ILoadable<Guid>, IEquatable<Comment>
    {
        public Guid Id { get; private set; }
        public DateTime CreateAt { get; private set; }
        public FeedUser Commentator { get; private set; }
        public ContentHolder Content { get; private set; }
        public ILoadable<Guid> Topic { get; private set; }

        public IEnumerable<CommentLike> Likes => maybeLikes.Reduce(Array.Empty<CommentLike>);
        private Option<IEnumerable<CommentLike>> maybeLikes;

        public IEnumerable<CommentDislike> Dislikes => maybeDislikes.Reduce(Array.Empty<CommentDislike>);
        private Option<IEnumerable<CommentDislike>> maybeDislikes;

        protected Comment(ContentHolder content, DateTime at)
        {
            Content = content;
            CreateAt = at;
        }

        protected Comment(ContentHolder content, DateTime at, CommentLike[] likes) : this(content, at)
        {
            maybeLikes = likes;
        }

        public static Comment WithContentAt(ContentHolder content, DateTime at) => new Comment(content, at);

        public Comment AddDislike(CommentDislike postDislike)
        {
            maybeDislikes = maybeDislikes.AppendUnique(postDislike);
            return this;
        }

        public Comment AddLike(CommentLike like)
        {
            maybeLikes = maybeLikes.AppendUnique(like);
            return this;
        }

        public async Task<Either<string, Guid>> SaveAsync(IFeedDataStore<Guid> dataStore)
           => await dataStore.SaveCommentAsync(this);

        public bool Equals(Comment other)
        {
            return this.Id == other.Id;
        }
    }
}
