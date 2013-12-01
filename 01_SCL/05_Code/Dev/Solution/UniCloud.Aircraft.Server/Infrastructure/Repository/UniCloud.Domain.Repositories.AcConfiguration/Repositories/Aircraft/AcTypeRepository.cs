using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Domain.Model;
using UniCloud.Domain.Repositories;
using UniCloud.Domain.Repositories.EntityFramework;

namespace UniCloud.Domain.Repositories.Repositories
{
    public class AcTypeRepository : EntityFrameworkIntRepository<AcType>, IAcTypeRepository
    {
        private readonly AcConfigurationDbContext _efContext;

        public AcTypeRepository(IRepositoryContext context)
            : base(context)
        {
            _efContext = EFContext.Context as AcConfigurationDbContext;
        }

        public void DeleteAcType(AcType acType)
        {
            if (acType == null)
                return;
            for (int i = acType.Acmodels.Count - 1; i >= 0; i--)
            {
                var acmodel = acType.Acmodels.ElementAt(i);
                for (int j = acmodel.AcConfigs.Count - 1; j >= 0; j--)
                {
                    var acconfig = acmodel.AcConfigs.ElementAt(j);
                    this.DoEntityRegisterDeleted(acconfig);
                }
                this.DoEntityRegisterDeleted(acType.Acmodels.ElementAt(i));
            }
            for (int i = acType.Atas.Count - 1; i >= 0; i--)
            {
                acType.Atas.Remove(acType.Atas.ElementAt(i));
            }
            this.Update(acType);
            this.Remove(acType);
            this.Context.Commit();
        }

        public void DeleteAcModel(AcType acType, IEnumerable<AcModel> acModels)
        {
            if (acType == null || acType.Acmodels == null || acModels == null)
                return;
            for (int i = acType.Acmodels.Count - 1; i >= 0; i--)
            {
                if (acModels.FirstOrDefault(a => a.ID == acType.Acmodels.ElementAt(i).ID)!=null)
                {
                    var acmodel = acType.Acmodels.ElementAt(i);
                    for (int j = acmodel.AcConfigs.Count - 1; j >= 0; j--)
                    {
                        this.DoEntityRegisterDeleted(acmodel.AcConfigs.ElementAt(j));
                    }
                    this.DoEntityRegisterDeleted(acmodel);
                }
            }
            this.Update(acType);
            this.Context.Commit();
        }

        public void DeleteAcConfig(AcType acType, AcModel acModel, IEnumerable<AcConfig> acConfigs)
        {
            if (acType == null || acType.Acmodels == null || acModel.AcConfigs == null || acConfigs==null)
                return;
            var acmodel = acType.Acmodels.FirstOrDefault(a => a.ID == acModel.ID);
            if (acmodel != null)
            {
                for (int i = acmodel.AcConfigs.Count - 1; i >= 0; i--)
                {
                    if (acConfigs.FirstOrDefault(a => a.ID == acmodel.AcConfigs.ElementAt(i).ID)!=null)
                        this.DoEntityRegisterDeleted(acmodel.AcConfigs.ElementAt(i));
                }
                this.Update(acType);
                this.Context.Commit();
            }
        }

        /// <summary>
        /// 实现对AcType的增删改。
        /// 需要添加的AcType对象集合
        /// 需要删除的AcType的ID集合
        /// 需要更新的AcType对象集合
        /// <returns>执行后的更改结果</returns>
        /// </summary>
      public void CommitAcType(List<AcType> addAcTypes,  IEnumerable<string> deleteIds,  List<AcType> updateAcTypes)
        {
            AddAcTypes(addAcTypes);
            DeleteAcTypes(deleteIds);
            UpdateAcTypes(updateAcTypes);
            _efContext.SaveChanges();
        }

        /// <summary>
        /// 增加AcType
        /// </summary>
        /// <param name="addAcTypes">AcType</param>
        private void AddAcTypes(List<AcType> addAcTypes)
        {
            if (addAcTypes != null && addAcTypes.Any())
            {
                //addAcTypes.ForEach(p =>
                //{
                //    foreach (var acModel in p.Acmodels)
                //    {
                //        foreach (var acConfig in acModel.AcConfigs)
                //        {
                //            _efContext.Entry(acConfig).State = EntityState.Added;
                //        }
                //        _efContext.Entry(acModel).State = EntityState.Added;
                //    }
                //    _efContext.Entry(p).State = EntityState.Added;
                //});
                addAcTypes.ForEach(Add);
            }
        }

        /// <summary>
        /// 删除AcType
        /// </summary>
        /// <param name="deleteIds">删除AcType</param>
        private void DeleteAcTypes(IEnumerable<string> deleteIds)
        {
            if (deleteIds != null)
            {
                foreach (string id in deleteIds)
                {
                    var result = GetAcTypeById(id);
                    if (result != null)
                    {
                        for (int i = result.Acmodels.Count - 1; i >= 0; i--)
                        {
                            var acmodel = result.Acmodels.ElementAt(i);
                            for (int j = acmodel.AcConfigs.Count - 1; j >= 0; j--)
                            {
                                var acconfig = acmodel.AcConfigs.ElementAt(j);
                                _efContext.Entry(acconfig).State = EntityState.Deleted;
                            }
                            _efContext.Entry(acmodel).State = EntityState.Deleted;
                        }
                        //移除与ATA的关系
                        for (int i = result.Atas.Count - 1; i >= 0; i--)
                        {
                            result.Atas.Remove(result.Atas.ElementAt(i));
                        }
                        _efContext.Entry(result).State = EntityState.Deleted;
                    }
                }
            }
        }

        /// <summary>
        ///     更新AcType
        /// </summary>
        /// <param name="updateAcTypes">更新的AcType</param>
        private void UpdateAcTypes(List<AcType> updateAcTypes)
        {
            if (updateAcTypes != null && updateAcTypes.Any())
            {
                //待处理集合
                List<AcConfig> beDeleteAcconfigs = new List<AcConfig>();
                List<AcModel> beAddAcmodels = new List<AcModel>();
                List<AcModel> beDeleteAcmodels = new List<AcModel>();

                foreach (var updateObj in updateAcTypes)
                {
                    var obj = GetAcTypeById(updateObj.ID.ToString());
                    if (obj != null)
                    {
                        //_efContext.AcTypes.Attach(obj);
                        obj.Guid = !updateObj.Guid.Equals(new Guid()) ? updateObj.Guid : Guid.NewGuid();
                        obj.Description = updateObj.Description;
                        obj.Manufacturer = updateObj.Manufacturer;
                        obj.AcCategory = updateObj.AcCategory;
                        //如果数据库里面对应的Acmodels集合为空，则直接新增
                        if (obj.Acmodels.Count == 0)
                        {
                            foreach (var model in updateObj.Acmodels)
                            {
                                if (model.AcConfigs.Count == 0)
                                {
                                    beAddAcmodels.Add(model);
                                }
                            }
                        }
                        else  //如果数据库有有记录则进行比对
                        {
                            //如果数据库中有记录，而传进来的为空，则进行删除动作
                            if (updateObj.Acmodels.Count == 0)
                            {
                                foreach (var model in obj.Acmodels)
                                {
                                    if (model.AcConfigs.Count == 0)
                                    {
                                        foreach (var config in model.AcConfigs)
                                        {
                                            beDeleteAcconfigs.Add(config);
                                        }
                                        beDeleteAcmodels.Add(model);
                                    }
                                }
                            }
                            else
                            {
                                //将传入集体与数据库集合进行对比
                                foreach (var acmodel in obj.Acmodels)
                                {
                                    var updateAcModel = updateObj.Acmodels.FirstOrDefault(a => a.Name == acmodel.Name);
                                    //不为空，则更新
                                    if (updateAcModel != null)
                                    {
                                        //数据库存在，进行更新
                                        acmodel.Guid = updateAcModel.Guid.Equals(new Guid()) ? Guid.NewGuid() : updateAcModel.Guid;
                                        acmodel.Description = updateAcModel.Description;
                                        acmodel.AcTypeGuid = obj.Guid;
                                        UpdateAcconfigItems(updateAcModel.AcConfigs.ToList(), acmodel.AcConfigs.ToList());
                                        updateObj.Acmodels.Remove(updateAcModel);
                                    }
                                    {
                                        //数据库有，传入集合没有，则删除
                                        beDeleteAcmodels.Add(acmodel);
                                        beDeleteAcconfigs.AddRange(acmodel.AcConfigs);
                                    }
                                }
                                //余留下来的，都是数据库中没有的，则新增
                                if (updateObj.Acmodels.Count > 0)
                                {
                                    beAddAcmodels.AddRange(updateObj.Acmodels);
                                }
                            }
                        }

                        //
                        foreach (var beDeleteAconfig in beDeleteAcconfigs)
                        {
                            _efContext.Entry(beDeleteAconfig).State = EntityState.Deleted;
                        }
                        foreach (var beDeleteAcmodel in beDeleteAcmodels)
                        {
                            _efContext.Entry(beDeleteAcmodel).State = EntityState.Deleted;
                        }
                        foreach (var beAddAcmodel in beAddAcmodels)
                        {
                            _efContext.Entry(beAddAcmodel).State = EntityState.Added;
                        }


                        //foreach (var acModel in obj.Acmodels)
                        //{
                        //    if (updateObj.Acmodels.FirstOrDefault(a => a.ID == acModel.ID) == null)
                        //        _efContext.Entry(acModel).State = EntityState.Deleted;
                        //}
                        //foreach (var acModel in updateObj.Acmodels)
                        //{
                        //    var acmodel = obj.Acmodels.FirstOrDefault(a => a.ID == acModel.ID);
                        //    if (acmodel != null)
                        //    {
                        //        acmodel.Guid = acModel.Guid.Equals(new Guid())?Guid.NewGuid():acModel.Guid;
                        //        acmodel.Description = acModel.Description;
                        //        acmodel.AcTypeGuid = obj.Guid;
                        //        foreach (var acConfig in acmodel.AcConfigs)
                        //        {
                        //            if (acModel.AcConfigs.FirstOrDefault(a => a.ID == acConfig.ID) == null)
                        //                _efContext.Entry(acConfig).State = EntityState.Deleted;
                        //        }
                        //        foreach (var acConfig in acModel.AcConfigs)
                        //        {
                        //            var config = acmodel.AcConfigs.FirstOrDefault(a => a.ID == acConfig.ID);
                        //            if (config != null)
                        //            {
                        //                config.Guid = acConfig.Guid;
                        //                config.Description = acConfig.Description;
                        //                config.AcModelGuid = acmodel.Guid;
                        //                config.BEW = acConfig.BEW;
                        //                config.BW = acConfig.BW;
                        //                config.BWF = acConfig.BWF;
                        //                config.BWI = acConfig.BWI;
                        //                config.MCC = acConfig.MCC;
                        //                config.MLW = acConfig.MLW;
                        //                config.MMFW = acConfig.MMFW;
                        //                config.MTOW = acConfig.MTOW;
                        //                config.MTW = acConfig.MTW;
                        //                config.MZFW = acConfig.MZFW;
                        //            }
                        //            else
                        //            {
                        //                _efContext.Entry(acConfig).State = EntityState.Added;
                        //            }
                        //        }
                        //    }
                        //    else
                        //    {
                        //        _efContext.Entry(acModel).State = EntityState.Added;
                        //        foreach (var acConfig in acModel.AcConfigs)
                        //        {
                        //            _efContext.Entry(acConfig).State = EntityState.Added;
                        //        }
                        //    }
                        //}
                    }
                }
            }
        }

        /// <summary>
        ///     根据AcTypeID获取AcType
        /// </summary>
        /// <param name="id">AcType主键</param>
        /// <returns>AcType</returns>
        private AcType GetAcTypeById(string id)
        {
            int value = Convert.ToInt32(id);
            return _efContext == null ? null : _efContext.AcTypes.FirstOrDefault(p => p.ID == value);
        }

        public void UpdateAcconfigItems(ICollection<AcConfig> srcItems, ICollection<AcConfig> dstItems)
        {
            if (srcItems == null || dstItems == null) return;
            //数据库中没有，直接新增
            if (!dstItems.Any())
            {
                foreach (var srcItem in srcItems)
                {
                     _efContext.Entry(srcItem).State = EntityState.Added;
                }
                return;
            }
            //传进来的是空集合，则删除数据库中集合
            if (!srcItems.Any())
            {
                foreach (var dstItem in dstItems)
                {
                    _efContext.Entry(dstItem).State = EntityState.Deleted;
                }
                return;
            }
            //遍历数据库中集合，与传入集合对比
            foreach (var dstItem in dstItems)
            {
                //传入集合中没有数据库现在ID，则认为是新增，如果有，则是修改
                var srcItem = srcItems.FirstOrDefault(p=>p.Name==dstItem.Name);
                if (srcItem == null)
                {
                    _efContext.Entry(dstItem).State = EntityState.Deleted;
                }
                else
                {
                     _efContext.AcConfigs.Attach(dstItem);
                     RepositoriesHelper.UpdateProperty(srcItem, dstItem);
                }
            }
            //遍历传入集合，与数据库集合对比
            foreach (var srcItem in srcItems)
            {
                 var   dstItem = dstItems.FirstOrDefault(p => p.Name==srcItem.Name);
                if (dstItem != null) continue;
                _efContext.Entry(srcItem).State = EntityState.Added;
            }
        }



        /// <summary>
        /// 维护Actype与Ata的关系
        /// </summary>
        /// <param name="acTypes"></param>
        /// <returns></returns>
        public List<AcType> ManageAcTypeAta(List<AcType> acTypes)
        {
            List<AcType> acTypeList = new List<AcType>();

            List<Ata> beAdd = new List<Ata>();//待增加集合
            List<Ata> beRemove = new List<Ata>();//待删除集合

            foreach (var acType in acTypes)
            {
                beAdd.Clear();
                beRemove.Clear();
                var oriActype = _efContext.AcTypes.FirstOrDefault(a=>a.ID==acType.ID);
                if (oriActype != null)
                {
                    //如果数据库中没有ATA记录，则直接添加
                    if (oriActype.Atas.Count == 0)
                    {
                        foreach (var ata in acType.Atas)
                        {
                            beAdd.Add(ata);
                        }
                    }
                    else
                    {
                        //如果数据库中存在ATA记录，则对比传入的ATA与数据库中的ATA的值
                        //如果数据库中存在则，保留，如果数据中不存在，则新增
                        foreach (var ata in acType.Atas)
                        {
                            if (!oriActype.Atas.Contains(ata))
                            {
                                beAdd.Add(ata);
                            }
                        }

                        foreach (var oriAta in oriActype.Atas)
                        {
                            if (!acType.Atas.Contains(oriAta))
                            {
                                beRemove.Add(oriAta);
                            }
                        }
                    }
                    //新增
                    foreach (var ata in beAdd)
                    {
                        var oriAta = _efContext.Atas.FirstOrDefault(a => a.ID == ata.ID);
                        if (oriAta != null) oriActype.Atas.Add(oriAta);
                    }
                    //删除
                    foreach (var ata in beRemove)
                    {
                        var oriAta = _efContext.Atas.FirstOrDefault(a => a.ID == ata.ID);
                        if (oriAta != null) oriActype.Atas.Remove(oriAta);

                    }
                }
                acTypeList.Add(acType);
            }
            _efContext.SaveChanges();
            //this.efContext.Commit();
            return acTypeList;
        }
    }
}
