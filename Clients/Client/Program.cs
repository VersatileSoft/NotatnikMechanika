using System.Threading.Tasks;

namespace NotatnikMechanika.Client
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            await new Application().Build(args);
        }
    }
}
