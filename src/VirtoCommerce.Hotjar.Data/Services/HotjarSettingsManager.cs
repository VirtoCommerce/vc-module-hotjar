using System.Threading.Tasks;
using VirtoCommerce.Hotjar.Core.Services;
using VirtoCommerce.Platform.Core.GenericCrud;
using VirtoCommerce.Platform.Core.Settings;
using VirtoCommerce.StoreModule.Core.Model;

namespace VirtoCommerce.Hotjar.Data.Services
{
    public class HotjarSettingsManager : IHotjarSettingsManager
    {
        readonly ICrudService<Store> _storeService;

        public HotjarSettingsManager(ICrudService<Store> storeService)
        {
            _storeService = storeService;
        }

        public virtual async Task<HotjarSettings> GetAsync(string storeId)
        {
            var retVal = new HotjarSettings { EnableTracking = false };

            var store = await _storeService.GetByIdAsync(storeId);
            if (store == null)
                return retVal;

            retVal.SiteId = store.Settings.GetSettingValue("Hotjar.SiteId", string.Empty);
            if (!string.IsNullOrEmpty(retVal.SiteId))
            {
                retVal.EnableTracking = store.Settings.GetSettingValue("Hotjar.EnableTracking", false);
            }

            return retVal;
        }
    }
}
