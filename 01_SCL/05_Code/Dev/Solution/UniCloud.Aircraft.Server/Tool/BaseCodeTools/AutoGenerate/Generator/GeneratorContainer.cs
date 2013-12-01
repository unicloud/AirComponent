#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：zhangnx 时间：2013/8/18 14:06:10
// 文件名：GeneratorContainer
// 版本：V1.0.0
//
// 修改者： 时间： 
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCodeTools.AutoGenerate.Generator
{
   public class GeneratorContainer
   {
       private readonly List<IGenerator> _container;
       public GeneratorContainer()
       {
           _container = new List<IGenerator>();
           InitGenerator();
       }

       /// <summary>
       /// 初始化所有生成器
       /// </summary>
       private void InitGenerator()
       {
           _container.Add(new ConfigurationsGeneratorOracle());
           _container.Add(new ConfigurationsGeneratorSqlServer());
           _container.Add(new DataObjectsGeneratorServer());
           _container.Add(new DataObjectsGeneratorSilverlight());
           _container.Add(new RepositoryGenerator());
           _container.Add(new RepositoryGeneratorInterface());
		   _container.Add(new PartialGenerator());
           _container.Add(new QueryGeneratorInterface());
           _container.Add(new QueryGenerator());
           _container.Add(new ServiceContractGeneratorInterface());
           _container.Add(new ServiceImplGenerator());
           _container.Add(new ProjectConfigurationGenerator());
           _container.Add(new PaginationGenerator());
       }

       /// <summary>
       /// 生成所有文件
       /// </summary>
       public void GeneratorAllFile()
       {
           _container.ForEach(generator => generator.GenerateCodeFile());
       }
   }
}
