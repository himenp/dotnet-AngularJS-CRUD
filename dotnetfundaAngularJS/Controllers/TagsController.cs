using dotnetfundaAngularJS.Models;
using System.Linq;
using System.Web.Mvc;

namespace dotnetfundaAngularJS.Controllers
{
    public class TagsController : Controller
    {
        private IRepository<Tags> repository = null;
        public TagsController()
        {
            this.repository = new Repository<Tags>();
        }
        public TagsController(IRepository<Tags> repository)
        {
            this.repository = repository;
        }
        //Get All Tags
        public JsonResult TagsList()
        {
            var TagsList = repository.SelectAll().ToList();
            return Json(TagsList, JsonRequestBehavior.AllowGet);
        }
        
    }
}
