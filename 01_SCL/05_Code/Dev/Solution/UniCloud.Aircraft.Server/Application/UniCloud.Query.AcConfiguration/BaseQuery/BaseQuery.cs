#region Version Info

/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency 时间：2013/8/8 20:47:51
// 文件名：BaseQuery
// 版本：V1.0.0
//
// 修改者： 时间： 
// 修改说明：
// ========================================================================*/

#endregion

using System;
using System.Collections.Concurrent;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using UniCloud.DataObjects;
using UniCloud.Domain;
using UniCloud.Infrastructure;

namespace UniCloud.Query.AcConfiguration
{
	public abstract class BaseQuery : IQuery
	{
		#region Private Fields
		//表达式缓存
		private ConcurrentDictionary<Type, dynamic> _expressionCache = new ConcurrentDictionary<Type, dynamic>();

		#endregion

		#region Private Fields

		private DbContext _context;

		#endregion

		#region Properties

		public DbContext Context {
			get { return _context; }
			set { _context = value; }
		}

		#endregion

		#region  Public Methods

		/// <summary>
		///     获取DTO对象
		/// </summary>
		/// <typeparam name="TEntity">实体</typeparam>
		/// <typeparam name="TObject">DTO对象</typeparam>
		/// <param name="entityToObject">实体转化DTO</param>
		/// <returns>返回DTO对象</returns>
		public dynamic LoadObjects<TEntity, TObject>(Expression<Func<TEntity, TObject>> entityToObject)
			where TEntity : class, IEntity
			where TObject : class {
			Expression<Func<TEntity, bool>> wherelambda = p => true;
			return LoadEntities(wherelambda, null, SortOrder.Ascending).Select(entityToObject);
		}

		/// <summary>
		///     获取DTO对象
		/// </summary>
		/// <param name="wherelambda"></param>
		/// <typeparam name="TEntity">实体</typeparam>
		/// <typeparam name="TObject">DTO对象</typeparam>
		/// <param name="entityToObject">实体转化DTO</param>
		/// <returns>返回DTO对象</returns>
		public dynamic LoadObjects<TEntity, TObject>(Expression<Func<TEntity, bool>> wherelambda,
																		  Expression<Func<TEntity, TObject>> entityToObject)
			where TEntity : class, IEntity
			where TObject : class {
			return LoadEntities(wherelambda, null, SortOrder.Ascending).Select(entityToObject);
		}

		/// <summary>
		///     获取DTO对象
		/// </summary>
		/// <param name="wherelambda"></param>
		/// <param name="sortPredicate">排序字段</param>
		/// <param name="sortOrder">排序方式</param>
		/// <typeparam name="TEntity">实体</typeparam>
		/// <typeparam name="TObject">DTO对象</typeparam>
		/// <param name="entityToObject">实体转化DTO</param>
		/// <returns>返回DTO对象</returns>
		public dynamic LoadObjects<TEntity, TObject>(Expression<Func<TEntity, bool>> wherelambda,
																		  Expression<Func<TEntity, dynamic>> sortPredicate,
																		  SortOrder sortOrder,
																		  Expression<Func<TEntity, TObject>> entityToObject)
			where TEntity : class, IEntity
			where TObject : class {
			return LoadEntities(wherelambda, sortPredicate, sortOrder).Select(entityToObject);
		}


		/// <summary>
		///     获取DTO对象
		/// </summary>
		/// <param name="wherelambda"></param>
		/// <typeparam name="TEntity">实体</typeparam>
		/// <typeparam name="TObject">DTO对象</typeparam>
		/// <param name="sortPredicate">排序字段</param>
		/// <param name="pagination">分页信息</param>
		/// <param name="entityToObject">实体转化为DTO</param>
		/// <returns>返回DTO对象</returns>
		public dynamic LoadObjects<TEntity, TObject>(
			Expression<Func<TEntity, bool>> wherelambda,
			Expression<Func<TEntity,dynamic>> sortPredicate,
			Pagination pagination,
			Expression<Func<TEntity, TObject>>
				entityToObject)
			where TEntity : class, IEntity
			where TObject : class
		{

		
			var findResultEntitiesByPage = LoadPageDataObjects(wherelambda,sortPredicate,pagination,entityToObject);
			pagination.TotalPages = findResultEntitiesByPage.TotalPages;
			return new { Pagination = pagination, DataList = findResultEntitiesByPage };
		}

		/// <summary>
		///     获取当个DTO对象
		/// </summary>
		/// <typeparam name="TEntity">实体</typeparam>
		/// <typeparam name="TObject">DTO</typeparam>
		/// <returns>返回单个DTO对象</returns>
		public TObject LoadObject<TEntity, TObject>(Expression<Func<TEntity, TObject>> entityToObject)
			where TEntity : class, IEntity
			where TObject : class {
			Expression<Func<TEntity, bool>> wherelambda = p => true;
			return LoadEntities(wherelambda, null, SortOrder.Ascending).Select(entityToObject).FirstOrDefault();
		}

		/// <summary>
		///     获取当个DTO对象
		/// </summary>
		/// <typeparam name="TEntity">实体</typeparam>
		/// <typeparam name="TObject">DTO</typeparam>
		/// <param name="wherelambda">查询表达式</param>
		/// <param name="entityToObject">实体转化为DTO</param>
		/// <returns>返回单个DTO对象</returns>
		public TObject LoadObject<TEntity, TObject>(Expression<Func<TEntity, bool>> wherelambda,
													 Expression<Func<TEntity, TObject>> entityToObject)
			where TEntity : class, IEntity
			where TObject : class {
			return LoadEntities(wherelambda, null, SortOrder.Descending).Select(entityToObject).FirstOrDefault();
		}



		/// <summary>
		/// 加载所有实体
		/// </summary>
		/// <typeparam name="TEntity">实体</typeparam>
		/// <param name="wherelambda">查询表达式</param>
		/// <param name="sortPredicate">排列字段</param>
		/// <param name="sortOrder">排序</param>
		/// <returns>返回获取的实体</returns>
		public IQueryable<TEntity> LoadEntities<TEntity>(Expression<Func<TEntity, bool>> wherelambda,
														 Expression<Func<TEntity, dynamic>> sortPredicate, SortOrder sortOrder)
			where TEntity : class, IEntity {
			IQueryable<TEntity> query = _context.Set<TEntity>()
												.Where(wherelambda);
			if (sortPredicate != null) {
				switch (sortOrder) {
					case SortOrder.Ascending:
						return query.SortBy(sortPredicate);
					case SortOrder.Descending:
						return query.SortByDescending(sortPredicate);

				}
			}
			return query;
		}


		/// <summary>
		/// 分页查询
		/// </summary>
		/// <typeparam name="TEntity">实体</typeparam>
		/// <typeparam name="TObject">DTO对象</typeparam>
		/// <param name="wherelambda">查询表达式</param>
		/// <param name="sortPredicate">排序字段</param>
		/// <param name="pagination">分页信息</param>
		/// <param name="entityToObject"></param>
		/// <returns>分页查询结果</returns>
		public PagedResult<TObject> LoadPageDataObjects<TEntity, TObject>(
			Expression<Func<TEntity, bool>> wherelambda,
			Expression<Func<TEntity, dynamic>> sortPredicate,
			Pagination pagination,
			Expression<Func<TEntity, TObject>>
				entityToObject)
			where TEntity : class, IEntity
			where TObject : class {

			if (pagination.PageNumber <= 0)
				throw new ArgumentOutOfRangeException("pageNumber", pagination.PageNumber, "页码必须大于或等于1。");
			if (pagination.PageSize <= 0)
				throw new ArgumentOutOfRangeException("pageSize", pagination.PageSize, "每页大小必须大于或等于1。");

			IQueryable<TEntity> query = _context.Set<TEntity>()
												.Where(wherelambda);
			var skip = (pagination.PageNumber - 1) * pagination.PageSize;
			var take = pagination.PageSize;
			if (sortPredicate != null) {
				switch (pagination.SortOrder) {
					case SortOrder.Ascending:
						var pagedGroupAscending =
							query.SortBy(sortPredicate).Skip(skip).Take(take).Select(entityToObject).GroupBy(p => new { Total = query.Count() }).FirstOrDefault();
						return pagedGroupAscending == null
								   ? null
								   : new PagedResult<TObject>(pagedGroupAscending.Key.Total,
															  (pagedGroupAscending.Key.Total + pagination.PageSize - 1) / pagination.PageSize, pagination.PageSize, pagination.PageNumber,
															  pagedGroupAscending.Select(p => p).ToList());
					case SortOrder.Descending:
						var pagedGroupDescending =
							query.SortByDescending(sortPredicate)
								 .Skip(skip)
								 .Take(take)
								 .Select(entityToObject)
								 .GroupBy(p => new { Total = query.Count() })
								 .FirstOrDefault();
						return pagedGroupDescending == null
								   ? null
								   : new PagedResult<TObject>(pagedGroupDescending.Key.Total,
															  (pagedGroupDescending.Key.Total + pagination.PageSize - 1) / pagination.PageSize, pagination.PageSize, pagination.PageNumber,
															  pagedGroupDescending.Select(p => p).ToList());

				}
			}
			throw new InvalidOperationException("基于分页功能的查询必须指定排序字段和排序顺序。");
		
		}

		/// <summary>
		/// 获取单条记录
		/// </summary>
		/// <typeparam name="TEntity">实体</typeparam>
		/// <param name="wherelambda">查询表达式</param>
		/// <returns>返回单个实体</returns>
		public TEntity LoadEntity<TEntity>(Expression<Func<TEntity, bool>> wherelambda) where TEntity : class, IEntity {
			return LoadEntities(wherelambda, null, SortOrder.Descending).FirstOrDefault();
		}

		public dynamic LoadField<TEntity>(Expression<Func<TEntity, bool>> wherelambda,
		                                   Expression<Func<TEntity, dynamic>> selectlambda) where TEntity : class, IEntity
		{
			return _context.Set<TEntity>().Where(wherelambda).Select(selectlambda).FirstOrDefault();
		}

		#endregion
		
		#region Public Abstact Methods

		/// <summary>
		///     初始化DbContext
		/// </summary>
		/// <param name="context">域上下文</param>
		protected abstract void InitializerDbContext(DbContext context);

		#endregion

	
	}
}