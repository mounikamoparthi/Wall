using System.ComponentModel.DataAnnotations;

namespace loginreg.Models{
    
    public class User{
        public int idUsers {get;set;}

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

        
    }
}