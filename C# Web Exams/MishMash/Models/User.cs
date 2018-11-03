using System;
using System.Collections.Generic;
using System.Text;
using MishMashWebApp.Models;

namespace MishMashExam.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public virtual ICollection<UserInChannel> Channels { get; set; }=new List<UserInChannel>();

        public UserRole Role { get; set; }
    }
}
