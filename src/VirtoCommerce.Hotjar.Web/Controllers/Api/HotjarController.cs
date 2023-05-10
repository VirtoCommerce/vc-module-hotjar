using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtoCommerce.Hotjar.Core;
using VirtoCommerce.Hotjar.Core.Services;
using VirtoCommerce.Platform.Core.Settings;

namespace VirtoCommerce.Hotjar.Web.Controllers.Api
{
    [Route("api/hotjar")]
    public class HotjarController : Controller
    {
        private readonly IHotjarSettingsManager _settings;
        const string HotjarHomeSiteRedirectUrl = "https://insights.hotjar.com/site/list";

        public HotjarController(IHotjarSettingsManager settings, ISettingsManager settingsManager)
        {
            _settings = settings;
        }

        [HttpGet]
        [Route("{storeId}")]
        public Task<HotjarSettings> GetStoreSettings(string storeId)
        {
            return _settings.GetAsync(storeId);
        }

        [HttpGet]
        [Route("redirect")]
        [Authorize(ModuleConstants.Security.Permissions.Access)]
        public ActionResult Redirect()
        {
            return Redirect(HotjarHomeSiteRedirectUrl);
        }

    }
}
