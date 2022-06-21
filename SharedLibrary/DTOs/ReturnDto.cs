using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.DTOs
{
    public class ReturnDto<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public string Error { get; set; }   


        public static ReturnDto<T> Success(T data, int statusCode)
        {
            return new ReturnDto<T> { Data = data , StatusCode = statusCode};
        }
        public static ReturnDto<T> Success(int statusCode)
        {
            return new ReturnDto<T> { Data = default, StatusCode = statusCode };
        }

        public static ReturnDto<T> Fail(string errorMessage, int statusCode)
        {
            return new ReturnDto<T> { Error = errorMessage, StatusCode = statusCode };
        }
    }
}
