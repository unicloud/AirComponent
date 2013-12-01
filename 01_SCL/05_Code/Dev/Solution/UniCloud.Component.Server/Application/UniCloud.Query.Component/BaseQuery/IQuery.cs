#region Version Info

/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency 时间：2013/8/8 20:32:19
// 文件名：IQuery
// 版本：V1.0.0
//
// 修改者： 时间： 
// 修改说明：
// ========================================================================*/

#endregion

using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using UniCloud.DataObjects;
using UniCloud.Domain;
using UniCloud.Infrastructure;

namespace UniCloud.Query
{
	/// <summary>
	///     表示查询接口
	/// </summary>
	public interface IQuery
	{
		/// <summary>
		///     域上下文对象
		/// </summary>
		DbContext Context { get; set; }

		/// <summary>
		///     获取DTO对象
		/// </summary>
		/// <typeparam name="TEntity">实体</typeparam>
		/// <typeparam name="TObject">DTO对象</typeparam>
		/// <param name="entityToObject">实体转化DTO</param>
		/// <returns>返回DTO对象</returns>
		dynamic LoadObjects<TEntity, TObject>(Expression<Func<TEntity, TObject>> entityToObject)
			where TEntity : class, IEntity
			where TObject : class;

		/// <summary>
		///     获取DTO对象
		/// </summary>
		/// <param name="wherelambda"></param>
		/// <typeparam name="TEntity">实体</typeparam>
		/// <typeparam name="TObject">DTO对象</typeparam>
		/// <param name="entityToObject">实体转化DTO</param>
		/// <returns>返回DTO对象</returns>
		dynamic LoadObjects<TEntity, TObject>(Expression<Func<TEntity, bool>> wherelambda,
		                                      Expression<Func<TEntity, TObject>> entityToObject)
			where TEntity : class, IEntity
			where TObject : class;

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
		dynamic LoadObjects<TEntity, TObject>(Expression<Func<TEntity, bool>> wherelambda,
		                                      Expression<Func<TEntity, dynamic>> sortPredicate,
		                                      SortOrder sortOrder,
		                                      Expression<Func<TEntity, TObject>> entityToObject)
			where TEntity : class, IEntity
			where TObject : class;

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
		dynamic LoadObjects<TEntity, TObject>(
			Expression<Func<TEntity, bool>> wherelambda,
			Expression<Func<TEntity, dynamic>> sortPredicate,
			Pagination pagination,
			Expression<Func<TEntity, TObject>>
				entityToObject)
			where TEntity : class, IEntity
			where TObject : class;

		/// <summary>
		///     获取当个DTO对象
		/// </summary>
		/// <typeparam name="TEntity">实体</typeparam>
		/// <typeparam name="TObject">DTO</typeparam>
		/// <returns>返回单个DTO对象</returns>
		TObject LoadObject<TEntity, TObject>(Expression<Func<TEntity, TObject>> entityToObject)
			where TEntity : class, IEntity
			where TObject : class;

		/// <summary>
		///     获取当个DTO对象
		/// </summary>
		/// <typeparam name="TEntity">实体</typeparam>
		/// <typeparam name="TObject">DTO</typeparam>
		/// <param name="wherelambda">查询表达式</param>
		/// <param name="entityToObject">实体转化为DTO</param>
		/// <returns>返回单个DTO对象</returns>
		TObject LoadObject<TEntity, TObject>(Expression<Func<TEntity, bool>> wherelambda,
		                                     Expression<Func<TEntity, TObject>> entityToObject)
			where TEntity : class, IEntity
			where TObject : class;


		/// <summary>
		///     加载所有实体
		/// </summary>
		/// <typeparam name="TEntity">实体</typeparam>
		/// <param name="wherelambda">查询表达式</param>
		/// <param name="sortPredicate">排列字段</param>
		/// <param name="sortOrder">排序</param>
		/// <returns>返回获取的实体</returns>
		IQueryable<TEntity> LoadEntities<TEntity>(Expression<Func<TEntity, bool>> wherelambda,
		                                          Expression<Func<TEntity, dynamic>> sortPredicate, SortOrder sortOrder)
			where TEntity : class, IEntity;


		/// <summary>
		///     分页查询
		/// </summary>
		/// <typeparam name="TEntity">实体</typeparam>
		/// <typeparam name="TObject">DTO对象</typeparam>
		/// <param name="wherelambda">查询表达式</param>
		/// <param name="sortPredicate">排序字段</param>
		/// <param name="pagination">分页信息</param>
		/// <param name="entityToObject"></param>
		/// <returns>分页查询结果</returns>
		PagedResult<TObject> LoadPageDataObjects<TEntity, TObject>(
			Expression<Func<TEntity, bool>> wherelambda,
			Expression<Func<TEntity, dynamic>> sortPredicate,
			Pagination pagination,
			Expression<Func<TEntity, TObject>>
				entityToObject)
			where TEntity : class, IEntity
			where TObject : class;


		/// <summary>
		///     获取当条记录
		/// </summary>
		/// <typeparam name="TEntity">实体</typeparam>
		/// <param name="wherelambda">查询表达式</param>
		/// <returns>返回单个实体</returns>
		TEntity LoadEntity<TEntity>(Expression<Func<TEntity, bool>> wherelambda) where TEntity : class, IEntity;
	}
}