using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Result
{
    public class ResponseEntity<T> : Response
    {
        public T Entity { get; set; }
        public ResponseEntity(bool status, string message,List<ValidationFailure> errors, T entity) : base(status, message,errors)
        {
            Entity = entity;
        }
    }
}
