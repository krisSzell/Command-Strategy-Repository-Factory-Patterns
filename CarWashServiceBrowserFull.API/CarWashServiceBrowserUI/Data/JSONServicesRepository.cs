using CarWashServiceBrowserFull.API.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CarWashServiceBrowserUI.Data
{
    public class JSONServicesRepository
    {
        private readonly string _baseUrl = "http://localhost:49266";

        public IEnumerable<Service> GetAll()
        {
            var client = new RestClient($"{_baseUrl}/api/services");
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<List<Service>>(response.Content);
        }

        public Service GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Service GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Add(Service obj)
        {
            var client = new RestClient($"{_baseUrl}/api/services");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(JsonConvert.SerializeObject(obj));
            client.Execute(request);
        }

        public void Remove(Service obj)
        {
            var id = obj.ServiceId;
            var client = new RestClient($"{_baseUrl}/api/services/{id}");
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("content-type", "application/json");
            client.Execute(request);
        }

        public void Update(int id, Service updated)
        {
            var client = new RestClient($"{_baseUrl}/api/services/{id}");
            var request = new RestRequest(Method.PUT);
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(JsonConvert.SerializeObject(updated));
            client.Execute(request);
        }
    }
}
