namespace CarWashServiceBrowser.Models
{
    public interface IService
    {
        string Name { get; set; }
        decimal Price { get; set; }
        int DurationInMinutes { get; set; }
    }
}
