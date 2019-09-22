using System;

namespace Feed.Domain.Model.Abstract
{
    public interface ILoadable<TId>        
    {
        TId Id { get; }
        
        DateTime CreateAt { get;}
    }
}
