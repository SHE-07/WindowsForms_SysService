using System;

namespace SysFileClass
{

    public class SysConfigurationApplication
    {


        public class DataInfConf

        {
            public string Name_systems_managment_database { get; set; } = "PostgreSQL";
            public int NumberPort { get; set; } = 5432;
            public string NameDatabase { get; set; } = "REESTR_CREDIT";
            public string OwnerDB { get; set; } = "postgres";
            public string Address { get; set; } = "localhost";
            public string Password { get; set; } = "0";


        }

        public DataInfConf conf { get; set; } = new DataInfConf();
      

    }

    
}
