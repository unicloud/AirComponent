using System.Runtime.Serialization;

namespace UniCloud.DataObjects.Silverlight
{

    public partial class OilHistoryDataObject : BaseDataObject
    {
        
        private string WarnTagField;

        [DataMemberAttribute()]
        public string WarnTag
        {
            get
            {
                return this.WarnTagField;
            }
            set
            {
                if (this.WarnTagField != value)
                {
                    this.WarnTagField = value;
                    this.RaisePropertyChanged("WarnTag");
                }
            }
        }
    }
}
