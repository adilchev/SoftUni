using System;
using System.Collections.Generic;
using System.Text;
using ChushkaExam.ViewModels.Products;

namespace ChushkaExam.ViewModels.Home
{
    public class IndexViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
