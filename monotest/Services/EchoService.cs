using System;

using ServiceStack;

using monotest.Responses;

namespace monotest.Services
{
    public class EchoService : Service
    {
        public object Any(Routes.EchoRequest request)
        {
            if (String.IsNullOrWhiteSpace(request.Input))
                return new Response<string> { Success = false };

            return new Response<string>(request.Input);
        }
    }
}

