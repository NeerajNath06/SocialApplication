using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApplication.Application.Formatters.FormatterInterfaces
{
    public interface IContentSerializer
    {
        Task<HttpContent> SerializeAsync<T>(T content);
        Task<T> DeserializeAsync<T>(HttpContent content);
    }
}
