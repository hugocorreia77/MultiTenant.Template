namespace Services.Abstractions.Models.Users
{
    public class UserDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
