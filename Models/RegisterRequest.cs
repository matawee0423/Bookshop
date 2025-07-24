namespace BookShop.Models;

public class RegisterRequest
{
   
    
         public string Email { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string Fullname { get; set; } = "";
        public string Phone_number { get; set; } = "";
}