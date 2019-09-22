using System;

namespace Feed.Domain.Component
{
    public abstract class PostReaction
    {
        public FeedUser From { get; private set; }
        public DateTime At { get; private set; }
        public static TReaction FromUserAtTime<TReaction>(FeedUser from, DateTime at)
            where TReaction : PostReaction, new()
        {
            var reaction = new TReaction
            {
                At = at,
                From = from
            };
            return reaction;
        }
    }

    public abstract class CommentReaction
    {
        public FeedUser From { get; private set; }
        public DateTime At { get; private set; }
        public static TReaction FromUserAtTime<TReaction>(FeedUser from, DateTime at)
            where TReaction : CommentReaction, new()
        {
            var reaction = new TReaction
            {
                At = at,
                From = from
            };
            return reaction;
        }
    }

    public class PostLike : PostReaction, IEquatable<PostLike>
    {
        public bool Equals(PostLike other) => this.From.Equals(other.From);
    }

    public class CommentLike : CommentReaction, IEquatable<CommentLike>
    {
        public bool Equals(CommentLike other) => this.From.Equals(other.From);
    }

    public class PostDislike : PostReaction, IEquatable<PostDislike>
    {
        public bool Equals(PostDislike other) => this.From.Equals(other.From);
    }

    public class CommentDislike : CommentReaction, IEquatable<CommentDislike>
    {
        public bool Equals(CommentDislike other) => this.From.Equals(other.From);
    }
}
