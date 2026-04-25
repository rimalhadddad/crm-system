namespace CRM.API.DTOs
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid UserId { get; set; }
        public int? PropertyId { get; set; }
        public string PropertyTitle { get; set; }
    }
}
