using System;

namespace monotest.Responses
{
    public class Response<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }

        public Response()
        {
            Success = true;
        }

        public Response(T data)
            : this()
        {
            Data = data;
        }
    }
}

