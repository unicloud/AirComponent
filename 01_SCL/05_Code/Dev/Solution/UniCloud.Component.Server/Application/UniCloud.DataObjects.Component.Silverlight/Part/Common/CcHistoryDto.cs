#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/9/2 13:11:58
* 文件名：CcHistoryDto
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
using System.ServiceModel.DomainServices.Client;

namespace UniCloud.DataObjects.Silverlight
{
    /// <summary>
    ///APUWarningDto
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContractAttribute(Name = "CcHistoryDto", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class CcHistoryDto:BaseDataObject
    {
        private string AcregField;
        private string PartItemNoField;
        private string CcTypeField;
        private string SnField;
        private string PartField;
        private DateTime OperateTimeField;
        private string UnScheduledField;
        private string AtaField;

        [DataMemberAttribute()]
        public string Acreg
        {
            get
            {
                return this.AcregField;
            }
            set
            {
                if (this.AcregField != value)
                {
                    this.AcregField = value;
                    this.RaisePropertyChanged("Acreg");
                }
            }
        }

        [DataMemberAttribute()]
        public string PartItemNo
        {
            get
            {
                return this.PartItemNoField;
            }
            set
            {
                if (this.PartItemNoField != value)
                {
                    this.PartItemNoField = value;
                    this.RaisePropertyChanged("PartItemNo");
                }
            }
        }

        [DataMemberAttribute()]
        public string Sn
        {
            get
            {
                return this.SnField;
            }
            set
            {
                if (this.SnField != value)
                {
                    this.SnField = value;
                    this.RaisePropertyChanged("Sn");
                }
            }
        }

        [DataMemberAttribute()]
        public string Part
        {
            get
            {
                return this.PartField;
            }
            set
            {
                if (this.PartField != value)
                {
                    this.PartField = value;
                    this.RaisePropertyChanged("Part");
                }
            }
        }

        [DataMemberAttribute()]
        public string CcType
        {
            get
            {
                return this.CcTypeField;
            }
            set
            {
                if (this.CcTypeField != value)
                {
                    this.CcTypeField = value;
                    this.RaisePropertyChanged("CcType");
                }
            }
        }

        [DataMemberAttribute()]
        public string UnScheduled
        {
            get
            {
                return this.UnScheduledField;
            }
            set
            {
                if (this.UnScheduledField != value)
                {
                    this.UnScheduledField = value;
                    this.RaisePropertyChanged("UnScheduled");
                }
            }
        }

        [DataMemberAttribute()]
        public string Ata
        {
            get
            {
                return this.AtaField;
            }
            set
            {
                if (this.AtaField != value)
                {
                    this.AtaField = value;
                    this.RaisePropertyChanged("Ata");
                }
            }
        }

        [DataMemberAttribute()]
        public DateTime OperateTime
        {
            get
            {
                return this.OperateTimeField;
            }
            set
            {
                if (this.OperateTimeField != value)
                {
                    this.OperateTimeField = value;
                    this.RaisePropertyChanged("OperateTime");
                }
            }
        }
    }
}
