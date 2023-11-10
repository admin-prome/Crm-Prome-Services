using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace CRMPromeServices.Models
{
    public class APIResponse
    {
        public APIResponse()
        {
            this.ErrorMessages = new List<string>();
        }
        public HttpStatusCode StatusCode { get; set; }

        public bool IsSuccess { get; set; } = true;

        public List<string> ErrorMessages { get; set; }

        public object Result { get; set; }
    }
}