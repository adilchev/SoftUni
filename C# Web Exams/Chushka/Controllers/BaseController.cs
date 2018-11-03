using System;
using System.Collections.Generic;
using System.Text;
using ChushkaExam.Data;
using SIS.MvcFramework;

namespace ChushkaExam.Controllers
{
    public abstract class BaseController:Controller
    {
        protected BaseController()
        {
            this.Db=new ApplicationDbContext();
        }
        public ApplicationDbContext Db { get; }
    }
}
