namespace PPI_Challenge_API.DTO.RequestDTO
{
    public class UserCredentialsDTO
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
