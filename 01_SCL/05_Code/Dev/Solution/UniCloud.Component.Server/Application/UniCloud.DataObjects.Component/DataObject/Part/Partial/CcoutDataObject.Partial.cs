#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/21 9:41:58

// 文件名：CcoutDataObject.Partial
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

namespace UniCloud.DataObjects
{
   /// <summary>
   ///CcoutDataObject
   /// </summary>
   public partial class CcoutDataObject
   {
      private string PnField;
      private string SnField;
   
      [DataMemberAttribute()]
      public string Pn
      {
          get
          {
              return this.PnField;
          }
          set
          {
             if(this.PnField != value)
             {
                 this.PnField = value;
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
             if(this.SnField != value)
             {
                 this.SnField = value;
             }
          }
      }
      
   }
}
