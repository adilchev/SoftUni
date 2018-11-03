using System;
using System.Collections.Generic;
using System.Text;
using MishMashExam.Models;
using MishMashWebApp.Models;

namespace MishMashExam.ViewModels.Home
{
    public class BaseChannelViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int FollowersCount { get; set; }
        public ChannelType Type { get; set; }
    }
}
