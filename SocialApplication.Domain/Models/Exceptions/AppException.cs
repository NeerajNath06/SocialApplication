namespace SocialApplication.Domain.Models.Exceptions
{
    [Serializable]
    public class AppException : Exception
    {
        public HttpRequestMessage RequestMessage { get; }
        public string Content { get; private set; }
        public bool HasContent => !string.IsNullOrWhiteSpace(Content);
        public object Obj { get; private set; }
        public AppException(string message) : base(message)
        {
        }

        public AppException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public AppException(HttpRequestMessage requestMessage)
        {
            RequestMessage = requestMessage;
        }

        public AppException(string message, object obj) : base(message)
        {
            Obj = obj;
            if (obj != null)
            {
                Data.Add(obj.GetType().Name, obj);
            }
        }
    }
}
