#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/9/11 13:23:16
* 文件名：ComboBoxDto
* 版本：V1.0.0
*
* 修改者： 时间： 
* 修改说明：
* ========================================================================
*/
#endregion
using System;
using System.Net;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace UniCloud.DataObjects.Silverlight
{
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContractAttribute(Name = "ComboBoxDto", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class ComboBoxDto : BaseDataObject
    {
        private int IDField;
        private string DisplayValueField;
        private string StringValueField;

        /// <summary>
        /// 主键
        /// </summary>
        [DataMemberAttribute()]
        public int ID
        {
            get
            {
                return this.IDField;
            }
            set
            {
                if (this.IDField != value)
                {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }

        /// <summary>
        /// 显示值
        /// </summary>
        [DataMemberAttribute()]
        public string DisplayValue
        {
            get
            {
                return this.DisplayValueField;
            }
            set
            {
                if (this.DisplayValueField != value)
                {
                    this.DisplayValueField = value;
                    this.RaisePropertyChanged("DisplayValue");
                }
            }
        }

        /// <summary>
        /// 字符串类型主键
        /// </summary>
        [DataMemberAttribute()]
        public string StringValue
        {
            get
            {
                return this.StringValueField;
            }
            set
            {
                if (this.StringValueField != value)
                {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
                }
            }
        }
    }
}
