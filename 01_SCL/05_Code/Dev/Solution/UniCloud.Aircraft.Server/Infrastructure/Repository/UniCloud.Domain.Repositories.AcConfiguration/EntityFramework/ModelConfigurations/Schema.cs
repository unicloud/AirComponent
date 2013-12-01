using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniCloud.Domain.Repositories.EntityFramework.ModelConfigurations
{
    public class Schema
    {
        public static string Name = ConfigurationManager.AppSettings["DatabaseType"].ToLower() == "oracle" ? "UC_AMD" : "dbo";
    }
}
