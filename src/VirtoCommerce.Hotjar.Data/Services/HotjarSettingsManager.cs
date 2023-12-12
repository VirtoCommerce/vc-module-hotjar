using System.Threading.Tasks;
using VirtoCommerce.Hotjar.Core.Services;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Settings;
using VirtoCommerce.StoreModule.Core.Services;
using HotjarSettingsConstants = VirtoCommerce.Hotjar.Core.ModuleConstants.Settings.General;

namespace VirtoCommerce.Hotjar.Data.Services
{
    public class HotjarSettingsManager : IHotjarSettingsManager
    {
        readonly IStoreService _storeService;

        public HotjarSettingsManager(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public virtual async Task<HotjarSettings> GetAsync(string storeId)
        {
            var retVal = new HotjarSettings { EnableTracking = false };

            var store = await _storeService.GetByIdAsync(storeId);
            if (store == null)
                return retVal;

            retVal.SiteId = store.Settings.GetValue<string>(HotjarSettingsConstants.SiteId);
            if (!string.IsNullOrEmpty(retVal.SiteId))
            {
                retVal.EnableTracking = store.Settings.GetValue<bool>(HotjarSettingsConstants.EnableTracking);
            }

            return retVal;
        }
    }
}
