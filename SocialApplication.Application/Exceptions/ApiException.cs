using SocialApplication.Application.Settings;
using System.Net;
using System.Net.Http.Headers;


namespace SocialApplication.Application.Exceptions
{
    [Serializable]
    public class ApiException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ReasonPhrase { get; set; }
        public HttpResponseHeaders Headers { get; set; } // Changed type to HttpResponseHeaders  
        public HttpMethod HttpMethod { get; set; }
        public Uri Uri => RequestMessage.RequestUri;
        public HttpRequestMessage RequestMessage { get; set; }
        public HttpContentHeaders ContentHeaders { get; private set; }
        public string Content { get; private set; }
        public bool HasContent => !string.IsNullOrWhiteSpace(Content);
        public RefitSettings RefitSettings { get; set; } // Added property for RefitSettings

        private static string CreateMessage(HttpStatusCode statusCode, string reason)
        {
            return $"Response status code does not indicate success: {(int)statusCode} ({reason}).";
        }

        protected ApiException(HttpRequestMessage message, HttpMethod method, HttpStatusCode statusCode, string reason, HttpResponseHeaders headers) // Changed parameter type to HttpResponseHeaders  
            : base(CreateMessage(statusCode, reason))
        {
            RequestMessage = message;
            HttpMethod = method;
            StatusCode = statusCode;
            ReasonPhrase = reason;
            Headers = headers; // Updated assignment  
        }

        public static async Task<ApiException> Create(HttpRequestMessage message, HttpMethod method, HttpResponseMessage response)
        {
            //var content = response.Content != null ? await response.Content.ReadAsStringAsync() : null;
            ApiException exception = new ApiException(message, method, response.StatusCode, response.ReasonPhrase, response.Headers);
            if (response == null)
            {
                return exception;
            }
            try
            {
                exception.ContentHeaders = response.Content.Headers;
                ApiException ex = exception;
                ex.Content = await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
                if ((response.Content.Headers?.ContentType?.MediaType?.Equals("application/error+json")).GetValueOrDefault())
                {
                    exception = await ValidationApiException.Create(exception).ConfigureAwait(continueOnCapturedContext: false);
                }
                response.Content.Dispose();
            }
            catch (Exception ex)
            {
            }
            return exception;
        }

        public async Task<T> GetContentAsAsync<T>()
        {
            return (!HasContent) ? default(T) : (await RefitSettings.ContentSerializer.DeserializeAsync<T>(new StringContent(Content)).ConfigureAwait
                (continueOnCapturedContext: false));
        }
    }
}
