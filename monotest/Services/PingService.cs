using System;

using ServiceStack;

using monotest.Responses;

namespace monotest.Services
{
    public class PingService : Service
    {
        public object Any(Routes.PingRequest request)
        {
            return new Response<string>("pong");
        }
    }
}

