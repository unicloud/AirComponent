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
using UniCloud.Domain.Repositories.EntityFramework.ModelConfigurations.Component;
using UniCloud.Infrastructure.CryptographyUtil;

namespace UniCloud.Domain.Repositories.EntityFramework
{
    public class ComponentDbContext : UniCloudDbContext
    {
        private static readonly string DatabaseType = ConfigurationManager.AppSettings["DatabaseType"].ToString();

        public DbSet<Ccin> Ccins { get; set; }
        public DbSet<CcOrder> CcOrders { get; set; }
        public DbSet<Ccout> Ccouts { get; set; }
        public DbSet<CcpLimit> CcpLimits { get; set; }
        public DbSet<CcpMain> CcpMains { get; set; }
        public DbSet<CcpPn> CcpPns { get; set; }
        public DbSet<IntUnit> IntUnits { get; set; }
        public DbSet<AcIntUnitUtiliza> AcIntUnitUtilizas { get; set; }
        public DbSet<OilHistory> OilHistorys { get; set; }
        public DbSet<OilAnalysis> OilAnalysiss { get; set; }
        public DbSet<PartsMonitor> PartsMonitors { get; set; }
        public DbSet<PartsMonitorDetail> PartsMonitorDetails { get; set; }
        public DbSet<PnReg> PnRegs { get; set; }
        public DbSet<ScnAcorder> ScnAcorders { get; set; }
        public DbSet<ScnItem> ScnItems { get; set; }
        public DbSet<ScnMain> ScnMains { get; set; }
        public DbSet<SnHistory> SnHistorys { get; set; }
        public DbSet<SnHistoryUnit> SnHistoryUnits { get; set; }
        public DbSet<SnReg> SnRegs { get; set; }
        public DbSet<WfHistory> WfHistorys { get; set; }
        public DbSet<WorkScope> WorkScopes { get; set; }
        public DbSet<EgtMargin> EgtMargins { get; set; }
        public DbSet<AttactDocument> AttactDocuments { get; set; }
        public DbSet<MajorEvent> MajorEvents { get; set; }
        public DbSet<AirBusMSCN> AirBusMSCNs { get; set; }
        public DbSet<Adsb> Adsbs { get; set; }
        public DbSet<AdsbComply> AdsbComplys { get; set; }
        public DbSet<AcStructure> AcStructures { get; set; }

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

        public ComponentDbContext()
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

    //public class AircraftDbContext : UniCloudDbContext
    //{
    //    static string sqlName = ConfigurationManager.AppSettings["DatabaseType"].ToLower().Equals("oracle") ? "Aircraft" : "AircraftSql";
    //    static string constr = ConnStringPasswordDecrypt.DecryptConnectionString(ConfigurationManager.ConnectionStrings[sqlName].ToString());

    //    public AircraftDbContext()
    //        : base(constr)
    //    {

    //    }

    //    public DbSet<Ata> Atas { get; set; }

    //    protected override void OnConfiguration(DbModelBuilder modelBuilder)
    //    {
    //        if (ConfigurationManager.AppSettings["DatabaseType"].ToLower().Equals("oracle"))
    //        {
    //            modelBuilder.Configurations.Add(new ModelConfigurations.Oracle.AtaConfiguration());
    //        }
    //        else
    //        {
    //            modelBuilder.Configurations.Add(new ModelConfigurations.SqlServer.AtaConfiguration());
    //        }
    //    }

    //}
}
