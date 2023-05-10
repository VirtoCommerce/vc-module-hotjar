using System.Threading.Tasks;

namespace VirtoCommerce.Hotjar.Core.Services
{
    public class HotjarSettings
    {
        public bool EnableTracking { get; set; }
        public string SiteId { get; set; }
        public int HotjarVersion { get; set; } = 6;
    }

    public interface IHotjarSettingsManager
    {
        Task<HotjarSettings> GetAsync(string storeId);
    }
}
