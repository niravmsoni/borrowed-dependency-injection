namespace DependencyInjection.Services
{
    public class SimpleService : IService
    {
        public string GetData()
        {
            return "Simple";
        }
    }
}
