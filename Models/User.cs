using System.ComponentModel.DataAnnotations;
using System;

namespace wall.Models{
    
    public class User{
        public int idusers {get;set;}

        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string firstName {get; set;}

        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string lastName {get; set;}


        [Required]
        [EmailAddress]
        public string emailid { get; set; }
 
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Compare("password", ErrorMessage = "Password confirmation must match Password")]
        public string confirmPassword { get; set; }
        public DateTime created_at { get; set; }

        public DateTime updated_at { get; set; }
        public User()
        {
            created_at = DateTime.Now;
            updated_at = DateTime.Now;
            
        }

        
    }
}