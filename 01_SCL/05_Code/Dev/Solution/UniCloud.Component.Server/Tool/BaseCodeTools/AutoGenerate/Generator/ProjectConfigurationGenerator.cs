﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseCodeTools.AutoGenerate.Generator
{
    public class ProjectConfigurationGenerator : IGenerator
    {
        private readonly List<string> _aggregateRoots = new List<string>
                                                   {
                                                       "AircraftLeaseSubPrjTemplate",
                                                       "AircraftPurchaseSubPrjTemplate",
                                                       "AirProject",
                                                       "BFESubPrjTemplate",
                                                       "EngineLeaseSubPrjTemplate",
                                                       "EnginePurchaseSubPrjTemplate",
                                                       "GroupMember",
                                                       "PrjSubPrj",
                                                       "PrjTemplate",
                                                       "SubPrjGroup",
                                                       "SubPrjTask",
                                                       "TaskGroup",
                                                       "TaskTemplate",
                                                       "WorkGroup",
                                                   };


        private readonly List<string> _moduleTemplates = new List<string>
                                  {
                                      "      <register type=\"UniCloud.Domain.Repositories.Project.IPaymentPlanRepository, UniCloud.Domain.FRP\" mapTo=\"UniCloud.Domain.Repositories.Project.PaymentPlanRepository, UniCloud.Domain.Repositories.FRP\"/>",
                                      "      <register type=\"UniCloud.Query.FRP.IPaymentPlanQuery, UniCloud.Query.FRP\" mapTo=\"UniCloud.Query.FRP.PaymentPlanQuery, UniCloud.Query.FRP\"/>"
                                  };

        public ProjectConfigurationGenerator()
        {
            InitData();

        }

        private void InitData()
        {
            string sb = "      <register type=\"UniCloud.ServiceContracts.IPaymentPlanService, UniCloud.ServiceContracts.FRP\" mapTo=\"UniCloud.Application.Implementation.Project.PaymentPlanServiceImpl, UniCloud.Application.FRP\">"
                        + "\r\n" + "       <interceptor type=\"InterfaceInterceptor\"/> "
                        + "\r\n" +
                        "       <interceptionBehavior type=\"UniCloud.Infrastructure.InterceptionBehaviors.CachingBehavior, UniCloud.Infrastructure\"/>"
                        + "\r\n" +
                        "       <interceptionBehavior type=\"UniCloud.Infrastructure.InterceptionBehaviors.ExceptionLoggingBehavior, UniCloud.Infrastructure\"/>"
                        + "\r\n" + "      </register>";
            _moduleTemplates.Add(sb);
        }


        protected string GetFilePath()
        {
            return "E:\\AutoGenerate\\Others\\";
        }

        private string GetFileName()
        {
            return "app.config";
        }

        /// <summary>
        /// 获取文件全路径
        /// </summary>
        /// <returns></returns>
        protected string GetFullFileName()
        {
            return GetFilePath() + GetFileName();
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="content"></param>
        /// <param name="fileName"></param>
        protected void SaveFile(string content, string fileName)
        {
            File.WriteAllText(fileName, content);
        }

        /// <summary>
        /// 生成代码文件
        /// </summary>
        public void GenerateCodeFile()
        {
            var sb = new StringBuilder();
            foreach (var moduleTemplate in _moduleTemplates)
            {
                foreach (var aggregateRoot in _aggregateRoots)
                {
                    sb.AppendLine(moduleTemplate.Replace("PaymentPlan", aggregateRoot));
                }
                sb.AppendLine("");
                sb.AppendLine("");
            }

            GeneratorHelper.ForceDirectory(GetFilePath());
            SaveFile(sb.ToString(), GetFullFileName());
        }
    }
}
