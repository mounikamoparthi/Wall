using System.ComponentModel.DataAnnotations;
using System;

namespace wall.Models{
    public class Message{
        public int user_iduser{get;set;}
        public int idmessages {get;set;}
        [Required]
        [MinLength(4)]
        public string message {get;set;}

        public DateTime created_at { get; set; }

        public DateTime updated_at { get; set; }
        public Message()
        {
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
            
        }
    }
}
