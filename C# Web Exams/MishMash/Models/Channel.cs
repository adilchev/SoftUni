using System;
using System.Collections.Generic;
using System.Text;
using MishMashWebApp.Models;

namespace MishMashExam.Models
{
    public class Channel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<ChannelTag> Tags { get; set; }=new List<ChannelTag>();

        public virtual ICollection<UserInChannel> Followers { get; set; }=new List<UserInChannel>();

        public ChannelType Type { get; set; }
    }
}
