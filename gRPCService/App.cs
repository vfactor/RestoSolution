using Data.Collections;
using Data.SQLServer;

namespace gRPCService
{
    public class App
    {
        public readonly Information.AppSetting AppSettings;
        private readonly Information.Dictionaries Dictionaries;
        public App(IServiceScopeFactory serviceScopeFactory)
        {
            using var scope = serviceScopeFactory.CreateScope();
            var dbcontext = scope.ServiceProvider.GetRequiredService<RestaurantReadOnlyContext>();

            this.AppSettings = new()
            {
                Info = dbcontext.AppInfos.First().ToInformation(),
                States = new States(dbcontext).ToInformation(),
                ServiceStatuses = new ServiceStatuses(dbcontext).ToInformation(),
                LanguageCodes = new LanguageCodes(dbcontext).ToInformation()
            };

            this.Dictionaries = new Dictionaries(dbcontext).ToInformation();
        }
        public Information.Dictionary GetDictionary(Information.LanguageCode lc) => this.Dictionaries.GetDictionary(lc) ?? throw new KeyNotFoundException($"Dictionary for language code '{lc.Code}' not found.");
    }
}
