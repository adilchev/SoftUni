using System;
using System.Collections.Generic;
using System.Text;

namespace ChushkaExam.ViewModels.Orders
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string ProductName { get; set; }

        public DateTime OrderedOn { get; set; }
    }
}
