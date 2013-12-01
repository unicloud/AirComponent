#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：zhangnx 时间：2013/8/14 18:48:56
// 文件名：GeneratorHelper
// 版本：V1.0.0
//
// 修改者： 时间： 
// 修改说明：
// ========================================================================*/
#endregion

using System.IO;
using System.Linq;
using System.Reflection;

namespace BaseCodeTools
{

    public static class GeneratorHelper
    {
        private const string ModelAssemblyFileName = @"..\..\..\..\Domain\UniCloud.Domain.Component\bin\Debug\UniCloud.Domain.Component.dll";
        private const string DataObjectAssemblyFileName = @"..\..\..\..\Application\UniCloud.DataObjects.Component\bin\Debug\UniCloud.DataObjects.Component.dll";

        public const string ModelFilePath = @"..\..\..\..\Domain\UniCloud.Domain.Component\Model\";

        public const string Author = "gyoung ";

        public static string GetTabString(int count)
        {
            var s = "";
            for (int i = 1; i <= count; i++)
            {
                s += "   ";
            }
            return s;
        }

        public static void  ForceDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        //获取文件所在子目录
        public static bool GetFileRelativePath(string foldPath, string fileName, out string relativePath)
        {
            var thefolder = new DirectoryInfo(foldPath);

            //先查找当前目录
            if (thefolder.GetFiles(fileName).Any(nextfile => fileName.Equals(nextfile.Name)))
            {
                var rootfolder = new DirectoryInfo(ModelFilePath);
                relativePath = thefolder.FullName.Substring(rootfolder.FullName.Length);
                return true;
            }
            //查找子目录
            foreach (var nextfolder in thefolder.GetDirectories())
            {
                if (GetFileRelativePath(nextfolder.FullName, fileName, out relativePath))
                    return true;
            }
            relativePath = "";
            return false;
        }

        /// <summary>
        /// 获取模型DLL文件
        /// </summary>
        /// <returns></returns>
        public static Assembly GetModelAssembly()
        {
            return Assembly.LoadFrom(GeneratorHelper.ModelAssemblyFileName);
        }

        /// <summary>
        /// 获取模型DLL文件
        /// </summary>
        /// <returns></returns>
        public static Assembly GetDataObjectAssembly()
        {
            return Assembly.LoadFrom(GeneratorHelper.DataObjectAssemblyFileName);
        }

        public static string UppercaseFirst(string str)
        {
            return str.Substring(0, 1).ToUpper() + str.Substring(1, str.Length - 1);
        }

        public static string LowercaseFirst(string str)
        {
            return str.Substring(0, 1).ToLower() + str.Substring(1, str.Length - 1);
        }
        /// <summary>
        /// 获取服务名称
        /// </summary>
        /// <returns></returns>
        public static string GetServiceName(string serviceName)
        {
            return serviceName;
        }
    }
}
