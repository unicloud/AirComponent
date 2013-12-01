#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/27 15:14:30

// 文件名：SnHistoryDataObject
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
using System.Runtime.Serialization;

namespace UniCloud.DataObjects.Silverlight
{

    public partial class SnHistoryDataObject : BaseDataObject
    {
        //常用的两条历史时间信息
        private SnHistoryUnitDataObject SnHistoryFhField;
        private SnHistoryUnitDataObject SnHistoryCyField;
        private string SnField;
        private string PnField;
        private string PnSnField;
        private string NhPnSnField;
        private string RootPnSnField;

        [DataMemberAttribute()]
        public SnHistoryUnitDataObject SnHistoryFh
        {
            get
            {
                return this.SnHistoryFhField;
            }
            set
            {
                if (this.SnHistoryFhField != value)
                {
                    this.SnHistoryFhField = value;
                    this.RaisePropertyChanged("SnHistoryFh");
                }
            }
        }
        [DataMemberAttribute()]
        public SnHistoryUnitDataObject SnHistoryCy
        {
            get
            {
                return this.SnHistoryCyField;
            }
            set
            {
                if (this.SnHistoryCyField != value)
                {
                    this.SnHistoryCyField = value;
                    this.RaisePropertyChanged("SnHistoryCy");
                }
            }
        }

        [DataMemberAttribute]
        public virtual string Sn
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


        [DataMemberAttribute]
        public virtual string Pn
        {
            get
            {
                return this.PnField;
            }
            set
            {
                if (this.PnField != value)
                {
                    this.PnField = value;
                    this.RaisePropertyChanged("Pn");
                }
            }
        }
        [DataMemberAttribute]
        public virtual string PnSn
        {
            get
            {
                return this.PnSnField;
            }
            set
            {
                if (this.PnSnField != value)
                {
                    this.PnSnField = value;
                    this.RaisePropertyChanged("PnSn");
                }
            }
        }
        [DataMemberAttribute]
        public virtual string NhPnSn
        {
            get
            {
                return this.NhPnSnField;
            }
            set
            {
                if (this.NhPnSnField != value)
                {
                    this.NhPnSnField = value;
                    this.RaisePropertyChanged("NhPnSn");
                }
            }
        }


        [DataMemberAttribute]
        public virtual string RootPnSn
        {
            get
            {
                return this.RootPnSnField;
            }
            set
            {
                if (this.RootPnSnField != value)
                {
                    this.RootPnSnField = value;
                    this.RaisePropertyChanged("RootPnSn");
                }
            }
        }

    }
}
