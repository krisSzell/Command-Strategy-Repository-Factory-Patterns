using CarWashServiceBrowser.Models;

namespace CarWashServiceBrowser.Accessibility
{
    public static class ServicesFactory
    {
        public static DefaultService CreateDefault()
        {
            return new DefaultService()
            {
                Name = "Default",
                Price = 0,
                DurationInMinutes = 0
            };
        }

        public static Service CreateSingle(string name, decimal price, int durationInMinutes)
        {
            return new Service()
            {
                Name = name,
                Price = price,
                DurationInMinutes = durationInMinutes
            };
        }
    }
}
