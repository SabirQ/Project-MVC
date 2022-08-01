using Project_MVC.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Project_MVC.Models
{
    public class CustomMessage:BaseEntity
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
