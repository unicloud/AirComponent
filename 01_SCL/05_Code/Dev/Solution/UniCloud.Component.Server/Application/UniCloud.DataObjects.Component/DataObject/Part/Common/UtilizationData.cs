using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UniCloud.DataObjects
{
    [DataContract(IsReference = false)]
    public class UtilizationData
    {
        public UtilizationData()
        {
            UseDetails = new UseDetailInfoList();
        }

        [DataMember]
        public float FlightHours
        {
            get;
            set;
        }

        [DataMember]
        public float FlightCycles
        {
            get;
            set;
        }

        [DataMember]
        public UseDetailInfoList UseDetails
        {
            get;
            set;
        }
    }
}
