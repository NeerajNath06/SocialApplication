

namespace SocialApplication.Application.ErrorModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class OperationsResult<T>
    {
        public T Payload { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsError { get; set; }
        public Guid ErrorId { get; set; } = Guid.NewGuid();
        public Guid SuccessId { get; set; } = Guid.NewGuid();
        public List<Error> Errors { get; set; } = new List<Error>();
    }
}
