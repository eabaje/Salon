using System;
using System.Collections.Generic;
using System.Text;

namespace Salon.Application.DTO
{
    public class UserResponce
    {
        public string Id { get; }
        public bool Success { get; }
        public IEnumerable<Error> Errors { get; }


        public UserResponce(string id, bool success = false, IEnumerable<Error> errors = null)
        {
            Id = id;
            Success = success;
            Errors = errors;
        }
    }
}
