using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SocialApplication.Application.Formatters.FormatterInterfaces
{
    public interface IFormUrlEncodedParameterFormatter
    {
        string Formate(object value, string formatString);
    }
}
