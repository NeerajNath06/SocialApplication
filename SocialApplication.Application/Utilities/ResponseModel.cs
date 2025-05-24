using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SocialApplication.Application.Utilities
{
    [ExcludeFromCodeCoverage]
    [Newtonsoft.Json.JsonConverter(typeof(ResponseModelConverter))]
    [XmlRoot("ResponseModel", Namespace = "")]
    public sealed class ResponseModel<T>
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
        // The message of the response.
        // </summary>
        [JsonProperty("message")]
        [XmlElement("message")]
        public string Message { get; set; }

        // <summary>
        // The number of elements in the response.
        // </summary>
        [JsonProperty("numberOfElements")]
        [XmlElement("numberOfElements")]
        public int NumberOfElements { get; set; }

        // <summary>
        // The list of elements in the response.
        // </summary>
        [JsonProperty("elements")]
        [XmlElement("elements")]
        public T Elements { get; set; }

        // <summary>
        // The status code of the response.
        // </summary>
        [JsonProperty("statusCode")]
        [XmlElement("statusCode")]
        public int StatusCode { get; set; }


    }
}
