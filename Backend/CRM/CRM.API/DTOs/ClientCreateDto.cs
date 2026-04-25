using System.ComponentModel.DataAnnotations;

namespace CRM.API.DTOs
{
    public class ClientCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }


    }
}
