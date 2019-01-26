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
                obj.TotalTasks = db.Tasks.Where(x => x.ProjectID == proj.ProjectID).Count() ;
                obj.CompletedTasks = db.Tasks.Where(x => x.ProjectID == proj.ProjectID && x.Status=="Completed").Count();

                lstProject.Add(obj);
            }
            
            return lstProject.ToList();
        }

        //// GET: api/Projects/5
        //[ResponseType(typeof(Project))]
        //public IHttpActionResult GetProject(int id)
        //{
        //    Project project = db.Projects.Find(id);
        //    if (project == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(project);
        //}

        // PUT: api/Projects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProject(int id, Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project.ProjectID)
            {
                return BadRequest();
            }

            db.Entry(project).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Projects
        [ResponseType(typeof(Project))]
        public IHttpActionResult PostProject(Project project)
        {
            try
            {

          
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            db.Projects.Add(project);
            db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return CreatedAtRoute("DefaultApi", new { id = project.ProjectID }, project);
        }

        // DELETE: api/Projects/5
        [ResponseType(typeof(Project))]
        public IHttpActionResult DeleteProject(int id)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            db.Projects.Remove(project);
            db.SaveChanges();

            return Ok(project);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectExists(int id)
        {
            return db.Projects.Count(e => e.ProjectID == id) > 0;
        }
    }
}