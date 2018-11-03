using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIS.HTTP.Responses;
using TorshiaExam.ViewModels.Home;

namespace TorshiaExam.Controllers
{
    public class HomeController:BaseController
    {

        public IHttpResponse Index()
        {
            if (this.User.IsLoggedIn)
            {
                var tasksViewModel = this.Db.Tasks.Where(x => x.IsReported == false).Select(x => new TaskViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    AffectedSectors = x.AffectedSectors
                }).ToList();
                var tasks = new IndexViewModel
                {
                    Tasks = tasksViewModel
                };
                return this.View("Home/LoggedInIndex",tasks);
            }

            return this.View();
        }
    }
}
