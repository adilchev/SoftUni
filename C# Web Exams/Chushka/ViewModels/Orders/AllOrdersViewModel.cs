using System;
using System.Collections.Generic;
using System.Text;

namespace ChushkaExam.ViewModels.Orders
{
    public class AllOrdersViewModel
    {
        public IEnumerable<OrderViewModel> Orders { get; set; }
    }
}
