namespace Authentication.Domain.Dto
{
    public class LoginResponseDto
    {
        public long ContactId { get; set; }
        public long CompanyId { get; set; }
        public required string Role { get; set; }
        public long RoleId { get; set; }
        public bool Active { get; set; }
        public required string Token { get; set; }

    }
}
