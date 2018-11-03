﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MishMashExam.Models
{
    public class Tag
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ChannelTag>  Channels{ get; set; }
    }
}
