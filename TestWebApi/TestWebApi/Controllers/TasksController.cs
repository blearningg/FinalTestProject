using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TestWebApi;
using TestWebApi.Models;

namespace TestWebApi.Controllers
{
    public class TasksController : ApiController
    {
        private masterEntities db = new masterEntities();

        public IEnumerable<TaskViewModel> GetTasks(int projectID)
        {
            List<TaskViewModel> lstTask = new List<TaskViewModel>();
            foreach (Task task in db.Tasks)
            {
                if (task.ProjectID == projectID)
                {
                    TaskViewModel obj = new TaskViewModel();
                    obj.TaskID = task.TaskID;
                    obj.ParentID = task.ParentID;
                    obj.ProjectID = task.ProjectID;
                    obj.TaskDesc = task.TaskDesc;
                    obj.StartDate = task.StartDate.ToString("yyyy-MM-dd");
                    obj.EndDate = task.EndDate.ToString("yyyy-MM-dd");
                    obj.Priority = task.Priority;
                    obj.Status = task.Status;
                    obj.ParentTaskDesc = db.ParentTasks.Where(x => x.ParentID == task.ParentID).Select(x => x.TaskDesc).FirstOrDefault();
                    obj.ProjectName = db.Projects.Where(x => x.ProjectID == task.ProjectID).Select(x => x.ProjectName).FirstOrDefault();
                    obj.UserName = db.Users.Where(x => x.TaskID == task.TaskID).Select(x => x.FirstName + " " + x.LastName).FirstOrDefault();
                    lstTask.Add(obj);
                }
               
            }
            return lstTask.ToList().OrderBy(x=>x.StartDate); //db.Tasks;//db.Tasks.Include(i => i.ParentTask).ToList();
        }

        // GET: api/Tasks/5
        [ResponseType(typeof(TaskViewModel))]
        public IHttpActionResult GetTask(int id)
        {
            Task task = db.Tasks.Find(id);

            TaskViewModel obj = new TaskViewModel();
            obj.TaskID = task.TaskID;
            obj.ParentID = task.ParentID;
            obj.ProjectID = task.ProjectID;
            obj.TaskDesc = task.TaskDesc;
            obj.StartDate = task.StartDate.ToString("yyyy-MM-dd");
            obj.EndDate = task.EndDate.ToString("yyyy-MM-dd");
            obj.Priority = task.Priority;
            obj.Status = task.Status;
            obj.ParentTaskDesc = db.ParentTasks.Where(x => x.ParentID == task.ParentID).Select(x => x.TaskDesc).FirstOrDefault();
            obj.ProjectName = db.Projects.Where(x => x.ProjectID == task.ProjectID).Select(x => x.ProjectName).FirstOrDefault();
            obj.UserName = db.Users.Where(x => x.TaskID == task.TaskID).Select(x => x.FirstName + " " + x.LastName).FirstOrDefault();


            return Ok(obj);
        }

        //// PUT: api/Tasks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTask(int id, TaskViewModel taskViewModel)
        {

            Task task = db.Tasks.Find(id);
            task.TaskID = taskViewModel.TaskID;
            task.ParentID = taskViewModel.ParentID;
            task.ProjectID = taskViewModel.ProjectID;
            task.TaskDesc = taskViewModel.TaskDesc;
            task.StartDate = Convert.ToDateTime(taskViewModel.StartDate);
            task.EndDate = Convert.ToDateTime(taskViewModel.EndDate);
            task.Priority = taskViewModel.Priority;
            task.Status = taskViewModel.Status;
            db.Entry(task).State = EntityState.Modified;

           // db.SaveChanges();

            User objUser = db.Users.Find(taskViewModel.UserID);
            objUser.TaskID = task.TaskID;

            db.Entry(objUser).State = EntityState.Modified;

           // db.SaveChanges();


            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Tasks
        [ResponseType(typeof(TaskViewModel))]
        public IHttpActionResult PostTask(TaskViewModel taskViewModel)
        {
          
                Task task = new Task();
                task.ParentID = taskViewModel.ParentID;
                task.ProjectID = taskViewModel.ProjectID;
                task.TaskDesc = taskViewModel.TaskDesc;
                task.StartDate = Convert.ToDateTime(taskViewModel.StartDate);
                task.EndDate = Convert.ToDateTime(taskViewModel.EndDate);
                task.Priority = taskViewModel.Priority;
                task.Status = "Pending";
                db.Tasks.Add(task);
                db.SaveChanges();

                if (taskViewModel.UserID !=null)
                {
                    User objUser = db.Users.Find(taskViewModel.UserID);


                    db.Entry(objUser).State = EntityState.Modified;

                    db.SaveChanges();
                }
                return CreatedAtRoute("DefaultApi", new { id = task.TaskID }, taskViewModel);
           
        }

       
        [ResponseType(typeof(Task))]
        public IHttpActionResult EndTask(int id)
        {
            Task task = db.Tasks.Find(id);
            task.Status = "Completed";
            db.Entry(task).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok(task);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}