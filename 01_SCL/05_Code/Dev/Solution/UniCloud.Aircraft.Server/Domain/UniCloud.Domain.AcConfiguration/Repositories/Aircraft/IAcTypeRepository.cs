using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Domain.Model;

namespace UniCloud.Domain.Repositories
{
    public interface IAcTypeRepository : IRepository<AcType>
    {
        void DeleteAcType(AcType acType);

        void DeleteAcModel(AcType acType, IEnumerable<AcModel> acModels);

        void DeleteAcConfig(AcType acType, AcModel acModel, IEnumerable<AcConfig> acConfigs);

        //void DeleteAcTypeAta(AcType acType, IEnumerable<Ata> acTypeAtas);

        /// <summary>
        /// 实现对AcType的增删改。
        /// 需要添加的AcType对象集合
        /// 需要删除的AcType的ID集合
        /// 需要更新的AcType对象集合
        /// <returns>执行后的更改结果</returns>
        /// </summary>
      void CommitAcType(List<AcType> addAcTypes, IEnumerable<string> deleteIds, List<AcType> updateAcTypes);

        /// <summary>
        /// 维护Actype与Ata的关系
        /// </summary>
        /// <param name="acTypes"></param>
        /// <returns></returns>
        List<AcType> ManageAcTypeAta(List<AcType> acTypes);
    }
}
