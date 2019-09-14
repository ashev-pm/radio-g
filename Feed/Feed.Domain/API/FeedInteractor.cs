using Feed.Domain.Model;
using System.Threading.Tasks;

namespace Feed.Domain.API
{
    public interface FeedInteractive
    {
        Task AddPost(Post post);
    }
}
