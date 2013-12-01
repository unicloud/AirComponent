using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Domain.Model;
using UniCloud.Domain.Repositories.EntityFramework;

namespace UniCloud.Domain.Repositories.Repositories
{
    public class AtaRepository : EntityFrameworkIntRepository<Ata>, IAtaRepository
    {
        private readonly AcConfigurationDbContext _efContext;

        public AtaRepository(IRepositoryContext context)
            : base(context)
        {
            _efContext = EFContext.Context as AcConfigurationDbContext;
        }

        /// <summary>
        /// 实现对Ata的增删改。
        /// 需要添加的Ata对象集合
        /// 需要删除的Ata的ID集合
        /// 需要更新的Ata对象集合
        /// <returns>执行后的更改结果</returns>
        /// </summary>
      public void CommitAta(List<Ata> addAtas,  IEnumerable<string> deleteIds,  List<Ata> updateAtas)
        {
            AddAtas(addAtas);
            DeleteAtas(deleteIds);
            UpdateAtas(updateAtas);
            _efContext.SaveChanges();
        }

        /// <summary>
        /// 增加Ata
        /// </summary>
        /// <param name="addAtas">Ata</param>
        private void AddAtas(List<Ata> addAtas)
        {
            if (addAtas != null && addAtas.Any())
            {
                addAtas.ForEach(p =>
                {
                    _efContext.Entry(p).State = EntityState.Added;
                    AddChildAtas(p.ChildAtas);
                });
            }
        }

        private void AddAta(Ata addAta)
        {
            _efContext.Entry(addAta).State = EntityState.Added;
            AddChildAtas(addAta.ChildAtas);
        }

        /// <summary>
        /// 增加Ata的子节点
        /// </summary>
        /// <param name="childAtas"></param>
        private void AddChildAtas(IEnumerable<Ata> childAtas)
        {
            foreach (var addAta in childAtas)
            {
                _efContext.Entry(addAta).State = EntityState.Added;
                AddChildAtas(addAta.ChildAtas);
            }
        }

        /// <summary>
        /// 删除Ata
        /// </summary>
        /// <param name="deleteIds">删除Ata</param>
        private void DeleteAtas(IEnumerable<string> deleteIds)
        {
            if (deleteIds != null)
            {
                foreach (string id in deleteIds)
                {
                    var result = GetAtaById(id);
                    if (result != null)
                    {
                        _efContext.Entry(result).State = EntityState.Deleted;
                        DeleteChildAtas(result.ChildAtas);
                    }
                }
            }
        }

        private void DeleteAta(Ata ata)
        {
            DeleteChildAtas(ata.ChildAtas);
            _efContext.Entry(ata).State = EntityState.Deleted;
        }

        private void DeleteChildAtas(IEnumerable<Ata> childAtas)
        {
            for (int i = childAtas.Count() - 1; i >= 0; i--)
            {
                var childAta = childAtas.ElementAt(i);
                DeleteChildAtas(childAta.ChildAtas);
                _efContext.Entry(childAta).State = EntityState.Deleted;
            }
        }

        /// <summary>
        ///     更新Ata
        /// </summary>
        /// <param name="updateAtas">更新的Ata</param>
        private void UpdateAtas(List<Ata> updateAtas)
        {
            if (updateAtas != null && updateAtas.Any())
            {
                foreach (var updateObj in updateAtas)
                {
                    var obj = GetAtaById(updateObj.ID.ToString());
                    if (obj != null)
                    {
                        _efContext.Atas.Attach(obj);
                        obj.ATA = updateObj.ATA;
                        obj.Description = updateObj.Description;
                        obj.Guid = updateObj.Guid.Equals(new Guid()) ? Guid.NewGuid() : updateObj.Guid;
                        UpdateChildAtas(updateObj.ChildAtas);
                        for (int i = obj.ChildAtas.Count - 1; i >= 0; i--)
                        {
                            var child = obj.ChildAtas.ElementAt(i);
                            if(updateObj.ChildAtas.FirstOrDefault(a=>a.ID==child.ID)==null)
                                DeleteAta(child);
                        }
                    }
                }
            }
        }

        private void UpdateChildAtas(IEnumerable<Ata> childAtas)
        {
            foreach (var childAta in childAtas)
            {
                var obj = GetAtaById(childAta.ID.ToString());
                if (obj != null)
                {
                    _efContext.Atas.Attach(obj);
                    obj.ATA = childAta.ATA;
                    obj.Description = childAta.Description;
                    obj.Guid = childAta.Guid.Equals(new Guid()) ? Guid.NewGuid() : childAta.Guid;
                    for (int i = obj.ChildAtas.Count - 1; i >= 0; i--)
                    {
                        var child = obj.ChildAtas.ElementAt(i);
                        if (childAta.ChildAtas.FirstOrDefault(a => a.ID == child.ID) == null)
                            DeleteAta(child);
                    }
                    UpdateChildAtas(childAta.ChildAtas);
                }
                else
                {
                    AddAta(childAta);
                }
            }
        }

        /// <summary>
        ///     根据AtaID获取Ata
        /// </summary>
        /// <param name="id">Ata主键</param>
        /// <returns>Ata</returns>
        private Ata GetAtaById(string id)
        {
            int value = Convert.ToInt32(id);
            return _efContext == null ? null : _efContext.Atas.FirstOrDefault(p => p.ID== value);
        }
    }
}
