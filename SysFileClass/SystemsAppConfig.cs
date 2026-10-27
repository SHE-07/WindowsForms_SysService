using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysFileClass
{
    /// <summary>
    /// Класс SysFileClass - отвечает за управление общими настройками программы
    /// </summary>
    public  class SystemsAppConfig
    {
        public SysConfigurationApplication application { get; set;  }
        public SysLogFile sysLog { get; set; }
    }

}
