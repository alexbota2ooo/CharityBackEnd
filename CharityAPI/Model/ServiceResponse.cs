namespace CharityAPI.Model
{
    public class ServiceResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public object? Payload { get; set; } = new object();
    }
}
