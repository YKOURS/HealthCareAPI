namespace Authentication.Domain.Dto
{
    public class RegisterUserDto
    {
        public long Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public required string Mobile { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastEditedDate { get; set; }

        public long? CreatedId { get; set; }

        public long? EditedId { get; set; }

        public bool? Active { get; set; }

        public long Age { get; set; }

        public long GenderId { get; set; }

    }
}
