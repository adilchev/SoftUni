using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChushkaExam.ViewModels.Orders;
using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace ChushkaExam.Controllers
{
    public class OrdersController:BaseController
    {
        [Authorize("Admin")]
        public IHttpResponse All()
        {
            var orders = this.Db.Orders.Select(x => new OrderViewModel
            {
                Id = x.Id,
                OrderedOn = x.OrderedOn,
                ProductName = x.Product.Name,
                Username = x.Client.Username
            }).ToList();

            var ordersViewModel = new AllOrdersViewModel()
            {
                Orders = orders
            };

            return this.View(ordersViewModel);
        }
    }
}
