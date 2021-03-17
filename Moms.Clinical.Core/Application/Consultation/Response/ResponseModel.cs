using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Moms.Clinical.Core.Application.Consultation.Response
{
    public class ResponseModel
    {
        public string message { get; set; }

        public Object data { get; set; }

        public HttpStatusCode code { get; set; }
    }
}
