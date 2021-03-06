﻿using System;
using System.Collections.Generic;
using System.Text;
using MishMashExam.Models;
using MishMashWebApp.Models;

namespace MishMashExam.ViewModels.Channels
{
    public class ChannelDetailsInputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Tags { get; set; }

        public int FollowersCount { get; set; }

        public ChannelType Type { get; set; }
    }
}
