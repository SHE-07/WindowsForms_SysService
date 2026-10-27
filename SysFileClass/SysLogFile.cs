using System;
using System.IO;

namespace SysFileClass
{
    /// <summary>
    /// Класс для работы с log файлами
    /// </summary>
    public class SysLogFile
    {
        /// <summary>
        /// Поле с названием по умолчанию лог файла
        /// </summary>
        private readonly string _name_log_file = "applog.txt";

        /// <summary>
        /// Путь до файла лог
        /// </summary>
        private readonly string _path_to_file_sys;

        /// <summary>
        /// Свойство название файла лог
        /// </summary>
        public string Name_lof_file => _name_log_file;

        public SysLogFile()
        {
            _path_to_file_sys = Path.Combine(Directory.GetCurrentDirectory(), _name_log_file);

            if (!File.Exists(_path_to_file_sys))
            {
                using (File.Create(_path_to_file_sys)) { }
            }
        }

        /// <summary>
        /// Записывает в лог файл ошибку
        /// </summary>
        /// <param name="ex"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void WriteErrorInLog(object e, Exception ex)
        {
            if (ex == null)
            {
                throw new ArgumentNullException(nameof(ex), "Параметр ошибка - пуст !");
            }

            string textlog = $"[{DateTimeOffset.Now:dd.MM.yyyy HH:mm:ss}]:\t{ex.Message}\t{ex.InnerException}\t{ex.Source}\t{ex.StackTrace}";

            using (var streamw = new StreamWriter(_path_to_file_sys, true))
            {
                streamw.WriteLine(textlog);
            }
        }
    }
}