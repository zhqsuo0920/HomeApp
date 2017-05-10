using HomeworkApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace HomeworkApp.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Index(string sort, string search)
        {
            IEnumerable<UserListModel> users = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56441/api/");
                //HTTP GET
                var responseTask = client.GetAsync("user");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<UserListModel>>();
                    readTask.Wait();

                    users = readTask.Result;
                }
                else //web api sent error response 
                {
                    users = Enumerable.Empty<UserListModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            users = AddFilterAndSorter(users, sort, search);
            return View(users);
        }

        [HttpGet]
        public ActionResult GetUserByID(string userID)
        {
            var user = new UserModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56441/api/");
                //HTTP GET
                var responseTask = client.GetAsync("user?userID=" + userID);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UserModel>();
                    readTask.Wait();

                    user = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here.
                    ModelState.AddModelError(string.Empty, "Not Found.");
                }
            }

            return View(user);
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(UserModel user, string button)
        {
            if(string.Compare(button, "Cancel", StringComparison.OrdinalIgnoreCase) == 0)
            {
                return RedirectToAction("Index");
            }

            if(UserExists(user.UserID))
            {
                ModelState.AddModelError(string.Empty, "This UserID exists.");
            }
            else
            {
                using (var client = new HttpClient())
                {
                    //add date
                    user.JoinedDate = DateTime.Now;
                    client.BaseAddress = new Uri("http://localhost:56441/api/user");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<UserModel>("user", user);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            }

            return PartialView(user);
        }

        [HttpGet]
        public bool UserExists(string userID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:56441/api/");
                //HTTP GET
                var responseTask = client.GetAsync("user?userID=" + userID);
                responseTask.Wait();

                return responseTask.Result.IsSuccessStatusCode;
            }
        }

        private IEnumerable<UserListModel> AddFilterAndSorter(IEnumerable<UserListModel> users, string sort, string search)
        {
            ViewBag.UserNameSortParameter = string.IsNullOrEmpty(sort) ? "Name_DESC" : string.Empty;
            ViewBag.EmailAddressSortParameter = sort == "EmailAddress" ? "EmailAddress_DESC" : "EmailAddress";
            ViewBag.JoinedDateSortParameter = sort == "JoinedDate" ? "JoinedDate_DESC" : "JoinedDate";

            if (!string.IsNullOrEmpty(search))
            {
                users = users.Where(c => c.Name.ToUpper().StartsWith(search.ToUpper()));
            }

            switch (sort)
            {
                case "Name_DESC":
                    users = users.OrderByDescending(c => c.Name);
                    break;
                case "EmailAddress":
                    users = users.OrderBy(c => c.EmailAddress);
                    break;
                case "EmailAddress_DESC":
                    users = users.OrderByDescending(c => c.EmailAddress);
                    break;
                case "JoinedDate":
                    users = users.OrderBy(c => c.JoinedDate);
                    break;
                case "JoinedDate_DESC":
                    users = users.OrderByDescending(c => c.JoinedDate);
                    break;
                default:
                    users = users.OrderBy(c => c.Name);
                    break;
            }

            return users;
        }
    }
}