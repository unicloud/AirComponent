#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/9/16 22:39:33
* 文件名：AircraftDbContext
* 版本：V1.0.0
*
* 修改者： 时间： 
* 修改说明：
* ========================================================================
*/
#endregion
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Domain.Model;
using UniCloud.Domain.Model.AcConfiguration;
using UniCloud.Domain.Repositories.EntityFramework;
using UniCloud.Domain.Repositories.EntityFramework.ModelConfigurations;
using UniCloud.Domain.Repositories.EntityFramework.ModelConfigurations.Aircraft;

namespace UniCloud.Domain.Repositories.EntityFramework
{
    public class AircraftDbContext : UniCloudDbContext
    {
        private static readonly string DatabaseType = ConfigurationManager.AppSettings["DatabaseType"].ToString();

        public DbSet<Ata> Atas { get; set; }

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

        public AircraftDbContext()
            : base(Connection, true)
        {
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
