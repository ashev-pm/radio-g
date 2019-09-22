using Feed.Domain.Model.Abstract;

namespace Feed.Domain.Model
{
    public class FeedFetch<TId>
    {
        public enum ECategory
        {
            Newest = 1,
            Popular = 2
        }

        public int Step { get; set; }

        public ILoadable<TId> Latest { get; set; }

        public ECategory Category { get; set; }
    }
}
