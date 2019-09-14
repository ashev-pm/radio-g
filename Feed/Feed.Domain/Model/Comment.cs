using System.Collections.Generic;

namespace Feed.Domain.Model
{
    public class Reply : Comment {
    
        protected Reply(ContentHolder content) : base(content) { }
        public new static Reply WithContent(ContentHolder content) => new Reply(content);
    }

    public class Comment
    {
        public IEnumerable<Reply> Replies { get; private set; }

        public ContentHolder Content { get; private set; }

        public IEnumerable<CommentLike> Likes { get; private set; }

        public IEnumerable<CommentDislike> Dislikes { get; private set; }

        public FeedUser Commentator { get; set; }

        protected Comment(ContentHolder content)
        {
            Content = content;
        }

        protected Comment(ContentHolder content, IEnumerable<CommentLike> likes)
        {
            Content = content;
            Likes = likes;
        }

        protected Comment(ContentHolder content, IEnumerable<CommentLike> likes, IEnumerable<Reply> replies)
        {
            Content = content;
            Likes = likes;
            Replies = replies;
        }

        public static Comment WithContent(ContentHolder content) => new Comment(content);
    }
}
