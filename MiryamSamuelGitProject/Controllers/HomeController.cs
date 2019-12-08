using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using MiryamSamuelGitProject.Models;

namespace MiryamSamuelGitProject.Controllers
{
    public class HomeController : Controller
    {
        public const string RepositorySession = "RepositorySession";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult BookmarkedRepositoriesView()
        {

            return View();
        }

        
        [HttpPost]
        public JsonResult SetBookmarkRepository(Repository repository)
        {
            var allBookmarkedRepositories = GetAllBookmarkedRepositoriesList();
           
           

            allBookmarkedRepositories.Add(repository);

            SaveBookmarkedRepositoriesList(allBookmarkedRepositories);

            return Json(new { bookmarkedRepos = allBookmarkedRepositories }) ;
        }

        [HttpGet]
        public JsonResult GetAllBookmarkedRepositories()
        {
            return Json(new { bookmarkedRepos = GetAllBookmarkedRepositoriesList() }, JsonRequestBehavior.AllowGet);
           
        }

        private List<Repository> GetAllBookmarkedRepositoriesList()
        {

            var sessionObject = Session[RepositorySession];

            if (sessionObject == null) return new List<Repository>();

            return (List<Repository>)sessionObject;

        }

        private void SaveBookmarkedRepositoriesList(List<Repository> allRepositories)
        {
            Session[RepositorySession] = allRepositories;
        }
    }
}