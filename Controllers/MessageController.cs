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
                //    HttpContext.Session.SetInt32("MessageId", new_message.idmessages);
                     
                }
                 return RedirectToAction("show");
            }
            [HttpGet]
            [Route("show")]
            public IActionResult show(){
                List<Dictionary<string, object>> AllMessages = _dbConnector.Query("select a.message,a.idmessages, b.firstName,a.created_at from messages a inner join users b on b.idusers = a.user_iduser");
                    ViewBag.AllMessages = AllMessages;
                 List<Dictionary<string, object>> AllComments = _dbConnector.Query("select a.comment,a.message_idmessage,b.idmessages, b.message,b.created_at from messages b left join comments a on b.idmessages = a.message_idmessage");
                    ViewBag.AllComments = AllComments;
                    return View("result");

            }
        }
}