using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using MishMashExam.Models;
using MishMashExam.ViewModels.Channels;
using MishMashExam.ViewModels.Home;
using MishMashWebApp.Models;
using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace MishMashExam.Controllers
{
    public class ChannelsController:BaseController
    {

        [Authorize("Admin")]
        public IHttpResponse Create()
        {
            return this.View();
        }

        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse Create(CreateChannelInputModel model)
        {
            var tagsToSplit = model.Tags.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
          
            var typeAsEnum = Enum.TryParse(model.Type, out ChannelType result);
            if (!typeAsEnum)
            {
                return BadRequestError("No such type.");
            }
            var channel = new Channel()
            {
                Description = model.Description,
                Name = model.Name,
                Type = result
            };
            this.Db.Channels.Add(channel);
      
            foreach (var tag in tagsToSplit)
            {
                var dbTag = this.Db.Tags.FirstOrDefault(x => x.Name == tag.Trim());
                if (dbTag == null)
                {
                    dbTag = new Tag { Name = tag.Trim() };
                    this.Db.Tags.Add(dbTag);
                    this.Db.SaveChanges();
                }

                channel.Tags.Add(new ChannelTag
                {
                    TagId = dbTag.Id,
                });
            }
           
            this.Db.SaveChanges();
            return this.Redirect("/");
        }

        [Authorize]
        public IHttpResponse Follow(int id)
        {
            var channelToFollow = this.Db.Channels.FirstOrDefault(x => x.Id == id);
            if (channelToFollow==null)
            {
                return BadRequestError("No such channel");
            }

            var currentUser = this.Db.Users.FirstOrDefault(x => x.Username == this.User.Username);
            if (currentUser==null)
            {
                return BadRequestError("No such user");
            }
            currentUser.Channels.Add(new UserInChannel()
            {
                UserId = currentUser.Id,
                ChannelId = channelToFollow.Id
            });
            this.Db.SaveChanges();

            return this.Redirect("/");
        }

        [Authorize]
        public IHttpResponse Details(int id)
        {


        var channel = this.Db.Channels.Select(x => new ChannelDetailsInputModel()
        {
            Description = x.Description,
            Name = x.Name,
            Type = x.Type,
            Tags = string.Join(", ", x.Tags.Select(y=>y.Tag.Name)),
            FollowersCount = x.Followers.Count,
            Id = x.Id
        }).FirstOrDefault(x => x.Id == id);
       
            return this.View(channel);
        }

        [Authorize]
        public IHttpResponse Followed()
        {

            var channelViewModel = this.Db.Channels.Where(
                    x => x.Followers.Any(f => f.User.Username == this.User.Username))
                .Select(x => new BaseChannelViewModel
                {
                    Id = x.Id,
                    Type = x.Type,
                    Name = x.Name,
                    FollowersCount = x.Followers.Count(),
                }).ToList();

            var followedChannels=new FollowedChannelsViewModel()
            {
                FollowedChannels = channelViewModel
            };

            return this.View(followedChannels);
        }

        [Authorize]
        public IHttpResponse Unfollow(int id)
        {
            var user = this.Db.Users.FirstOrDefault(x => x.Username == this.User.Username);

            var userInChannel = this.Db.UserInChannel.FirstOrDefault(
                x => x.UserId == user.Id && x.ChannelId == id);
            if (userInChannel != null)
            {
                this.Db.UserInChannel.Remove(userInChannel);
                this.Db.SaveChanges();
            }

            return this.Redirect("/channels/followed");
        }
    }
}
