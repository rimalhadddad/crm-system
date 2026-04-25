using System.ComponentModel.DataAnnotations;

namespace CRM.API.DTOs
{
    public class AssignPropertyDto
    {
        [Required]
        public Guid ClientId { get; set; }
        public int? PropertyId { get; set; }
    }
}
