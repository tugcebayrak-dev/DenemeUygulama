using Microsoft.Win32;

namespace DenemeUygulama.Data.Araclar
{
    public static class RegeditHelper
    {
        public static string Oku(RegistryHive konum, string subKey, string key, RegistryView view = RegistryView.Default)
        {
            var baseKey = RegistryKey.OpenBaseKey(konum, view);
            var regSubKey = baseKey.OpenSubKey(subKey, RegistryKeyPermissionCheck.ReadSubTree);
            return (string)regSubKey.GetValue(key);
        }
        public static void Yaz(RegistryHive konum, string subKey, string key, string value, RegistryView view = RegistryView.Default)
        {
            var baseKey = RegistryKey.OpenBaseKey(konum, view);
            var regSubKey = baseKey.CreateSubKey(subKey, RegistryKeyPermissionCheck.ReadWriteSubTree);
            regSubKey.SetValue(key, value);
        }
    }
}
