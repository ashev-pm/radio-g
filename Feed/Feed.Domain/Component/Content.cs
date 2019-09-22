using System;
using System.Collections.Generic;
using System.Linq;

namespace Feed.Domain.Component
{
    public abstract class Content { }

    public class Message : Content { }

    public class Image : Content { }

    public class Animation : Content { }

    public class ContentHolder : Content
    {
        private IEnumerable<Content> _content;

        protected ContentHolder(Content[] content) => _content = content;

        public ContentHolder AddMessage(Message content)
        {
            this._content = _content.Append(content);
            return this;
        }

        public ContentHolder AddImage(Image content)
        {
            this._content = _content.Append(content);
            return this;
        }

        public ContentHolder AddAnimation(Animation content)
        {
            this._content = _content.Append(content);
            return this;
        }

        public IEnumerable<TConent> GetContentOf<TConent>()
            where TConent : Content => _content.OfType<TConent>();

        public static ContentHolder Create() => new ContentHolder(Array.Empty<Content>());
    }
}
