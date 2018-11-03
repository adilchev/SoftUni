using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using TorshiaExam.Controllers;
using TorshiaExam.Models;
using TorshiaExam.Models.Enums;
using TorshiaExam.ViewModels.Reports;

namespace ChushkaExam.Controllers
{
    public class ReportsController:BaseController
    {
        [Authorize("Admin")]
        public IHttpResponse All()
        {
            var reports = this.Db.Reports.Select(x => new ReportViewModel
            {
                Id = x.Id,
                Task = x.Task.Title,
                Status = x.Status.ToString(),
                Level = x.Task.AffectedSectors.Count
            }).ToList();

            var allViewModel = new AllReportsInputModel
            {
                Reports = reports
            };

            return this.View(allViewModel);
        }
        [Authorize("Admin")]
        public IHttpResponse Details(int id)
        {
            var report = this.Db.Reports.Select(x => new ReportDetailsInputModel
            {
                Description = x.Task.Description,
                Id = x.Id,
                AffectedSectors = string.Join(", ", x.Task.AffectedSectors),
                DueDate = x.Task.DueDate,
                Level = x.Task.AffectedSectors.Count,
                Participants = x.Task.Participants,
                ReportedOn = x.ReportedOn,
                Reporter = x.Reporter.Username,
                Status = x.Status.ToString(),
                Task = x.Task.Title
            }).FirstOrDefault(x=>x.Id==id);

            if (report == null)
            {
                return this.BadRequestError("Invalid report id.");
            }
            return this.View(report);
        }

        [Authorize]
        public IHttpResponse Create(int id)
        {
            var task = this.Db.Tasks.FirstOrDefault(x => x.Id == id);
            if (task == null)
            {
                return BadRequestError("No such task");
            }
            task.IsReported = true;
            var currentUser = this.Db.Users.FirstOrDefault(x => x.Username == this.User.Username);
            if (currentUser == null)
            {
                return BadRequestError("No such user");
            }

            var status = new [] {1, 1, 1, 2};
            var random = new Random().Next(0,4);

            var report = new Report()
            {
                ReportedOn = DateTime.UtcNow,
                ReporterId = currentUser.Id,
                TaskId = task.Id,
                Status = (ReportStatus) status[random]

            };

            this.Db.Reports.Add(report);
            this.Db.SaveChanges();

            return this.Redirect("/");
        }
    }
}
