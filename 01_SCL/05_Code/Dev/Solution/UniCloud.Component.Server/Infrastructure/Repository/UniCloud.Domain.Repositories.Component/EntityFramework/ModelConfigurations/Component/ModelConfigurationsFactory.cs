using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniCloud.Domain.Repositories.EntityFramework.ModelConfigurations.Component
{
    public class ModelConfigurationsFactory
    {
        private static ModelConfigurationsFactory _modelConfigurationsFactory;
        private readonly List<IModelConfigurations> _modelConfigurations;

        public ModelConfigurationsFactory()
        {
            _modelConfigurations = new List<IModelConfigurations>();
            InitData();
        }

        private void InitData()
        {
            _modelConfigurations.Add(new SqlServerConfigurations());
            _modelConfigurations.Add(new OracleConfigurations());

        }

        public static ModelConfigurationsFactory GetInstance()
        {
            return _modelConfigurationsFactory ?? (_modelConfigurationsFactory = new ModelConfigurationsFactory());
        }

        public IModelConfigurations GetModelConfigurationsByDatabaseType(string databaseType)
        {
            return _modelConfigurations.FirstOrDefault(configurations => configurations != null && configurations.GetDatabaseType().Equals(databaseType, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
