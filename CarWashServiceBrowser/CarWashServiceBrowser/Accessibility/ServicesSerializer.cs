using CarWashServiceBrowser.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarWashServiceBrowser.Accessibility
{
    public class ServicesSerializer
    {
        public List<Service> Deserialize(string content)
        {
            return JsonConvert.DeserializeObject<List<Service>>(content);
        }

        public string Serialize(List<Service> obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}
