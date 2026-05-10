using Grpc.Net.Client;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("http://localhost:5109");

            var client = new Information.App.AppClient(channel);

            var response = client.GetSetting(new Google.Protobuf.WellKnownTypes.Empty());
        }
    }
}
