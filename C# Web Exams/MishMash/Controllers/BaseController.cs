using System;
using System.Collections.Generic;
using System.Text;
using MishMashExam.Data;
using SIS.MvcFramework;

namespace MishMashExam.Controllers
{
    public abstract class BaseController:Controller
    {
        public BaseController()
        {
            this.Db=new ApplicationDbContext();
        }
        public ApplicationDbContext Db { get; set; }
    }
}
