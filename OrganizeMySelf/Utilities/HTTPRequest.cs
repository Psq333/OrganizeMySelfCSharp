using OrganizeMySelf.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizeMySelf.Utilities
{
    public class HTTPRequest<T>
    {
        public static List<T> Request(String path, String classe, Method method, T jsonToSend)
        {
            var client = new RestClient(path);
            var request = new RestRequest(classe, method);
            if(method == Method.Post || method == Method.Put)
            {
                request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
                request.RequestFormat = DataFormat.Json;
            }
            return client.Execute<List<T>>(request).Data;
        }

        public static int RequestPost(String path, String classe, Method method, T jsonToSend)
        {
            var client = new RestClient(path);
            var request = new RestRequest(classe, method);
            if (method == Method.Post || method == Method.Put)
            {
                request.AddParameter("application/json", jsonToSend, ParameterType.RequestBody);
                request.RequestFormat = DataFormat.Json;
            }
            return client.Execute<int>(request).Data;
        }
    }
}
