#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：zhangnx 时间：2013/8/9 17:04:00
// 文件名：BaseFileCode
// 版本：V1.0.0
//
// 修改者： 时间： 
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.IO;
using System.Reflection;
using System.Text;
using BaseCodeTools.AutoGenerate.ClassCode;

namespace BaseCodeTools.AutoGenerate.FileCode
{
    public abstract class BaseFileCode : IFileCode
    {

        private BaseClassCode _classCode;

        protected string SubPath { get; set; }

        protected BaseClassCode ClassCode
        {
            get
            {
                if (_classCode == null) _classCode = CreateBaseClassCode();
                return _classCode;
            }
        }

        protected abstract BaseClassCode CreateBaseClassCode();

        /// <summary>
        /// 获取文件后缀
        /// </summary>
        /// <returns></returns>
        protected virtual string GetFileExt()
        {
            return ".cs";
        }

        /// <summary>
        /// 获取文件名
        /// </summary>
        /// <param name="modelName">模块名称</param>
        /// <returns></returns>
        protected abstract string GetFileName(string modelName);

        /// <summary>
        /// 获取对应文件路径
        /// </summary>
        /// <returns></returns>
        protected abstract string GetFilePath();

        /// <summary>
        /// 获取文件全路径
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        protected string GetFullFileName(string modelName)
        {
            return GetFilePath() + SubPath +"\\" + GetFileName(modelName) + GetFileExt();
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
        /// 初始化文件目录
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        public bool InitFilePath(string modelName)
        {
            string relativePath = "";
            if (GeneratorHelper.GetFileRelativePath(GeneratorHelper.ModelFilePath, modelName + ".cs", out relativePath))
            {
                SubPath = relativePath;
                //强制生成目录
                GeneratorHelper.ForceDirectory(GetFilePath() + SubPath);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 判断是否为模型文件
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public virtual bool IsNeedModelFile(Type m)
        {
            //!m.Name.StartsWith("I") || m.Name.StartsWith("Invoice");
            return m.FullName.StartsWith("UniCloud.Domain.Model"); 
        }

        /// <summary>
        /// 添加文件头信息
        /// </summary>
        /// <param name="m"></param>
        /// <param name="sb"></param>
        protected virtual void AddHeaderVersionInfo(Type m, StringBuilder sb)
        {
            var dateTime = DateTime.Now;
            sb.AppendLine(@"#region Version Info");
            sb.AppendLine(@"/* ========================================================================");
            sb.AppendLine(@"// 版权所有 (C) 2013 UniCloud ");
            sb.AppendLine(@"//【本类功能概述】");
            sb.AppendLine(@"// ");
            sb.AppendLine(@"// 作者："+ GeneratorHelper.Author + "时间：" + dateTime);
            sb.AppendLine(@"");
            sb.AppendLine(@"// 文件名：" + GetFileName(m.Name));
            sb.AppendLine(@"// 版本：V1.0.0");
            sb.AppendLine(@"//");
            sb.AppendLine(@"// 修改者： 时间：");
            sb.AppendLine(@"// 修改说明：");
            sb.AppendLine(@"// ========================================================================*/");
            sb.AppendLine(@"#endregion");
            sb.AppendLine(@"");
        }

        /// <summary>
        /// 添加文件引用单元
        /// </summary>
        /// <param name="m"></param>
        /// <param name="sb"></param>
        protected abstract void AddHeaderUsing(Type m, StringBuilder sb);

        /// <summary>
        /// 添加类命名空间
        /// </summary>
        /// <param name="m"></param>
        /// <param name="sb"></param>
        protected abstract void AddHeaderNameSpace(Type m, StringBuilder sb);

        /// <summary>
        ///添加文件头部分 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="sb"></param>
        public virtual void AddHeaderPart(Type m, StringBuilder sb)
        {
            AddHeaderVersionInfo(m, sb);
            AddHeaderUsing(m, sb);
            AddHeaderNameSpace(m, sb);
        }

        /// <summary>
        ///添加文件类代码 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="sb"></param>
        public virtual void AddClassCodePart(Type m, StringBuilder sb)
        {
            ClassCode.AddClassCodePart(m, sb);
        }

        /// <summary>
        /// 添加文件尾部 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="sb"></param>
        public virtual void AddTailPart(Type m, StringBuilder sb)
        {
            sb.AppendLine("}");
        }

        /// <summary>
        ///生成一个文件 
        /// </summary>
        /// <param name="m"></param>
        public virtual void GenerateOneCodeFile(Type m)
        {
            //初始化路径, 需要先做，命名空间需要用到这个目录
            InitFilePath(m.Name);
            var sb = new StringBuilder();
            AddHeaderPart(m, sb);
            AddClassCodePart(m, sb);
            AddTailPart(m, sb);

            //生成DTO的分布类文件
            //var partial = new StringBuilder();
            //AddHeaderPart(m, partial);
            //AddTailPart(m, partial);
            //SaveFile(partial.ToString(), (GetFullFileName(m.Name).Substring(0, (GetFullFileName(m.Name)).Length - 3)) + ".partial.cs");
           
            //保存文件
            SaveFile(sb.ToString(), GetFullFileName(m.Name));
        
        }


    }
}
