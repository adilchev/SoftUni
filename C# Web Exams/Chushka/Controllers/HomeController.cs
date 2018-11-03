using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChushkaExam.ViewModels.Home;
using ChushkaExam.ViewModels.Products;
using SIS.HTTP.Responses;

namespace ChushkaExam.Controllers
{
    public class HomeController:BaseController
    {
        public IHttpResponse Index()
        {
            if (this.User.IsLoggedIn)
            {
                var products = this.Db.Products.Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price
                }).ToList();

                var model = new IndexViewModel {Products = products};

                return this.View("Home/LoggedInIndex",model);
            }
            return this.View();
        }
    }
}
