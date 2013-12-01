#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/30 10:17:20

// 文件名：IAtaRepository
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
   /// <summary>
   /// 表示用于Ata聚合根的仓储接口。
   /// </summary>
   public interface IAtaRepository: IRepository<Ata>
   {
      /// <summary>
      /// 实现对Ata的增删改。
      /// 需要添加的Ata对象集合
      /// 需要删除的Ata的ID集合
      /// 需要更新的Ata对象集合
      /// <returns>执行后的更改结果</returns>
      /// </summary>
      void CommitAta(List<Ata> addAtas, IEnumerable<string> deleteIds, List<Ata> updateAtas);
   }
}
