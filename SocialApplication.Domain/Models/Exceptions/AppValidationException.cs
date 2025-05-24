

namespace SocialApplication.Domain.Models.Exceptions
{
    using SocialApplication.Domain.Models.Exceptions.Shared;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class AppValidationException : Exception
    {
        public ValidationErrorResponseModelElement ResponseModelElement { get; } = new ValidationErrorResponseModelElement();

        public AppValidationException(string title, string message) : base(message)
        {
            ResponseModelElement.Title = title;
            ResponseModelElement.Message = message;
        }

        public AppValidationException(ValidationErrorResponseModelElement modelElement) : base(modelElement?.Message)
        {
            ResponseModelElement = modelElement;
        }
    }
}
