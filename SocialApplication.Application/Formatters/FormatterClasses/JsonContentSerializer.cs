

namespace SocialApplication.Application.Formatters.FormatterClasses
{
    using Newtonsoft.Json;
    using SocialApplication.Application.Formatters.FormatterInterfaces;
    using System.Text;

    public class JsonContentSerializer : IContentSerializer
    {
        private readonly Lazy<JsonSerializerSettings> jsonSerializerSettings;

        public JsonContentSerializer() : this(null)
        {

        }

        public JsonContentSerializer(JsonSerializerSettings jsonSerializerSettings)
        {
            this.jsonSerializerSettings = new Lazy<JsonSerializerSettings>(() => (jsonSerializerSettings == null) ? ((JsonConvert.DefaultSettings == null) ? new JsonSerializerSettings() : JsonConvert.DefaultSettings()) : jsonSerializerSettings);
        }

        public Task<HttpContent> SerializeAsync<T>(T content)
        {
            return Task.FromResult((HttpContent)new StringContent(JsonConvert.SerializeObject(content, jsonSerializerSettings.Value), Encoding.UTF8, "application/json"));
        }

        public async Task<T> DeserializeAsync<T>(HttpContent content)
        {
            JsonSerializer jsonSerializer = JsonSerializer.Create(jsonSerializerSettings.Value);
            using Stream stream = await content.ReadAsStreamAsync().ConfigureAwait(continueOnCapturedContext: false);
            using StreamReader streamReader = new StreamReader(stream);
            using JsonTextReader jsonTextReader = new JsonTextReader(streamReader);
            return jsonSerializer.Deserialize<T>(jsonTextReader);
        }
    }
}
