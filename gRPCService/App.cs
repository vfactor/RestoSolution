using Data.Collections;
using Data.Models.SQLServer;

namespace gRPCService
{
    public class App
    {
        private readonly RestaurantReadOnlyContext _dbcontext;
        public Information.App AppSettings { get; private set; } = new();
        public App(RestaurantReadOnlyContext dbcontext)
        {
            _dbcontext = dbcontext;
            LoadAppInfo();
        }
        private void LoadAppInfo()
        {
            AppSettings.Info = _dbcontext.AppInfos.First().ToInformation();
            AppSettings.States = new States(_dbcontext).ToInformation();
            AppSettings.ServiceStatuses = new ServiceStatuses(_dbcontext).ToInformation();
            AppSettings.LanguageCodes = new LanguageCodes(_dbcontext).ToInformation();
        }
    }
}
