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
                IsPublic = true,
            };

            public static SettingDescriptor SiteId { get; } = new SettingDescriptor
            {
                Name = "Hotjar.SiteId",
                GroupName = "Hotjar",
                ValueType = SettingValueType.Integer,
                DefaultValue = 0,
                IsPublic = true,
            };

            public static SettingDescriptor SnippetVersion { get; } = new SettingDescriptor
            {
                Name = "Hotjar.SnippetVersion",
                GroupName = "Hotjar",
                ValueType = SettingValueType.Integer,
                DefaultValue = 6,
                IsPublic = true,
            };

            public static IEnumerable<SettingDescriptor> AllSettings
            {
                get
                {
                    yield return EnableTracking;
                    yield return SiteId;
                    yield return SnippetVersion;
                }
            }

        }

        public static IEnumerable<SettingDescriptor> StoreLevelSettings
        {
            get
            {
                yield return General.EnableTracking;
                yield return General.SiteId;
                yield return General.SnippetVersion;
            }
        }

    }
}
