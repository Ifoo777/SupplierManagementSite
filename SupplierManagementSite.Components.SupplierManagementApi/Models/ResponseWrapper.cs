using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Components.SupplierManagementApi.Models
{
    public class ResponseWrapper<T>
    {
        public T Response { get; set; }
        public string ResponseMessage { get; set; } = "";
        public HttpStatusCode HttpStatusCode { get; set; }
        public bool IsSuccess { get; set; }
    }
}
