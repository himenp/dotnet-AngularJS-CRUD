using dotnetfundaAngularJS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dotnetfundaAngularJS.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Post> repository = null;
        private IRepository<Tags> tagrepository = null;
        private bool Success = false;
        public HomeController()
        {
            this.repository = new Repository<Post>();
            this.tagrepository = new Repository<Tags>();
        }
        public HomeController(IRepository<Post> repository, IRepository<Tags> tagrepository)
        {
            this.repository = repository;
            this.tagrepository = tagrepository;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}