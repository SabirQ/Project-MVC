using System.ComponentModel.DataAnnotations;

namespace Project_MVC.ViewModels
{
    public class LoginVM
    {
        [Required, StringLength(25)]
        public string Username { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberOn { get; set; }
    }
}
