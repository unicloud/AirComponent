using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Domain.Repositories.EntityFramework.ModelConfigurations.SqlServer;
using UniCloud.Infrastructure.CryptographyUtil;

namespace UniCloud.Domain.Repositories.EntityFramework.ModelConfigurations.Component
{
    public class SqlServerConfigurations : IModelConfigurations
    {
        /// <summary>
        /// 获取数据库类型
        /// </summary>
        /// <returns></returns>
        public string GetDatabaseType()
        {
            return "SqlServer";
        }

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <returns></returns>
        public DbConnection GetDbConnection()
        {
            string encryptConnectionString = ConfigurationManager.ConnectionStrings["ComponentSql"].ToString();
            string connectionString = ConnStringPasswordDecrypt.DecryptConnectionString(encryptConnectionString);
            DbConnection dbConnection = DbProviderFactories.GetFactory("System.Data.SqlClient").CreateConnection();
            if (dbConnection != null)
            {
                dbConnection.ConnectionString = connectionString;
            }
            return dbConnection;
        }

        public void AddConfiguration(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CcpLimitConfiguration())
                .Add(new CcpMainConfiguration())
                .Add(new CcpPnConfiguration())
                .Add(new IntUnitConfiguration())
                .Add(new AcIntUnitUtilizaConfiguration())
                .Add(new PnRegConfiguration())
                .Add(new SnHistoryConfiguration())
                .Add(new SnHistoryUnitConfiguration())
                .Add(new SnRegConfiguration())
                .Add(new WfHistoryConfiguration())
                .Add(new WorkScopeConfiguration())
                .Add(new CcinConfiguration())
                .Add(new CcOrderConfiguration())
                .Add(new CcoutConfiguration())
                .Add(new OilHistoryConfiguration())
                .Add(new OilAnalysisConfiguration())
                .Add(new PartsMonitorConfiguration())
                .Add(new PartsMonitorDetailConfiguration())
                .Add(new ScnAcorderConfiguration())
                .Add(new ScnItemConfiguration())
                .Add(new ScnMainConfiguration())
                .Add(new EgtMarginConfiguration())
                .Add(new AttactDocumentConfiguration())
                .Add(new MajorEventConfiguration())
                .Add(new AirBusMSCNConfiguration())
                .Add(new AdsbComplyConfiguration())
                .Add(new AdsbConfiguration())
                .Add(new AcStructureConfiguration());
        }
    }
}
