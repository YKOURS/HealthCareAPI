
namespace Authentication.Domain.Dto
{
    public class UserLoginDto
    {
        public string? Email { get; set; }
        public required string MobileNumber { get; set; }
        public required string Password { get; set; }

    }
}
