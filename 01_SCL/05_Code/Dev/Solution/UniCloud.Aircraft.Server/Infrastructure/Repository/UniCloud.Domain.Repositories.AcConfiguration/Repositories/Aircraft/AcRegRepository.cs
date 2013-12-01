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
    public class AcRegRepository : EntityFrameworkIntRepository<AcReg>, IAcRegRepository
    {
        private readonly AcConfigurationDbContext _efContext;

        public AcRegRepository(IRepositoryContext context)
            : base(context)
        {
            _efContext = EFContext.Context as AcConfigurationDbContext;
        }

        public void DeleteAcRegLicenseType(AcReg acReg, IEnumerable<AcregLicense> acregLicenses)
        {
            if(acReg.AcregLicenses==null)
                return;
            for (int i = acReg.AcregLicenses.Count - 1; i >= 0; i--)
            {
                if (acregLicenses.FirstOrDefault(li => li.ID == acReg.AcregLicenses.ElementAt(i).ID)!=null)
                {
                    this.DoEntityRegisterDeleted(acReg.AcregLicenses.ElementAt(i));
                }
            }
            this.Update(acReg);
            this.Context.Commit();
        }

        /// <summary>
        /// 实现对AcReg的增删改。
        /// 需要添加的AcReg对象集合
        /// 需要删除的AcReg的ID集合
        /// 需要更新的AcReg对象集合
        /// <returns>执行后的更改结果</returns>
        /// </summary>
      public void CommitAcReg(List<AcReg> addAcRegs,  IEnumerable<string> deleteIds,  List<AcReg> updateAcRegs)
        {
            AddAcRegs(addAcRegs);
            UpdateAcRegs(updateAcRegs);
            _efContext.SaveChanges();
        }

        /// <summary>
        /// 增加AcReg
        /// </summary>
        /// <param name="addAcRegs">AcReg</param>
        private void AddAcRegs(List<AcReg> addAcRegs)
        {
            if (addAcRegs != null && addAcRegs.Any())
            {
                addAcRegs.ForEach(p =>
                {
                    p.CreateDate = DateTime.Now;
                    _efContext.Entry(p).State = EntityState.Added;
                    //for (int i = p.AcregLicenses.Count - 1; i >= 0; i--)
                    //{
                    //    _efContext.Entry(p.AcregLicenses.ElementAt(i)).State = EntityState.Deleted;
                    //}
                });
            }
        }

        /// <summary>
        ///     更新AcReg
        /// </summary>
        /// <param name="updateAcRegs">更新的AcReg</param>
        private void UpdateAcRegs(List<AcReg> updateAcRegs)
        {
            if (updateAcRegs != null && updateAcRegs.Any())
            {
                foreach (var acreg in updateAcRegs)
                {
                    var ac = GetAcRegById(acreg.ID.ToString());
                    if (ac != null)
                    {
                        _efContext.AcRegs.Attach(ac);
                        ac.Guid = !acreg.Guid.Equals(new Guid()) ? acreg.Guid : Guid.NewGuid();
                        ac.AcTypeID = acreg.AcTypeID;
                        ac.AcTypeGuid = acreg.AcTypeGuid;
                        ac.AcModelID = acreg.AcModelID;
                        ac.AcModelGuid = acreg.AcModelGuid;
                        ac.AcConfigGuid = acreg.AcConfigGuid;
                        ac.AcConfigID = acreg.AcConfigID;
                        ac.DecodeConfigGuid = acreg.DecodeConfigGuid;
                        ac.DecodeConfigID = acreg.DecodeConfigID;
                        ac.Owner = acreg.Owner;
                        ac.Operators = acreg.Operators;
                        ac.ImportCategory = acreg.ImportCategory;
                        ac.Msn = acreg.Msn;
                        ac.EngineTr = acreg.EngineTr;
                        ac.IsOperation = acreg.IsOperation;
                        ac.CreateDate = acreg.CreateDate;
                        ac.FactoryDate = acreg.FactoryDate;
                        ac.ImportDate = acreg.ImportDate;
                        ac.ExportDate = acreg.ExportDate;
                        ac.SeatingCapacity = acreg.SeatingCapacity;
                        ac.CarryingCapacity = acreg.CarryingCapacity;
                        ac.OffsetUTC = acreg.OffsetUTC;
                        ac.SubframeLenght = acreg.SubframeLenght;
                        ac.ExportCategory = acreg.ExportCategory;
                        foreach (var acreglicense in acreg.AcregLicenses)
                        {
                            var acregli = ac.AcregLicenses.FirstOrDefault(al => al.ID == acreglicense.ID);
                            if (acregli != null)
                            {
                                acregli.AcRegGuid = ac.Guid;
                                acregli.Guid = acreglicense.Guid;
                                acregli.LicenseTypeGuid = acreglicense.LicenseTypeGuid;
                                acregli.CopyFile = acregli.CopyFile;
                                acregli.IssuedFrom = acreglicense.IssuedFrom;
                                acregli.Notes = acreglicense.Notes;
                                acregli.State = acreglicense.State;
                                acregli.ExpireDate = acreglicense.ExpireDate;
                                acregli.IssuedDate = acreglicense.IssuedDate;
                                acregli.ValidMonths = acreglicense.ValidMonths;
                                acregli.DocumentGuid = acreglicense.DocumentGuid;
                            }
                            else
                            {
                                acreglicense.AcRegGuid = ac.Guid;
                                acreglicense.AcRegID = ac.ID;
                                _efContext.Entry(acreglicense).State = EntityState.Added;
                            }
                        }
                        foreach (var acregLiense in ac.AcregLicenses)
                        {
                            if(acreg.AcregLicenses.FirstOrDefault(a=>a.ID==acregLiense.ID)==null)
                                _efContext.Entry(acregLiense).State = EntityState.Deleted;
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     根据AcRegID获取AcReg
        /// </summary>
        /// <param name="id">AcReg主键</param>
        /// <returns>AcReg</returns>
        private AcReg GetAcRegById(string id)
        {
            int value = Convert.ToInt32(id);
            return _efContext == null ? null : _efContext.AcRegs.FirstOrDefault(p => p.ID == value);
        }
        //public void TestUpdate()
        //{
        //    var configs = _efContext.AcConfigs.Take(3).ToList();

        //    List<AcConfig> list = new List<AcConfig>()
        //                          {
        //                              new AcConfig(){ID=1,Name="B737-800-09",Description="B737-800-02"},
        //                              new AcConfig{Name="B737-800-08",Description="B737-800-02"}
        //                          };
        //    RepositoriesHelper.UpdateItems<AcConfig>(list, configs, _efContext.AcConfigs, _efContext);


        //}
    }
}
