using System.Reflection;
using System.Runtime.InteropServices;

namespace Voucherly.Sdk
{
    public class VoucherlyApiSettings
    {
        public string ApiKey { get; set; } = string.Empty;

        public string? Os { get; set; } = RuntimeInformation.OSDescription.Replace(Environment.OSVersion.Version.ToString(), string.Empty).Trim();
        public string? OsVersion { get; set; } = Environment.OSVersion.Version.ToString();
        public string? OsFramework { get; set; } = RuntimeInformation.FrameworkDescription;
        public string? App { get; set; } = Assembly.GetEntryAssembly()?.GetName().Name;
        public string? AppVersion { get; set; } = Assembly.GetEntryAssembly()?.GetName().Version?.ToString();
        public string? AppHouse { get; set; } = "Voucherly";
        public string? DeviceType { get; set; }
    }
}
