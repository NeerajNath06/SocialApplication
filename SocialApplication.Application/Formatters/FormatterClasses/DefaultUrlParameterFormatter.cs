

namespace SocialApplication.Application.Formatters.FormatterClasses
{
    using SocialApplication.Application.Formatters.Attributes;
    using SocialApplication.Application.Formatters.FormatterInterfaces;
    using System.Collections.Concurrent;
    using System.Globalization;
    using System.Reflection;
    using System.Runtime.Serialization;
    public class DefaultUrlParameterFormatter : IUrlParameterFormatter
    {
        private static readonly ConcurrentDictionary<Type, ConcurrentDictionary<string, EnumMemberAttribute>> EnumMeberCache = new ConcurrentDictionary<Type, ConcurrentDictionary<string, EnumMemberAttribute>>();
        public string Formate(object value, ParameterInfo parameterInfo)
        {
            string text = parameterInfo.GetCustomAttribute<QueryAttribute>(inherit: true)?.Format;
            EnumMemberAttribute enumMemberAttribute = null;
            if (value != null && parameterInfo.ParameterType.GetTypeInfo().IsEnum)
            {
                enumMemberAttribute = EnumMeberCache.GetOrAdd(parameterInfo.ParameterType, (Type t) => new ConcurrentDictionary<string, EnumMemberAttribute>()).GetOrAdd(value.ToString(), (string val) => parameterInfo.ParameterType.GetMember(val).First().GetCustomAttribute<EnumMemberAttribute>());
            }

            if (value != null)
            {
                return string.Format(CultureInfo.InvariantCulture, string.IsNullOrWhiteSpace(text) ? "0" : ("{0:" + text + "}"), enumMemberAttribute?.Value ?? value);
            }
            return null;
        }
    }
}
