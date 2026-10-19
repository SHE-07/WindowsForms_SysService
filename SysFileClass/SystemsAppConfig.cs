using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysFileClass
{
    /// <summary>
    /// Класс SysFileClass - отвечает за управление файлом типа log.txt
    /// </summary>
    public class SystemsAppConfig
    {
        /// <summary>
        /// Поле с названием по умолчанию лог файла
        /// </summary>
        private string _name_lof_file = "applog.txt";
        /// <summary>
        /// Путь до файла лог
        /// </summary>
        private string _path_to_file_sys = Path.Combine(Directory.GetCurrentDirectory());

        /// <summary>
        /// Свойство название файла лог
        /// </summary>
        public string Name_lof_file { get { return _name_lof_file; } private set {  } }
        public SystemsAppConfig()
        {
            this._path_to_file_sys = this._path_to_file_sys +'/'+ this._name_lof_file;
            if (File.Exists(this._path_to_file_sys))
            {
                File.Create(this._path_to_file_sys);
            }
        }
        /// <summary>
        /// Записывает в лог файл ошибку
        /// </summary>
        /// <param name="ex"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void WriteErrorInLog(Exception ex)
        {
            if (ex == null)
            {
                throw new ArgumentNullException("Параметр ошибка - пуст !");
            }
            string textlog = $"[{DateTimeOffset.Now:dd:MM:yyyy:HH:mm:ss}]:\t{ex.Message}\t{ex.InnerException}\t{ex.Source}\t{ex.StackTrace}";
            using (var streamw = new StreamWriter(File.OpenWrite(this._path_to_file_sys)))
            {
                streamw.WriteLine(textlog);
                streamw.Dispose();
            }
        }
    }
}
