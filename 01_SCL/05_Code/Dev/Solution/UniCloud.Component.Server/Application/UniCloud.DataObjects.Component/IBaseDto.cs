using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniCloud.DataObjects
{
    public interface IBaseDto
    {
        string Sequence { get; }
        Nullable<int> ID { get; set; }
    }
}
