using SystemLoginirovanieEvent.SysFileClass;
using SystemWorkWithFileConfig.DataClass;

namespace SystemWorkWithFileConfig.SysFileClass
{
    /// <summary>
    /// Класс SysFileClass - отвечает за управление общими настройками программы
    /// </summary>
    public class SystemsAppConfig
    {
        public SysConfigurationApplication application { get; set; }
        public SysLogFile sysLog { get; set; }
    }

}
