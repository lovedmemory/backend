namespace lovedmemory.application.DTOs
{
    public class ContactUsDto
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public bool PrivacyAgree { get; set; }
    }
}
