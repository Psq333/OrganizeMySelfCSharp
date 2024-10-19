using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizeMySelf.Utilities
{
    internal class APIResponse<T>
    {
        public T Data { get; set; }
        public string ContentType { get; set; }
        public int StatusCode { get; set; }
    }
}
