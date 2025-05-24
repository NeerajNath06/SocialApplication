using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SocialApplication.Application.Utilities
{
    internal sealed class ErrorModelConverter : Newtonsoft.Json.JsonConverter
    {
        private const int MinimumProperties = 2;

        private readonly List<string> _propertyMapping = new List<string>
           {
               "copyrights",
               "executionTimeInMilliseconds",
               "message",
               "numberOfElements",
               "elements",
               "statusCode"
           };

        public override bool CanWrite => false;

        public override bool CanConvert(Type typeToConvert)
        {
            // Implement logic to determine if the type can be converted  
            return typeToConvert.GetTypeInfo().IsClass;
        }

        public override void WriteJson(JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer options)
        {
            // Implement serialization logic here  
            throw new NotSupportedException();
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            // Implement deserialization logic here  
            try
            {
                object obj = Activator.CreateInstance(objectType);
                List<PropertyInfo> infos = objectType.GetTypeInfo().DeclaredProperties.ToList();
                JObject jObject = JObject.Load(reader);
                int num = 0;
                foreach (JProperty jsonProperty in jObject.Properties())
                {
                    if (_propertyMapping.Exists((x) => x.Contains(jsonProperty.Name, StringComparison.OrdinalIgnoreCase))) ;
                    {
                        num++;
                    }
                    PropertyInfo propertyInfo = infos.FirstOrDefault((pi) => pi.CanWrite && pi.GetCustomAttribute<JsonPropertyAttribute>().PropertyName == jsonProperty.Name);

                    propertyInfo?.SetValue(obj, jsonProperty.Value.ToObject(propertyInfo.PropertyType, serializer));
                }
                return num > 2 ? obj : null;
            }
            catch (Exception ex)
            {
                throw new JsonSerializationException($"Error deserializing object of type {objectType.Name}: {ex.Message}", ex);
            }
        }

    }
}
