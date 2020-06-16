using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Nexos.MedApp.API.Models
{
    public class ResponseModel
    {
        public int HttpResponse { get; set; }
        public object Response  { get; set; }
        public string ErrorResponse { get; set; }
    }
}
