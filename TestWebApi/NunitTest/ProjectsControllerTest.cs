using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using TestWebApi;
using TestWebApi.Controllers;
using TestWebApi.Models;

namespace NunitTest
{
    [TestFixture]
    public class ProjectsControllerTest
    {
        [Test]
        public void GetProejcts_NunitTest()
        {
            var controller = new ProjectsController();
            List<ProjectViewModel> lstProject = new List<ProjectViewModel>();
            lstProject = controller.GetProjects().ToList();
            Assert.IsNotNull(lstProject);
        }


        //[Test]
        //public void GetProejct_NunitTest()
        //{
        //    var controller = new ProjectsController();

        //    var result = controller.GetSUPPLIER("1") as OkNegotiatedContentResult<ProjectViewModel>;
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual("Supp1", result.Content.SUPLNAME);
        //}



        [Test]
        public void AddProject_NunitTest()
        {
            var controller = new ProjectsController();

            Project obj = new Project { ProjectName = "UniTestProject1", StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(1), Priority = 1 };
            IHttpActionResult result = controller.PostProject(obj);
            var createResult = result as CreatedAtRouteNegotiatedContentResult<Project>;

            int id = Convert.ToInt32(createResult.RouteValues["id"]);

            var result2 = controller.GetProject(id) as OkNegotiatedContentResult<Project>;
            Assert.IsNotNull(result2);
            Assert.AreEqual(obj.ProjectName, result2.Content.ProjectName);

            //var response = Request.CreateResponse(HttpStatusCode.Created, product);
            //string uri = Url.Link("DefaultApi", new { id = product.Id });
            //response.Headers.Location = new Uri(uri);
            //List<ProjectViewModel> lstProject = new List<ProjectViewModel>();

            //lstProject = controller.GetProjects().ToList(); //as OkNegotiatedContentResult<SUPPLIER>;
            //ProjectViewModel proj = lstProject.Where(x => x.ProjectName == "UniTestProject1").SingleOrDefault();
            //Assert.IsNotNull(lstProject);
            //Assert.AreEqual(obj.ProjectName, proj.ProjectName);
        }

        //[Test]
        //public void UpdateProject_NunitTest()
        //{
        //    var controller = new ProjectsController();

        //    Project obj = new Project { ProjectName = "UniTestProject1", StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(1), Priority = 1 };
        //    var result = controller.PutSUPPLIER("4", obj);

        //    var result2 = controller.GetSUPPLIER("4") as OkNegotiatedContentResult<SUPPLIER>;
        //    Assert.IsNotNull(result2);
        //    Assert.AreEqual(obj.SUPLADDR, result2.Content.SUPLADDR);

        //    IHttpActionResult actionResult = controller.Put("10", obj);
        //    var contentResult = actionResult as NegotiatedContentResult<Product>;

        //    // Assert
        //    Assert.IsNotNull(contentResult);
        //    Assert.AreEqual(HttpStatusCode.Accepted, contentResult.StatusCode);
        //    Assert.IsNotNull(contentResult.Content);
        //    Assert.AreEqual(10, contentResult.Content.Id);
        //}
    }
}
