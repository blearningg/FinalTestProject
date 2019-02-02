using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestWebApi.Controllers;
using TestWebApi.Models;
using System.Collections.Generic;
using TestWebApi;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace WebApi.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
       
        public void GetProejcts_Test()
        {
            try
            {
                var controller = new ProjectsController();
                List<ProjectViewModel> lstProject = new List<ProjectViewModel>();
                lstProject = controller.GetProjects().ToList();
                Assert.IsNotNull(lstProject);
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
        //[TestMethod]
        //public void AddProject_NunitTest()
        //{
        //    var controller = new ProjectsController();

        //    Project obj = new Project { ProjectName = "UniTestProject1", StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(1), Priority = 1 };
        //    IHttpActionResult result = controller.PostProject(obj);
        //    var createResult = result as CreatedAtRouteNegotiatedContentResult<Project>;

        //    int id = Convert.ToInt32(createResult.RouteValues["id"]);
        //    var result2 = controller.GetProject(id) as OkNegotiatedContentResult<Project>;
        //    Assert.IsNotNull(result2);
        //    Assert.AreEqual(obj.ProjectName, result2.Content.ProjectName);

        //    //var response = Request.CreateResponse(HttpStatusCode.Created, product);
        //    //string uri = Url.Link("DefaultApi", new { id = product.Id });
        //    //response.Headers.Location = new Uri(uri);
        //    //List<ProjectViewModel> lstProject = new List<ProjectViewModel>();

        //    //lstProject = controller.GetProjects().ToList(); //as OkNegotiatedContentResult<SUPPLIER>;
        //    //ProjectViewModel proj = lstProject.Where(x => x.ProjectName == "UniTestProject1").SingleOrDefault();
        //    //Assert.IsNotNull(lstProject);
        //    //Assert.AreEqual(obj.ProjectName, proj.ProjectName);
        //}
    }
}
