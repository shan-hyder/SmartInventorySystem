namespace SmartInventorySystem.DTOs
{
    public class AuthResponseDTO
    {
        public bool success { get; set; }
        public string message { get; set; } = string.Empty;
        public string? token { get; set; }
    }
}
