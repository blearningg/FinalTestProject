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
                obj.StartDate = proj.StartDate.ToString("MM/dd/yyyy");
                obj.EndDate = proj.EndDate.ToString("MM/dd/yyyy");
                obj.Priority = proj.Priority;
                obj.Suspended = proj.Suspended;
                obj.TotalTasks = db.Tasks.Where(x => x.ProjectID == proj.ProjectID).Count() ;
                obj.CompletedTasks = db.Tasks.Where(x => x.ProjectID == proj.ProjectID && x.Status=="Completed").Count();
                
                lstProject.Add(obj);
            }
            
            return lstProject.ToList();
        }

        //// GET: api/Projects/5
        [ResponseType(typeof(Project))]
        public IHttpActionResult GetProject(int id)
        {
            Project project = db.Projects.Find(id);
            return Ok(project);
        }

        // PUT: api/Projects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProject(int id, Project project)
        {

            db.Entry(project).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Projects
        [ResponseType(typeof(Project))]
        public IHttpActionResult PostProject(Project project)
        {
            db.Projects.Add(project);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = project.ProjectID }, project);
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