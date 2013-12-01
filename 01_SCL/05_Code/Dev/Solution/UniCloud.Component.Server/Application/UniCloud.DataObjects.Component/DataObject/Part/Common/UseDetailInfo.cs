using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UniCloud.DataObjects
{
    [DataContract(IsReference = false)]
    public class UseDetailInfo
    {
        [DataMember]
        public int Time
        {
            get;
            set;
        }

        [DataMember]
        public float Value
        {
            get;
            set;
        }
    }

    [CollectionDataContract]
    public class UseDetailInfoList : List<UseDetailInfo>
    {
    }
}
