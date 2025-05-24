

namespace SocialApplication.Application.Formatters.FormatterClasses
{
    using SocialApplication.Application.Formatters.FormatterInterfaces;
    using System;
    using System.Collections.Concurrent;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Serialization;
    public class DefaultFormUrlEncodedParameterFormatter : IFormUrlEncodedParameterFormatter
    {
        private static readonly ConcurrentDictionary<Type, ConcurrentDictionary<string, EnumMemberAttribute>> EnumMeberCache = new ConcurrentDictionary<Type, ConcurrentDictionary<string, EnumMemberAttribute>>();
        public string Formate(object value, string formatString)
        {
            if (value == null)
            {
                return null;
            }
            Type parameterType = value.GetType();
            EnumMemberAttribute enumMemberAttribute = null;
            if (parameterType.GetTypeInfo().IsEnum)
            {
                enumMemberAttribute = EnumMeberCache.GetOrAdd(parameterType, (Type t) => new ConcurrentDictionary<string, EnumMemberAttribute>()).GetOrAdd(value.ToString(), (string val) => parameterType.GetMember(val).First().GetCustomAttribute<EnumMemberAttribute>());
            }

            return string.Format(CultureInfo.InvariantCulture, string.IsNullOrWhiteSpace(formatString) ? "0" : ("{0:" + formatString + "}"), enumMemberAttribute?.Value ?? value);
        }
    }
}
