using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Domain.Repositories.EntityFramework.ModelConfigurations.Oracle;
using UniCloud.Infrastructure.CryptographyUtil;

namespace UniCloud.Domain.Repositories.EntityFramework.ModelConfigurations
{
    public class OracleConfigurations : IModelConfigurations
    {
        /// <summary>
        /// 获取数据库类型
        /// </summary>
        /// <returns></returns>
        public string GetDatabaseType()
        {
            return "Oracle";
        }

        /// <summary>
        ///获取数据库连接 
        /// </summary>
        /// <returns></returns>
        public DbConnection GetDbConnection()
        {
            string encryptConnectionString = ConfigurationManager.ConnectionStrings["AcConfiguration"].ToString();
            string connectionString = ConnStringPasswordDecrypt.DecryptConnectionString(encryptConnectionString);
            DbConnection dbConnection = DbProviderFactories.GetFactory("Oracle.DataAccess.Client").CreateConnection();
            if (dbConnection != null)
            {
                dbConnection.ConnectionString = connectionString;
            }
            return dbConnection;
        }

        /// <summary>
        /// 增加数据库表配置
        /// </summary>
        /// <param name="modelBuilder"></param>
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
