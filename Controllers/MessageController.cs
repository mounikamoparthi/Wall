using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using wall.Connectors;
using wall.Models;

namespace wall.Controllers
{
    public class MessageController : Controller
    {
        // GET: /Home/
       private readonly DbConnector _dbConnector;
 
            public MessageController(DbConnector connect)
            {
                _dbConnector = connect;
               }
    

            [HttpPost]
            [Route("message")]
            public IActionResult message_post(Message new_message)
            {
                if(ModelState.IsValid){

                    int? CurrUserId = HttpContext.Session.GetInt32("CurrUserId");
                    System.Console.WriteLine(CurrUserId);
                    string query = $"insert into messages (message,created_at,updated_at, user_iduser) VALUES ('{new_message.message}',Now(),Now(),{CurrUserId})";
                    _dbConnector.Execute(query);
                   
                     
                }
                 return RedirectToAction("show");
            }
            [HttpGet]
            [Route("show")]
            public IActionResult show(){
                List<Dictionary<string, object>> AllMessages = _dbConnector.Query("select a.message, b.firstName from messages a inner join users b on b.idusers = a.user_iduser");
                    ViewBag.AllMessages = AllMessages;
                    return View("result");

            }
        }
}