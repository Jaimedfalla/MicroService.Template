using FluentValidation.Results;
using System.Collections.Generic;

namespace MicroService.Template.Transversal.Common
{
    public class ResponseGeneric<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; } = false;
        public string Message { get; set; }
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}
