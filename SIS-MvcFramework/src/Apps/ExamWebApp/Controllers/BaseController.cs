using System;
using System.Collections.Generic;
using System.Text;
using ExamWebApp.Data;
using SIS.MvcFramework;

namespace ExamWebApp.Controllers
{
    public abstract class BaseController:Controller
    {
        public BaseController()
        {
            this.Db=new ApplicationDbContext();
        }

        public ApplicationDbContext Db{ get; }
    }
}
