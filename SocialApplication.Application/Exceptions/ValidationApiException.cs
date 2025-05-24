namespace SocialApplication.Application.Exceptions
{
    internal class ValidationApiException : ApiException
    {
        public ErrorDetails Content { get; private set; }
        public ValidationApiException(ApiException apiException)
            : base(apiException.RequestMessage, apiException.HttpMethod, apiException.StatusCode, apiException.ReasonPhrase, apiException.Headers)
        {
        }
        public static async Task<ValidationApiException> Create(ApiException exception)
        {
            var validationApiException = new ValidationApiException(exception);
            var validationApiException2 = validationApiException;
            validationApiException2.Content = await exception.GetContentAsAsync<ErrorDetails>().ConfigureAwait(continueOnCapturedContext: false);
            return validationApiException;
        }
    }
}
