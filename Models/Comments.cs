using System.ComponentModel.DataAnnotations;
using System;

namespace wall.Models{
    public class Comment{
        public int user_iduser{get;set;}
        public int message_idmessage{get;set;}
        public int idcomments {get;set;}
        [Required]
        [MinLength(4)]
        public string comment {get;set;}

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public Comment()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            
        }
    }
}
