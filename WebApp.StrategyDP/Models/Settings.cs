using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.StrategyDP.Enums;

namespace WebApp.StrategyDP.Models
{
    public class Settings
    {

        public static string claimDatabaseType = "databasetype";

        public EDatabaseType DatabaseType;
        public EDatabaseType GetDefaultDatabaseType => EDatabaseType.SqlServer;
    }

}
