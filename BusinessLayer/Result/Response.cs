using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Result
{
    public class Response
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; } = new List<string>();

        public Response(bool status, string message, List<ValidationFailure> errors)
        {
            Status = status;
            Message = message;
            if (errors is not null)
            {
                foreach (var error in errors)
                {
                    Errors.Add(error.PropertyName + " - " + error.ErrorMessage);
                }
            }
           
        }
    }
}
