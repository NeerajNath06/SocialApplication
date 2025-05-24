

namespace SocialApplication.Application.Settings
{
    using Newtonsoft.Json;
    using SocialApplication.Application.Formatters.FormatterClasses;
    using SocialApplication.Application.Formatters.FormatterInterfaces;
    using System;
    using System.Threading.Tasks;
    public class RefitSettings
    {
        private JsonSerializerSettings JsonSerializerSettings;
        public Func<Task<string>> AuthorizationHeaderValueGetter { get; set; }
        public Func<Task<HttpRequestMessage>> AuthorizationHeaderValueWithParamGetter { get; set; }
        public Func<Task<HttpMessageHandler>> HttpMessageHandlerFactory { get; set; }

        public IContentSerializer ContentSerializer { get; set; }
        public IUrlParameterFormatter UrlParameterFormatter { get; set; }
        public IFormUrlEncodedParameterFormatter FormUrlEncodedParameterFormatter { get; set; }
        public bool Buffered { get; set; } = true;
        public RefitSettings()
        {
            UrlParameterFormatter = new DefaultUrlParameterFormatter();
            FormUrlEncodedParameterFormatter = new DefaultFormUrlEncodedParameterFormatter();
            ContentSerializer = new JsonContentSerializer();
        }
    }
}
