using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VideoSharingPlatform.Shared.Dtos
{
    public class Response<T>        // takes generic parameter
    {
        public T Data { get; private set; }     //data that will be send when succeed


        [JsonIgnore]
        public int StatusCode { get; private set; }     // there is already a returned response statuscode when it is requested
                                                        // to a API end point so ignore it, no need to put it into response
                                                        // but needed in the code(software)

        [JsonIgnore]
        public bool IsSuccessful { get; private set; }

        public List<string> Errors { get; private set; }


        // Static Factory Method
        public static Response<T> Success(T data, int statusCode)       // data and status code
        {
            return new Response<T> { StatusCode = statusCode, Data = data, IsSuccessful = true };
        }

        public static Response<T> Success(int status)                   // just status code
        {
            return new Response<T> { StatusCode = status, Data = default(T), IsSuccessful = true };
        }

        public static Response<T> Fail(List<string> errors, int statusCode)     // errors and status code
        {
            return new Response<T>
            {
                StatusCode = statusCode,
                Errors = errors,
                IsSuccessful = false
            };
        }

        public static Response<T> Fail(string error, int statusCode)            // an error and status code
        {
            return new Response<T> { IsSuccessful = false, StatusCode = statusCode, Errors = new List<string>() { error } };
        }
    }
}
