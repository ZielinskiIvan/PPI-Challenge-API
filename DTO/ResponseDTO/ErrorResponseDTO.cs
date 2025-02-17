namespace PPI_Challenge_API.DTO.ResponseDTO
{
    public class ErrorResponseDTO
    {
        public Guid Id { get; set; }
        public string ErrorMessage { get; set; } = null!;
        public string? StackTrace { get; set; }
        public DateTime Date { get; set; }
    }
}
