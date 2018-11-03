using System;
using System.Collections.Generic;
using System.Text;
using MishMashExam.Models;
using MishMashWebApp.Models;

namespace MishMashExam.ViewModels.Channels
{
    public class CreateChannelInputModel
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public string Tags { get; set; }

        public virtual ICollection<UserInChannel> Followers { get; set; } = new List<UserInChannel>();

        public string Type { get; set; }
    }
}
