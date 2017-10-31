namespace CarWashServiceBrowser.Models
{
    public class Service : IService
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int DurationInMinutes { get; set; }

        public override string ToString()
        {
            return $"{Name}, cena: {Price} zł, czas trwania: {DurationInMinutes} min";
        }
    }
}
