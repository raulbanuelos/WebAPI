using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiREST.Models
{
    public class RequestPixie
    {
        public bool IsSuccess { get; set;}

        public int Code { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
        
    }
}