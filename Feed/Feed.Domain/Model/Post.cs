using Feed.Domain.Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Feed.Domain.Model
{
    public class Post : IAgregator
    {
        public Option<Guid> Id { get; private set; }

        public ContentHolder Content { get; private set; }

        public IEnumerable<Comment> Comments { get; private set; }

        public Option<IEnumerable<PostLike>> Likes { get; private set; }

        public IEnumerable<PostDislike> Dislikes { get; private set; }

        public DateTime Date { get; set; }

        public FeedUser OriginalPoster { get; set; }

        protected Post(ContentHolder content)
        {
            Content = content;
        }

        public static Post WithContent(ContentHolder content) => new Post(content);

        public Post AddComment(Comment comment)
        {
            Comments = Comments.Append(comment);
            return this;
        }

        public Post AddLike(PostLike like)
        {
            Likes = Likes
                .Reduce(Array.Empty<PostLike>)
                .Append(like)
                .ToArray();

            return this;
        }

        public string Save()
        {
            return $"Saved with id {Id.Reduce(Guid.NewGuid)}";
        }
    }
}
