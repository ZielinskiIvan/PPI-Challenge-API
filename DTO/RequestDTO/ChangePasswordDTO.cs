namespace PPI_Challenge_API.DTO.RequestDTO
{
    public class ChangePasswordDTO
    {
        public string Password { get; set; } = null!;
        public string RepeatPassword { get; set; } = null!;
    }
}
