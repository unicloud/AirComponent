#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/9/5 15:46:12
* 文件名：AcConfigurationDbContextInitailizer
* 版本：V1.0.0
*
* 修改者： 时间： 
* 修改说明：
* ========================================================================
*/
#endregion
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniCloud.Domain.Repositories.EntityFramework
{
    public class AcConfigurationDbContextInitailizer : DropCreateDatabaseIfModelChanges<AcConfigurationDbContext>
    {
        /// <summary>
        /// 执行对数据库的初始化操作。
        /// </summary>
        public static void Initialize()
        {
            Database.SetInitializer<AcConfigurationDbContext>(null);
        }
    }
}
