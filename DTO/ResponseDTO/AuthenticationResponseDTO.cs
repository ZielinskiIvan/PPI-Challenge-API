namespace PPI_Challenge_API.DTO.ResponseDTO
{
    public class AuthenticationResponseDTO
    {
        public string Token { get; set; } = null!;
        public DateTime Expiration { get; set; }
    }
}
