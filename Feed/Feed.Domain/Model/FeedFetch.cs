using Feed.Domain.Model.Abstract;

namespace Feed.Domain.Model
{
    public class FeedFetch<TId>
    {
        public int Step { get; set; }

        public ILoadable<TId> Latest { get; set; }
    }
}
