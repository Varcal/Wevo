using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;

namespace Wevo.Api.Models
{
    public class ObjetoRetorno
    {
        public HttpStatusCode StatusCode { get; private set; }
        public object Data { get; private set; }
        public IEnumerable<string> ErrorMessages { get; private set; }

        public ObjetoRetorno(HttpStatusCode statusCode, object data, [Optional]IEnumerable<string> errorMessages)
        {
            StatusCode = statusCode;
            Data = data;
            ErrorMessages = errorMessages;
        }
    }
}
