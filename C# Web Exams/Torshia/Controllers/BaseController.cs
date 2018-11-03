using System;
using System.Collections.Generic;
using System.Text;
using SIS.MvcFramework;
using TorshiaExam.Data;

namespace TorshiaExam.Controllers
{
    public class BaseController:Controller
    {
        public BaseController()
        {
            this.Db=new ApplicationDbContext();
        }
        public ApplicationDbContext Db { get;}
    }
}
