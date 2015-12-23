using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Toolshed.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Toolshed.Controllers
{
     public class ToolshedController : Controller

    {

        public ToolshedRepository Repo { get; set; }

        public ToolshedController() : base()
        {
            Repo = new ToolshedRepository();
        }

        // GET: Toolshed
        // Maybe the Public feed here?
        public ActionResult Index()
        {
            List<Tool> my_tools = Repo.GetAllTools();
            // How you send a list of anything to a view
            return View(my_tools);
        }

        [Authorize]
        public ActionResult TopFavs()
        {
            return View();
        }

        [Authorize]
        public ActionResult UserFeed()
        {
            // How to get ApplicationUser and ToolshedUser (There are 3 ways!)
            /* V1
            ApplicationUserManager _userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            string userId = User.Identity.GetUserId();
            ApplicationUser app_user = _userManager.FindById(userId);
            ToolshedUser me = Repo.GetAllUsers().Where(u => u.RealUser.Id == userId).Single();
            */

            string user_id = User.Identity.GetUserId();
            /* V2
            string user_id = User.Identity.GetUserId();
            ApplicationUser real_user = Repo.Context.Users.FirstOrDefault(u => u.Id == user_id);
            ToolshedUser me = Repo.GetAllUsers().Where(u => real_user.Id == u.RealUser.Id).Single();
            */


            /* V3 */
            ToolshedUser me = Repo.GetAllUsers().Where(u => u.RealUser.Id == user_id).Single();

            List<Tool> list_of_tools = Repo.GetUserTools(me);
            return View(list_of_tools);
        }

        // GET: Toolshed/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Toolshed/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Toolshed/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Toolshed/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Toolshed/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Toolshed/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Toolshed/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
/*{
    public class ToolshedController : ApiController
    {
        // GET: api/Toolshed
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Toolshed/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Toolshed
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Toolshed/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Toolshed/5
        public void Delete(int id)
        {
        }
    }
}*/
