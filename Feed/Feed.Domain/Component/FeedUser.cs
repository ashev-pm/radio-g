using System.Collections.Generic;

namespace Feed.Domain.Component
{
    public struct FeedUser
    {
        public static FeedUser WithName(string name) => new FeedUser(name);
        public static FeedUser WithNameAndImage(string name, string image) => new FeedUser(name, image);

        private FeedUser(string name, string image)
        {
            Name = name;
            Image = image;
        }

        private FeedUser(string name)
        {
            Name = name;
            Image = string.Empty;
        }

        public string Name { get; }
        public string Image { get; }

        public override bool Equals(object obj)
        {
            return obj is FeedUser user &&
                   Name == user.Name &&
                   Image == user.Image;
        }

        public override int GetHashCode()
        {
            var hashCode = 2033062288;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Image);
            return hashCode;
        }
    }
}
