namespace TWT.Core.Models
{
    public class ResponseM
    {
        public bool Success { get; set; }
        public int HttpCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}