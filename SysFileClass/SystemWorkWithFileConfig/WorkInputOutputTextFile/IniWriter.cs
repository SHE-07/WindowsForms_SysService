using System;
using System.Runtime.InteropServices;
using System.Text;
using SystemWorkWithFileConfig.DataClass;

namespace SystemWorkWithFileConfig.WorkInputOutputTextFile
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


        /// <summary>
        /// Метод принимает объект SysConfigurationApplication записывает значения параметров в файл конфигурации 
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="filePath"></param>
        public static void WriteSettings(SysConfigurationApplication settings, string filePath)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException($"\"{nameof(filePath)}\" не может быть неопределенным или пустым.", nameof(filePath));
            }

            WritePrivateProfileString("Database", "SMDB", settings.conf.Name_systems_managment_database, filePath);
            WritePrivateProfileString("Database", "namedatabase", settings.conf.NameDatabase, filePath);
            WritePrivateProfileString("Database", "port", settings.conf.NumberPort.ToString(), filePath);
            WritePrivateProfileString("Database", "address", settings.conf.Address, filePath);

        }
        public static SysConfigurationApplication ReadSettings(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException($"\"{nameof(filePath)}\" не может быть пустым или содержать только пробел.", nameof(filePath));
            }

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
            if (string.IsNullOrEmpty(section))
            {
                throw new ArgumentException($"\"{nameof(section)}\" не может быть неопределенным или пустым.", nameof(section));
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException($"\"{nameof(key)}\" не может быть неопределенным или пустым.", nameof(key));
            }

            if (string.IsNullOrEmpty(def))
            {
                throw new ArgumentException($"\"{nameof(def)}\" не может быть неопределенным или пустым.", nameof(def));
            }

            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException($"\"{nameof(filePath)}\" не может быть неопределенным или пустым.", nameof(filePath));
            }

            var sb = new StringBuilder(1024);
            GetPrivateProfileString(section, key, def, sb, sb.Capacity, filePath);
            return sb.ToString();
        }
    }



}
