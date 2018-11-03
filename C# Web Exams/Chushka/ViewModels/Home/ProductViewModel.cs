﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChushkaExam.Models;

namespace ChushkaExam.ViewModels.Products
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ShortDescription
        {
            get
            {
                if (this.Description?.Length>50)
                {
                    return this.Description.Substring(0, 50)+"...";
                }
                else
                {
                    return this.Description;
                }
            }
        }
    }
}
