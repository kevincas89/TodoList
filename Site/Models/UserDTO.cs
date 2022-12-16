using System.ComponentModel.DataAnnotations;

namespace Site.Models
{
    public class UserDTO
    {
        public int ID { get; set; }
      
        public string Username { get; set; }
      
        public string Password { get; set; }
      
        public string Role { get; set; }
        
        public int State { get; set; }
    }
}
