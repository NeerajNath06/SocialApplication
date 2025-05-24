
namespace SocialApplication.Application.Utilities
{
    using Newtonsoft.Json;
    using System.Diagnostics.CodeAnalysis;
    using System.Net;
    using System.Xml.Serialization;

    [ExcludeFromCodeCoverage]
    [Newtonsoft.Json.JsonConverter(typeof(ErrorModelConverter))]
    [XmlRoot("ResponseModel", Namespace = "")]
    public sealed class ErrorModel<T> where T : Exception
    {
        // <summary>
        // The copyrights of the response.
        // </summary>
        [JsonProperty("copyrights")]
        [XmlElement("copyrights")]
        public string Copyrights { get; set; }

        // <summary>
        // The execution time of the response in milliseconds.
        // </summary>
        [JsonProperty("executionTimeInMilliseconds")]
        [XmlElement("executionTimeInMilliseconds")]
        public long ExecutionTimeInMilliseconds { get; set; }

        // <summary>
        // The exception of the response.
        // </summary>
        [JsonProperty("exception", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement("exception")]
        public T Exception { get; set; }

        // <summary>
        // The message of the response.
        // </summary>
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement("message")]
        public string Message { get; set; }

        // <summary>
        // The number of elements in the response.
        // </summary>
        [JsonProperty("errorGuid", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement("errorGuid")]
        public Guid ErrorId { get; set; }

        // <summary>
        // The status code of the response.
        // </summary>
        [JsonProperty("statusCode", NullValueHandling = NullValueHandling.Ignore)]
        [XmlElement("statusCode")]
        public HttpStatusCode StatusCode { get; set; }


    }
}
