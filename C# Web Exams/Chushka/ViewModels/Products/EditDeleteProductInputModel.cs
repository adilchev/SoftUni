using System;
using System.Collections.Generic;
using System.Text;

namespace ChushkaExam.ViewModels.Products
{
    public class EditDeleteProductInputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }
    }
}
