﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChushkaExam.Models;
using ChushkaExam.ViewModels.Products;
using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace ChushkaExam.Controllers
{
    public class ProductsController:BaseController
    {
        [Authorize]
        public IHttpResponse Details(int id)
        {
            var product = this.Db.Products.Select(x => new ProductDetailsInputModel
            {
                Description = x.Description,
                Name = x.Name,
                Id = x.Id,
                Price = x.Price,
                Type = x.Type
            }).FirstOrDefault(x=>x.Id==id);
            if (product==null)
            {
                return this.BadRequestError("Invalid product id.");
            }
            return this.View(product);
        }

        [Authorize]
        public IHttpResponse Order(int id)
        {
            var user = this.Db.Users.FirstOrDefault(u => u.Username == this.User.Username);
            if (user==null)
            {
                return BadRequestError("No such user");
            }
            var order = new Order()
            {
                OrderedOn = DateTime.UtcNow,
                ClientId = user.Id,
                ProductId = id
            };
            this.Db.Orders.Add(order);
            this.Db.SaveChanges();

            return this.Redirect("/");
        }

        [Authorize("Admin")]
        public IHttpResponse Create()
        {
            return this.View();
        }

        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse Create(CreateProductInputModel model)
        {

            if (!Enum.TryParse(model.Type, out ProductType type))
            {
                return this.BadRequestErrorWithView("Invalid type.");
            }
            var product = new Product()
            {
                Description = model.Description,
                Name = model.Name,
                Price = model.Price,
                Type = type
            };
            this.Db.Products.Add(product);
            this.Db.SaveChanges();

            return this.Redirect("/Products/Details?id=" + product.Id);
        }

        [Authorize("Admin")]
        public IHttpResponse Edit(int id)
        {

            var product = this.Db.Products.Select(x => new EditDeleteProductInputModel()
            {
                Description = x.Description,
                Name = x.Name,
                Price = x.Price,
                Type = x.Type.ToString(),
                Id = x.Id
            }).FirstOrDefault(x=>x.Id==id);

            if (product == null)
            {
                return this.BadRequestError("Invalid product");
            }

            return this.View(product);
        }

        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse Edit(EditDeleteProductInputModel model)
        {
            var product = this.Db.Products.FirstOrDefault(p => p.Id == model.Id);
            if (product == null)
            {
                return this.BadRequestError("Product not found.");
            }
            if (!Enum.TryParse(model.Type, out ProductType type))
            {
                return this.BadRequestError("Invalid product type.");
            }

            product.Type = type;
            product.Description = model.Description;
            product.Name = model.Name;
            product.Price = model.Price;

            this.Db.SaveChanges();

            return this.Redirect("/Products/Details?id=" + product.Id);
        }
        [Authorize("Admin")]
        public IHttpResponse Delete(int id)
        {
            var viewModel = this.Db.Products
                .Select(x => new EditDeleteProductInputModel()
                {
                    Type = x.Type.ToString(),
                    Name = x.Name,
                    Id = x.Id,
                    Price = x.Price,
                    Description = x.Description,
                })
                .FirstOrDefault(x => x.Id == id);
            if (viewModel == null)
            {
                return this.BadRequestError("Invalid product id.");
            }

            return this.View(viewModel);

        }

        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse Delete(int id, string name)
        {
            var product = this.Db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return this.Redirect("/");
            }

            this.Db.Remove(product);
            // product.IsDeleted = true;
            this.Db.SaveChanges();

            return this.Redirect("/");
        }
    }
}
