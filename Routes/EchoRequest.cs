using System;

using ServiceStack;

namespace monotest.Routes
{
    [Route("/echo/{Input}")]
    public class EchoRequest
    {
        public string Input { get; set; }      
    }
}

