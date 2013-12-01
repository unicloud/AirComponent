#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/27 15:14:30

// 文件名：SnRegDataObject
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

    public partial class SnRegDataObject : BaseDataObject
    {
        //最近一次历史记录
        private SnHistoryDataObject snHistoryField;
        
        //常用的两个单位的最近使用时间信息
        private SnHistoryUnitDataObject SnTsnField;
        private SnHistoryUnitDataObject SnCsnField;

        private string ItemNoField;
        private string PnSnField;
        private string PnField;
        private string NhPnSnField;
        private string RootPnSnField;

        [DataMemberAttribute()]
        public SnHistoryDataObject SnHistory
        {
            get
            {
                return this.snHistoryField;
            }
            set
            {
                if (this.snHistoryField != value)
                {
                    this.snHistoryField = value;
                    this.RaisePropertyChanged("SnHistory");
                }
            }
        }

        [DataMemberAttribute()]
        public SnHistoryUnitDataObject SnTsn
        {
            get
            {
                return this.SnTsnField;
            }
            set
            {
                if (this.SnTsnField != value)
                {
                    this.SnTsnField = value;
                    this.RaisePropertyChanged("SnTsn");
                }
            }
        }
        [DataMemberAttribute()]
        public SnHistoryUnitDataObject SnCsn
        {
            get
            {
                return this.SnCsnField;
            }
            set
            {
                if (this.SnCsnField != value)
                {
                    this.SnCsnField = value;
                    this.RaisePropertyChanged("SnCsn");
                }
            }
        }

        [DataMemberAttribute()]
        public string PnSn
        {
            get
            {
                if (this.PnRegField != null)
                {
                    return this.PnRegField.Pn + "/" + SnField;
                }
                else
                {
                    return "";
                }

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

        [DataMemberAttribute()]
        public string ItemNo
        {
            get
            {
                return this.ItemNoField;
            }
            set
            {
                if (this.ItemNoField != value)
                {
                    this.ItemNoField = value;
                    this.RaisePropertyChanged("ItemNo");
                }
            }
        }

        [DataMemberAttribute()]
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

        [DataMemberAttribute()]
        public string NhPnSn
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
        [DataMemberAttribute()]
        public string RootPnSn
        {
            get
            {
                return RootPnSnField;
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
