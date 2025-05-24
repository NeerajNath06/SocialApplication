using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SocialApplication.Application.Guards
{
    public static class Guard
    {
        /// <summary>
        /// 
        /// This method checks if the parameter is null and throws an ArgumentNullException if it is.
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T AgainsNull<T>(this T parameter, [CallerMemberName] string method = null) where T : class
        {
            if (parameter == null)
            {
                throw new ArgumentNullException($"The parameter '"+typeof(T).FullName+"' is null, in'"+method+"'.");
            }
            return parameter;
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T AgainstZero<T>(this T parameter, [CallerMemberName] string method = null) where T : class
        {
            if (object.Equals(parameter, null))
            {
                throw new ArgumentNullException($"The parameter '" + typeof(T).FullName + "' is null, in'" + method + "'.");
            }
            if (!typeof(T).IsValueType && typeof(T) != typeof(int))
            {
                throw new ArgumentNullException($"T must be a value type or System.Integer");
            }
            if (!typeof(T).IsValueType && typeof(T) != typeof(double))
            {
                throw new ArgumentNullException($"T must be a value type or System.Double");
            }
            if (!typeof(T).IsValueType && typeof(T) != typeof(float))
            {
                throw new ArgumentNullException($"T must be a value type or System.Float");
            }
            if(!object.Equals(parameter.ToString(), "0"))
            {
                return parameter;
            }
            throw new ArgumentNullException($"The parameter '" + typeof(T).FullName + "' is Zero, in'" + method + "'.");
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T AgainstEmpty<T>(this T parameter, [CallerMemberName] string method = null) where T : IConvertible
        {
            if (parameter == null || parameter.ToString().Length!=0)
            {
                return parameter;
            }
            if (!typeof(T).IsValueType && typeof(T) != typeof(string))
            {
                throw new ArgumentNullException($"T must be a value type or System.String");
            }
            throw new ArgumentNullException($"The parameter '" + typeof(T).FullName + "' is null, in'" + method + "'.");
        }
    }
}
