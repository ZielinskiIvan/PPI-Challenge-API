namespace PPI_Challenge_API.DTO.RequestDTO
{
    public class UserRegisterDTO : UserCredentialsDTO
    {
        public string UserName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
