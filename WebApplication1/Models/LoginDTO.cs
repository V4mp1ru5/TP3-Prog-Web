using System.ComponentModel.DataAnnotations;

    namespace WebApplication1.Models
    {
        public class LoginDTO
        {
            [Required]
            public string UserName { get; set; }

            [Required]
            public string Password { get; set; }
        }
    }

