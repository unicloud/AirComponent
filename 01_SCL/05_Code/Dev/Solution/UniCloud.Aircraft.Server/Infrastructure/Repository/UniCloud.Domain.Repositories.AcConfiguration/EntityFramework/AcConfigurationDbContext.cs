using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Domain.Model;
using UniCloud.Domain.Repositories.EntityFramework.ModelConfigurations;

namespace UniCloud.Domain.Repositories.EntityFramework
{
    public class AcConfigurationDbContext : UniCloudDbContext
    {
        private static readonly string DatabaseType = ConfigurationManager.AppSettings["DatabaseType"].ToString();

        public DbSet<AcCategory> AcCategorys { get; set; }
        public DbSet<AcConfig> AcConfigs { get; set; }
        public DbSet<AcModel> AcModels { get; set; }
        public DbSet<AcReg> AcRegs { get; set; }
        public DbSet<AcregLicense> AcregLicenses { get; set; }
        public DbSet<AcType> AcTypes { get; set; }
        public DbSet<Ata> Atas { get; set; }
        public DbSet<LicenseType> LicenseTypes { get; set; }

        private static DbConnection Connection
        {
            get
            {
                var modelConfigurations =
                    ModelConfigurationsFactory.GetInstance().GetModelConfigurationsByDatabaseType(DatabaseType);
                if (modelConfigurations != null)
                {
                    return modelConfigurations.GetDbConnection();
                }
                else
                {
                    return null;
                }
            }
        }

        public AcConfigurationDbContext()
            : base(Connection, true)
        {
            //关闭自动检测功能
            this.Configuration.AutoDetectChangesEnabled = true;
            //关闭延迟加载功能
            this.Configuration.LazyLoadingEnabled = true;
            
            
        }

        protected override void OnConfiguration(DbModelBuilder modelBuilder)
        {
            var databaseType = ConfigurationManager.AppSettings["DatabaseType"]; 
            var modelConfigurations =
                ModelConfigurationsFactory.GetInstance().GetModelConfigurationsByDatabaseType(databaseType);
            if (modelConfigurations != null)
            {
                modelConfigurations.AddConfiguration(modelBuilder);
            }

        }
    }
}
