using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TestWebApi;
using TestWebApi.Models;

namespace TestWebApi.Controllers
{
  
    public class ProjectsController : ApiController
    {
        private masterEntities db = new masterEntities();

        // GET: api/Projects
        public IEnumerable<ProjectViewModel> GetProjects()
        {
            List<ProjectViewModel> lstProject = new List<ProjectViewModel>();

            foreach (Project proj in db.Projects)
            {
                ProjectViewModel obj = new ProjectViewModel();
                obj.ProjectID = proj.ProjectID;
                obj.ProjectName = proj.ProjectName;
                obj.StartDate = proj.StartDate.ToString("yyyy-MM-dd"); //.ToString("MM /dd/yyyy");
                obj.EndDate = proj.EndDate.ToString("yyyy-MM-dd");//.ToString("MM /dd/yyyy");
                obj.Priority = proj.Priority;
                obj.Suspended = proj.Suspended;
                obj.TotalTasks = db.Tasks.Where(x => x.ProjectID == proj.ProjectID).Count() ;
                obj.CompletedTasks = db.Tasks.Where(x => x.ProjectID == proj.ProjectID && x.Status=="Completed").Count();
                obj.UserID = db.Users.Where(x => x.ProjectID == proj.ProjectID).Select(x => x.UserID).FirstOrDefault();
                obj.UserName = db.Users.Where(x => x.ProjectID == proj.ProjectID).Select(x => x.FirstName + " " + x.LastName).FirstOrDefault();
                lstProject.Add(obj);
            }
            
            return lstProject.ToList().OrderBy(x => x.StartDate);
        }

        //// GET: api/Projects/5
        [ResponseType(typeof(ProjectViewModel))]
        public IHttpActionResult GetProject(int id)
        {
            Project proj = db.Projects.Find(id);

            ProjectViewModel obj = new ProjectViewModel();
            obj.ProjectID = proj.ProjectID;
            obj.ProjectName = proj.ProjectName;
            obj.StartDate = proj.StartDate.ToString(); //.ToString("MM/dd/yyyy");
            obj.EndDate = proj.EndDate.ToString();//.ToString("MM/dd/yyyy");
            obj.Priority = proj.Priority;
            obj.Suspended = proj.Suspended;
            obj.TotalTasks = db.Tasks.Where(x => x.ProjectID == proj.ProjectID).Count();
            obj.CompletedTasks = db.Tasks.Where(x => x.ProjectID == proj.ProjectID && x.Status == "Completed").Count();
            obj.UserID = db.Users.Where(x => x.ProjectID == proj.ProjectID).Select(x => x.UserID).FirstOrDefault();
            obj.UserName = db.Users.Where(x => x.ProjectID == proj.ProjectID).Select(x => x.FirstName + " " + x.LastName).FirstOrDefault();

            return Ok(obj);
        }

        // PUT: api/Projects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProject(int id, ProjectViewModel project)
        {
            Project obj = db.Projects.Find(project.ProjectID);
            obj.ProjectName = project.ProjectName;
            obj.StartDate = Convert.ToDateTime(project.StartDate);
            obj.EndDate = Convert.ToDateTime(project.EndDate);
            obj.Priority = project.Priority;
            obj.Suspended = project.Suspended;
            db.Entry(obj).State = EntityState.Modified;
            try
            {
                User objUser = db.Users.Find(project.UserID);

                objUser.ProjectID = project.ProjectID;

                db.Entry(objUser).State = EntityState.Modified;

                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Projects
        [ResponseType(typeof(ProjectViewModel))]
        public IHttpActionResult PostProject(ProjectViewModel project)
        {
            // db.Projects.Add(project);

            //  db.SaveChanges();
            Project obj = new Project();
            obj.ProjectName = project.ProjectName;
            obj.StartDate = Convert.ToDateTime(project.StartDate); 
            obj.EndDate = Convert.ToDateTime(project.EndDate);
            obj.Priority = project.Priority;
            obj.Suspended = project.Suspended;
            db.Projects.Add(obj);
            db.SaveChanges();

            if (project.UserID != null)
            {
                User objUser = db.Users.Find(project.UserID);

                objUser.ProjectID = obj.ProjectID;

                db.Entry(objUser).State = EntityState.Modified;

                db.SaveChanges();
            }

            return CreatedAtRoute("DefaultApi", new { id = obj.ProjectID }, project);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private bool ProjectExists(int id)
        //{
        //    return db.Projects.Count(e => e.ProjectID == id) > 0;
        //}
    }
}