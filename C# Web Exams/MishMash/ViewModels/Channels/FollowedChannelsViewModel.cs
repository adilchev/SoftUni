using System;
using System.Collections.Generic;
using System.Text;
using MishMashExam.ViewModels.Home;

namespace MishMashExam.ViewModels.Channels
{
    public class FollowedChannelsViewModel
    {
        public ICollection<BaseChannelViewModel> FollowedChannels { get; set; }
    }
}
