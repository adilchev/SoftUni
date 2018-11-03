using System;
using System.Collections.Generic;
using System.Text;
using ChushkaExam.Models;

namespace ChushkaExam.ViewModels.Products
{
    public class CreateProductInputModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }
    }
}
