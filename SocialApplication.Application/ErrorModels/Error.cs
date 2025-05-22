using SocialApplication.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApplication.Application.ErrorModels
{
    public class Error
    {
        public ErrorCode ErrorCodes { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
