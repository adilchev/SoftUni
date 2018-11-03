using System;
using System.Collections.Generic;
using System.Text;

namespace MishMashExam.ViewModels.Home
{
    public class IndexViewModel
    {
        public ICollection<BaseChannelViewModel> FollowedChannels { get; set; }=new List<BaseChannelViewModel>();

        public ICollection<BaseChannelViewModel> SuggestedChannels { get; set; }=new List<BaseChannelViewModel>();

        public ICollection<BaseChannelViewModel> SeeOther { get; set; } = new List<BaseChannelViewModel>();
    }
}
