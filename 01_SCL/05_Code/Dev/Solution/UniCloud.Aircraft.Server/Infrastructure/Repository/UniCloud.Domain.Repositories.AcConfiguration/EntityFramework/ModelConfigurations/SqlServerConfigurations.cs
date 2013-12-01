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

namespace UniCloud.Domain.Repositories.EntityFramework.ModelConfigurations
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
            string encryptConnectionString = ConfigurationManager.ConnectionStrings["AcConfigurationSql"].ToString();
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
            modelBuilder.Configurations
                        .Add(new AcCategoryConfiguration())
                        .Add(new AcConfigConfiguration())
                        .Add(new AcModelConfiguration())
                        .Add(new AcRegConfiguration())
                        .Add(new AcregLicenseConfiguration())
                        .Add(new AtaConfiguration())
                        .Add(new AcTypeConfiguration())
                        .Add(new LicenseTypeConfiguration());
        }
    }
}
