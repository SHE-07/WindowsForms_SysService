using System.Runtime.InteropServices;
using System.Text;

namespace SysFileClass
{

    /// <summary>
    /// Класс для сохранения настроек в INI файл 
    /// </summary>
    public static class IniWriter
    {
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString(
            string section, string key, string val, string filePath);
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileSectionNames(
        StringBuilder lpszReturnBuffer, int nSize, string lpFileName);
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(
            string section, string key, string def,
            StringBuilder retVal, int size, string filePath);
        public static void WriteSettings(SysConfigurationApplication settings, string filePath)
        {
            WritePrivateProfileString("Database", "SMDB", settings.conf.Name_systems_managment_database, filePath);
            WritePrivateProfileString("Database", "namedatabase", settings.conf.NameDatabase, filePath);
            WritePrivateProfileString("Database", "port", settings.conf.NumberPort.ToString(), filePath);
            WritePrivateProfileString("Database", "address", settings.conf.Address, filePath);

        }
        public static SysConfigurationApplication ReadSettings(string filePath)
        {
            var result = new SysConfigurationApplication();
          

            result.conf.Name_systems_managment_database =
                ReadValue("Database", "SMDB", "", filePath);

            result.conf.NameDatabase =
                ReadValue("Database", "namedatabase", "", filePath);

            result.conf.NumberPort =
                int.TryParse(ReadValue("Database", "port", "0", filePath),
                             out var port) ? port : 0;


            return result;
        }
        private static string ReadValue(string section, string key, string def, string filePath)
        {
            var sb = new StringBuilder(1024);
            GetPrivateProfileString(section, key, def, sb, sb.Capacity, filePath);
            return sb.ToString();
        }
    }


    
}
