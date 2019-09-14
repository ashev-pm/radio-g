using System;
using Utils;

namespace Feed.Domain.Model
{
    public class React
    {
        public FeedUser Reacted { get; protected set; }
        public DateTime Date { get; protected set; }

        private React(FeedUser user)
        {
            Reacted = user;
        }

        public static React From(FeedUser user) => new React(user);

        public React At(DateTime time)
        {
            Date = time;
            return this;
        }

        public PostLike IsPostLike() => new PostLike(Reacted, Date);
        public CommentLike IsCommentLike() => new CommentLike(Reacted, Date);
        public PostDislike IsPostDislike() => new PostDislike(Reacted, Date);
        public CommentDislike IsCommentDislike() => new CommentDislike(Reacted, Date);

    }

    public abstract class Reaction
    {
        public FeedUser Reacted { get; protected set; }
        public DateTime At { get; protected set; }
        protected Reaction(FeedUser reacted, DateTime at)
        {
            Reacted = reacted;
            At = at;
        }
    }

    public class PostLike : Reaction
    {
        public PostLike(FeedUser reacted, DateTime at) : base(reacted, at)
        {
        }
    }

    public class CommentLike : Reaction
    {
        public CommentLike(FeedUser reacted, DateTime at) : base(reacted, at)
        {
        }
    }

    public class PostDislike : Reaction
    {
        public PostDislike(FeedUser reacted, DateTime at) : base(reacted, at)
        {
        }
    }

    public class CommentDislike : Reaction
    {
        public CommentDislike(FeedUser reacted, DateTime at) : base(reacted, at)
        {
        }
    }
}
