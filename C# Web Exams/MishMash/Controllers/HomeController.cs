using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using MishMashExam.Models;
using MishMashExam.ViewModels.Home;
using SIS.HTTP.Responses;

namespace MishMashExam.Controllers
{
    public class HomeController:BaseController
    {
        public IHttpResponse Index()
        {
            if (this.User.IsLoggedIn)
            {
                var user = this.Db.Users.FirstOrDefault(x => x.Username == this.User.Username);
               var indexViewModel=new IndexViewModel();
                var followedChannels= this.Db.Channels.Where(x=>x.Followers.Any(y=>y.User.Username==user.Username)).Select(x => new BaseChannelViewModel
                {
                    Type = x.Type,
                    Id = x.Id,
                    Name = x.Name,
                    FollowersCount = x.Followers.Count
                }).ToList();


                var followedChannelsTags = this.Db.Channels.Where(
                        x => x.Followers.Any(f => f.User.Username == this.User.Username))
                    .SelectMany(x => x.Tags.Select(t => t.TagId)).ToList();

                indexViewModel.SuggestedChannels = this.Db.Channels.Where(
                        x => !x.Followers.Any(f => f.User.Username == this.User.Username) &&
                             x.Tags.Any(t => followedChannelsTags.Contains(t.TagId)))
                    .Select(x => new BaseChannelViewModel
                    {
                        Id = x.Id,
                        Type = x.Type,
                        Name = x.Name,
                        FollowersCount = x.Followers.Count(),
                    }).ToList();

                var ids = followedChannels.Select(x => x.Id).ToList();
                ids = ids.Concat(indexViewModel.SuggestedChannels.Select(x => x.Id)).ToList();
                ids = ids.Distinct().ToList();

                var seeOtherChannels = this.Db.Channels.Where(x => !ids.Contains(x.Id))
                    .Select(x => new BaseChannelViewModel
                    {
                        Id = x.Id,
                        Type = x.Type,
                        Name = x.Name,
                        FollowersCount = x.Followers.Count(),
                    }).ToList();
                indexViewModel.FollowedChannels = followedChannels;
               // indexViewModel.SuggestedChannels = indexViewModel;
                indexViewModel.SeeOther = seeOtherChannels;

                return this.View("/Home/LoggedInIndex",indexViewModel);
            }

            return this.View();
        }
    }
}
