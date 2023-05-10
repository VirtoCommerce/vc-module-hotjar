using System.Collections.Generic;
using VirtoCommerce.Platform.Core.Settings;

namespace VirtoCommerce.Hotjar.Core;

public static class ModuleConstants
{
    public static class Security
    {
        public static class Permissions
        {
            public const string Access = "Hotjar:access";

            public static string[] AllPermissions { get; } =
            {
                Access
            };
        }
    }

    public static class Settings
    {
        public static class General
        {
            public static SettingDescriptor EnableTracking { get; } = new SettingDescriptor
            {
                Name = "Hotjar.EnableTracking",
                GroupName = "Hotjar",
                ValueType = SettingValueType.Boolean,
                DefaultValue = false,
            };

            public static SettingDescriptor SiteId { get; } = new SettingDescriptor
            {
                Name = "Hotjar.SiteId",
                GroupName = "Hotjar",
                ValueType = SettingValueType.ShortText,
                DefaultValue = string.Empty,
            };

            public static IEnumerable<SettingDescriptor> AllSettings
            {
                get
                {
                    yield return EnableTracking;
                    yield return SiteId;
                }
            }

        }

        public static IEnumerable<SettingDescriptor> StoreLevelSettings
        {
            get
            {
                yield return General.EnableTracking;
                yield return General.SiteId;
            }
        }

    }
}
