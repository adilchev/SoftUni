using System;
using System.Collections.Generic;
using System.Text;
using ChushkaExam.Models;

namespace ChushkaExam.ViewModels.Products
{
    public class ProductDetailsInputModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public ProductType Type { get; set; }
    }
}
