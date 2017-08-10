using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using wall.Connectors;
using wall.Models;

namespace wall.Controllers
{
    public class CommentController : Controller
    {
        // GET: /Home/
       private readonly DbConnector _dbConnector;
 
            public CommentController(DbConnector connect)
            {
                _dbConnector = connect;
               }
    

            [HttpPost]
            [Route("comment")]
            public IActionResult comments(Comment new_comment)
            {
                if(ModelState.IsValid){

                    int? CurrUserId = HttpContext.Session.GetInt32("CurrUserId");
                    
                    System.Console.WriteLine("@@@@@@", new_comment.message_idmessage);
                    string query = $"insert into comments (comment,created_at,updated_at, message_idmessage,user_iduser) VALUES ('{new_comment.comment}',Now(),Now(),{new_comment.message_idmessage},{CurrUserId})";
                    _dbConnector.Execute(query);
                    
                                     
                }
                 return RedirectToAction("show","Message");
            }
           
        }
}