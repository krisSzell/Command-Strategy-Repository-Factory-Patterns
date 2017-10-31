namespace CarWashServiceBrowser.Models
{
    public class DefaultService : IService
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int DurationInMinutes { get; set; }
    }
}
