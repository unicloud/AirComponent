using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniCloud.Domain.Repositories.EntityFramework.ModelConfigurations
{
    public interface IModelConfigurations
    {
        /// <summary>
        /// 获取数据库类型
        /// </summary>
        /// <returns></returns>
        string GetDatabaseType();

        /// <summary>
        /// 获取数据库连接
        /// </summary>
        DbConnection GetDbConnection();

        /// <summary>
        /// 增加数据库表配置
        /// </summary>
        /// <param name="modelBuilder"></param>
        void AddConfiguration(DbModelBuilder modelBuilder);
    }
}
