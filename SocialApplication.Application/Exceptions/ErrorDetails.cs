namespace SocialApplication.Application.Exceptions
{
    public class ErrorDetails
    {
        public Dictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
        public string Type { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int Status { get; set; }
        public string Instance { get; set; } = string.Empty;
        public string Detail { get; set; } = string.Empty;

    }
}
