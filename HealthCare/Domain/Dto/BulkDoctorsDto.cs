namespace HealthCare.Domain.Dto
{
    public class BulkDoctorsDto
    {
        public long Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Mobile { get; set; }
        public long Age { get; set; }
        public long GenderId { get; set; }
        public long RegId { get; set; }
        public long CompanyId { get; set; }
        public long? ContactId { get; set; }
        public long SpecialityId { get; set; }
        public required string Education { get; set; }
        public long EducationId { get; set; }
        public long LanguageId { get; set; }
        public long Experience { get; set; }
        public bool IsVerified { get; set; }
        public required string Address { get; set; }
        public long CityId { get; set; }
        public long StateId { get; set; }
        public required string PinCode { get; set; }
        public long CountryId { get; set; }
        public long? CreatedId { get; set; }
        public long? EditedId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool Active { get; set; }

    }
}
