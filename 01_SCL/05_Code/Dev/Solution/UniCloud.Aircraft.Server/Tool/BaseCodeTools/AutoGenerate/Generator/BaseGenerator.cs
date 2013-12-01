#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：zhangnx 时间：2013/8/9 17:04:00
// 文件名：BaseGenerator
// 版本：V1.0.0
//
// 修改者： 时间： 
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Linq;
using System.Reflection;
using BaseCodeTools.AutoGenerate.FileCode;

namespace BaseCodeTools.AutoGenerate.Generator
{
    public abstract class BaseGenerator : IGenerator
    {
        private BaseFileCode _fileCode;

        protected BaseFileCode FileCode
        {
            get
            {
                if (_fileCode == null) _fileCode = CreateFileCode();
                return _fileCode;
            }
        }

        protected abstract BaseFileCode CreateFileCode();


        /// <summary>
        /// 获取模型DLL文件
        /// </summary>
        /// <returns></returns>
        protected Assembly GetModelAssembly()
        {
            return GeneratorHelper.GetModelAssembly();
        }

        /// <summary>
        /// 判断是否为模型文件
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public virtual bool IsNeedModelFile(Type m)
        {
            return FileCode.IsNeedModelFile(m);
        }

        /// <summary>
        ///生成一个文件 
        /// </summary>
        /// <returns></returns>
        protected void GenerateOneCodeFile(Type m)
        {
            FileCode.GenerateOneCodeFile(m);
        }

        /// <summary>
        /// 生成代码文件
        /// </summary>
        public void GenerateCodeFile()
        {
            var ase = GetModelAssembly();
            var types = ase.GetTypes();
            //获取模块数目
            var modeTypes = types.Where(IsNeedModelFile).ToList();
            //遍历模块，生成单个文件
            modeTypes.ForEach(GenerateOneCodeFile);
        }
    }
}
