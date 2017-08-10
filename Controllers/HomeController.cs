using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using wall.Connectors;

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
            public IActionResult Reg(User newUser,string firstName)
            {
            if(ModelState.IsValid)
            {
                string query = $"insert into users (firstName,lastName,emailid,password,confirmPassword) VALUES ('{newUser.firstName}','{newUser.lastName}','{newUser.emailid}','{newUser.password}','{newUser.confirmPassword}')";
                _dbConnector.Execute(query);
                ViewBag.firstName = firstName;
                return View("result");
            }
            else
            {
                ViewBag.errors = ModelState.Values;
                ViewBag.status="fail";
                return View("Index"); 
            }
        }
            [HttpPost]
            [Route("login")]
            public IActionResult Login(string emailid, string password){
                
                    List<Dictionary<string, object>> loginUsers = 
                    _dbConnector.Query ("select * from users where emailid = '"+emailid+"' and password = '"+password+"'");
                    if(loginUsers.Count > 0){
                        ViewBag.firstName=loginUsers[0]["firstName"];
                        return View("result");
                    }
                    
                    else{
                        ViewBag.status="faillogin";
                        return View("Index"); 
                }


        }

    }
}
    

    

