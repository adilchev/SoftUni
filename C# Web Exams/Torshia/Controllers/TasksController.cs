using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using TorshiaExam.Models;
using TorshiaExam.ViewModels.Tasks;

namespace TorshiaExam.Controllers
{
    public class TasksController:BaseController
    {
        [Authorize]
        public IHttpResponse Details(int id)
        {
            var tasksDetailsViewModel = this.Db.Tasks.Select(x => new TaskDetailsInputModel
            {
                Id = x.Id,
                Description = x.Description,
                DueDate = x.DueDate,
                IsReported = x.IsReported,
                Title = x.Title,
                Participants = x.Participants,
                AffectedSectors = x.AffectedSectors
            }).FirstOrDefault(x => x.Id == id);

            if (tasksDetailsViewModel == null)
            {
                return this.BadRequestError("Invalid product id.");
            }

            return this.View(tasksDetailsViewModel);
        }

        [Authorize("Admin")]
        public IHttpResponse Create()
        {
            return this.View();
        }

        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse Create(CreateTaskInputModel model)
        {
            var task = new Task()
            {
                Title = model.Title,
                Description = model.Description,
                DueDate = model.DueDate,
                Participants = model.Participants,
                AffectedSectors = model.AffectedSectors

            };
            this.Db.Tasks.Add(task);
            this.Db.SaveChanges();


            return this.Redirect("/Tasks/Details?id=" + task.Id);
        }
    }
}
