#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/30 10:17:20

// 文件名：IAcRegRepository
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Collections.Generic;
using UniCloud.Domain.Model;

namespace UniCloud.Domain.Repositories
{
    public interface IAcRegRepository : IRepository<AcReg>
    {
        void DeleteAcRegLicenseType(AcReg acReg, IEnumerable<AcregLicense> acregLicenses);

        /// <summary>
        /// 实现对AcReg的增删改。
        /// 需要添加的AcReg对象集合
        /// 需要删除的AcReg的ID集合
        /// 需要更新的AcReg对象集合
        /// <returns>执行后的更改结果</returns>
        /// </summary>
      void CommitAcReg(List<AcReg> addAcRegs, IEnumerable<string> deleteIds, List<AcReg> updateAcRegs);
    }
}
