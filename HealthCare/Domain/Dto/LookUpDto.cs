namespace HealthCare.Domain.Dto
{
    public class LookUpDto
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public required string Key { get; set; }
    }
}
