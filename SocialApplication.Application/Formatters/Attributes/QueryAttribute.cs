

namespace SocialApplication.Application.Formatters.Attributes
{
    using SocialApplication.Application.Enums;
    using System;

    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property)]
    public class QueryAttribute : Attribute
    {
        public string Delimeter { get; protected set; } = ",";
        public string Prefix { get; protected set; }
        public string Format { get; set; }
        public CollectionFormat CollectionFormat { get; set; }
        public QueryAttribute()
        {

        }

        public QueryAttribute(string delimeter)
        {
            Delimeter = delimeter;
        }

        public QueryAttribute(string delimeter, string prefix)
        {
            Delimeter = delimeter;
            Prefix = prefix;
        }

        public QueryAttribute(string delimeter, string prefix, string format)
        {
            Delimeter = delimeter;
            Prefix = prefix;
            Format = format;
        }

        public QueryAttribute(CollectionFormat collectionFormat)
        {
            CollectionFormat = collectionFormat;
        }


    }
}
