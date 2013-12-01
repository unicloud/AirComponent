using System;
using System.Runtime.Serialization;

namespace UniCloud.DataObjects.Silverlight
{

    public partial class OilAnalysisDataObject : BaseDataObject
    {

        private OilHistoryDataObjectList DetailField;
        private DateTime FromDateField;
        private DateTime ToDateField;
        [DataMemberAttribute()]
        public OilHistoryDataObjectList Detail
        {
            get
            {
                return this.DetailField;
            }
            set
            {
                if (this.DetailField != value)
                {
                    this.DetailField = value;
                    this.RaisePropertyChanged("Detail");
                }
            }
        }

        
        [DataMemberAttribute()]
        public DateTime FromDate
        {
            get
            {
                return this.FromDateField;
            }
            set
            {
                if (this.FromDateField != value)
                {
                    this.FromDateField = value;
                    this.RaisePropertyChanged("FromDate");
                }
            }
        }

        [DataMemberAttribute()]
        public DateTime ToDate
        {
            get
            {
                return this.ToDateField;
            }
            set
            {
                if (this.ToDateField != value)
                {
                    this.ToDateField = value;
                    this.RaisePropertyChanged("ToDate");
                }
            }
        }
    }
}
