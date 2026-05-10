using Grpc.Core;
using Information;
using Google.Protobuf.WellKnownTypes;

namespace gRPCService.Services
{
    public class AppService(App app) : Information.App.AppBase
    {
        public override Task<AppSetting> GetSetting(Empty request, ServerCallContext context)
        {
            return Task.FromResult(app.AppSettings);
        }

        public override Task<Dictionary> GetDictionary(LanguageCode lc, ServerCallContext context)
        {
            return Task.FromResult(app.GetDictionary(lc));
        }
    }
}
