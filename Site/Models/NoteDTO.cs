using Entity;
using System.ComponentModel.DataAnnotations;

namespace Site.Models
{
    public class NoteDTO
    {
        public int ID { get; set; }
    
        public string Title { get; set; }
      
        public string Description { get; set; }

        public int State { get; set; }

        public User User { get; set; }
    }
}
