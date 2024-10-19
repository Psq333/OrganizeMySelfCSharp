using Newtonsoft.Json;
using OrganizeMySelf.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

            var response = client.Execute(request);

            // Verifica lo status della risposta
            if (response.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.Content}");
                return null;
            }
            else
            {
                Console.WriteLine($"Response Content: {response.Content}");

                // Deserializza la risposta come ApiResponse<T>
                var apiResponse = JsonConvert.DeserializeObject<APIResponse<List<T>>>(response.Content);

                // Restituisci solo i dati
                return apiResponse.Data;
            }
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
            var x = JsonConvert.DeserializeObject<APIResponse<int>>(client.Execute(request).Content);
            return x.Data;
        }

        public static bool RequestDelete(String path, String classe, Method method, int id)
        {
            var client = new RestClient(path);
            var request = new RestRequest(classe, method);
            if (method == Method.Delete)
            {
                request.AddParameter("id",id.ToString());
                return client.Execute<bool>(request).Data;
            }
            return false;
        }
    }
}
