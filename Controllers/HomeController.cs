using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using wall.Connectors;
using wall.Models;

namespace wall.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        private readonly DbConnector _dbConnector;

        public HomeController(DbConnector connect)
        {
            _dbConnector = connect;
        }


        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            //List<Dictionary<string, object>> AllUsers = _dbConnector.Query("SELECT * FROM users");
            return View();
        }

        // GET: /Home/
        [HttpPost]
        [Route("register")]
        public IActionResult Reg(User newUser, string firstName)
        {
            if (ModelState.IsValid)
            {
                string query = $"insert into users (firstName,lastName,emailid,password,created_at,updated_at) VALUES ('{newUser.firstName}','{newUser.lastName}','{newUser.emailid}','{newUser.password}',Now(),Now())";
                _dbConnector.Execute(query);
                ViewBag.firstName = firstName;
                HttpContext.Session.SetInt32("CurrUserId", newUser.idusers);
                return RedirectToAction("show","Message");
            }
            else
            {
                ViewBag.errors = ModelState.Values;
                ViewBag.status = "fail";
                return View("Index");
            }
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(string emailid, string password)
        {

            List<Dictionary<string, object>> loginUsers =
            _dbConnector.Query("select * from users where emailid = '" + emailid + "' and password = '" + password + "'");
            if (loginUsers.Count > 0)
            {
                HttpContext.Session.SetInt32("CurrUserId", (int)loginUsers[0]["idusers"]);
                ViewBag.firstName = loginUsers[0]["firstName"];
                return RedirectToAction("show","Message");
            }

            else
            {
                ViewBag.status = "faillogin";
                return View("Index");
            }
        }
    }
}




