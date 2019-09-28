using Feed.Domain.Component;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Feed.Controllers
{
    public class FeedController : Controller
    {
        [HttpGet]
        public Post[] Posts()
        {
            var post = Post
                .WithContent(ContentHolder
                                .Create()
                                .AddMessage(Message.WithText("some message")))
                .AddLike(PostReaction
                            .FromUserAtTime<PostLike>(FeedUser.WithName("Jony"), DateTime.Now))
                .AddDislike(PostReaction
                            .FromUserAtTime<PostDislike>(FeedUser.WithName("Alex"), DateTime.Now));

          return new[] {
                post
              };
        }
    }
}
