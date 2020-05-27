using dotnetfundaAngularJS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace dotnetfundaAngularJS.Controllers
{
    public class PostController : Controller
    {
        private IRepository<Post> repository = null;
        private IRepository<Tags> tagrepository = null;
        private IRepository<PostTags> postagrepository = null;
        private bool Success = false;
        public PostController()
        {
            this.repository = new Repository<Post>();
            this.tagrepository = new Repository<Tags>();
            this.postagrepository = new Repository<PostTags>();
        }
        public PostController(IRepository<Post> repository, IRepository<Tags> tagrepository, IRepository<PostTags> postagrepository)
        {
            this.repository = repository;
            this.tagrepository = tagrepository;
            this.postagrepository = postagrepository;
        }

        public JsonResult PostList()
        {
            List<PostModel> postTags = new List<PostModel>();
            string tags = string.Empty;
            try
            {
                var posts = repository.SelectAll().ToList();
                foreach (Post post in posts)
                {
                    var allpostags = postagrepository.SelectAll().Where(p => p.PostId == post.PostId);
                    foreach(var postag in allpostags)
                    {
                       var tagName = tagrepository.SelectAll().Where(t => t.TagId == postag.TagId).ToList();
                       foreach (var tag in tagName)
                       {
                           tags = tag.Tag + ";" + tags;
                       }
                    }
                    postTags.Add(new PostModel { PostId = post.PostId,Title=post.Title,Content=post.Content,Tags = tags,Author = post.Author,CreatedDate=post.CreatedDate });
                    tags = string.Empty;
                }
                return Json(postTags, JsonRequestBehavior.AllowGet);
                
            }
            catch (Exception e)
            {
            }
            return Json(postTags, JsonRequestBehavior.AllowGet);
        }
        public JsonResult New()
        {
            PostModel postModel = new PostModel();
            return Json(postModel, JsonRequestBehavior.AllowGet);
        }
        public ActionResult NewPost(PostModel model)
        {
            try
            {
                var post = new Post
                {
                    Author = "Himen Patel",
                    Title = model.Title,
                    Content = model.Content,
                    CreatedDate = DateTime.UtcNow,
                    postTags = Utilities.ConvertToCollection(model),
                };
                repository.Insert(post);
                Success = repository.Save();
                return new HttpStatusCodeResult(HttpStatusCode.Created);  // OK = 200
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public JsonResult Edit(string id)
        {
            PostModel postTags = new PostModel();
            string tags = string.Empty;
            try
            {
                var posts = repository.SelectAll().Where(p => p.PostId == Convert.ToInt64(id)).ToList();
                foreach (Post post in posts)
                {
                    var allpostags = postagrepository.SelectAll().Where(p => p.PostId == post.PostId);
                    foreach (var postag in allpostags)
                    {
                        var tagName = tagrepository.SelectAll().Where(t => t.TagId == postag.TagId).ToList();
                        foreach (var tag in tagName)
                        {
                            tags = tag.Tag + ";" + tags;
                        }
                    }
                    postTags.Title = post.Title;
                    postTags.Content = post.Content;
                    postTags.Tags = tags;
                    postTags.PostId = post.PostId;
                    tags = string.Empty;
                }
                return Json(postTags, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {

            }
            return Json(postTags, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditPost(PostModel model)
        {
            try
            {
                bool success = DeleteTagsByPostId(Convert.ToInt32(model.PostId));
                var post = new Post
                {
                    PostId = model.PostId,
                    Author = "Himen Patel",
                    Title = model.Title,
                    Content = model.Content,
                    CreatedDate = DateTime.UtcNow,
                    postTags = Utilities.ConvertToCollection(model),
                };
                repository.Update(post);
                Success = repository.Save();
                return new HttpStatusCodeResult(HttpStatusCode.Created);  // OK = 200
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public ActionResult Delete(string PostId)
        {
            try
            {
                bool success = DeleteTagsByPostId(Convert.ToInt32(PostId));
                if (success)
                {
                    repository.Delete(Convert.ToInt32(PostId));
                    Success = repository.Save();
                }
                return new HttpStatusCodeResult(HttpStatusCode.Created);  // OK = 200
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        [NonAction]
        public bool DeleteTagsByPostId(int id)
        {
            try
            {
                var tags = postagrepository.SelectAll().Where(t => t.PostId == id);
                foreach (var t in tags)
                {
                    postagrepository.Delete(t.PostTagId);
                }
                Success = postagrepository.Save();
                return Success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
