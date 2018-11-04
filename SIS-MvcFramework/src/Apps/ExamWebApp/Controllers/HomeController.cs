using System;
using System.Collections.Generic;
using System.Text;
using SIS.HTTP.Responses;

namespace ExamWebApp.Controllers
{
    public class HomeController:BaseController
    {
        public IHttpResponse Index()
        {
            if (this.User.IsLoggedIn)
            {
                return this.View("Home/LoggedInIndex");
            }

            return this.View();
        }
    }
}
