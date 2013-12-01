#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/6 10:51:21

// 文件名：OilAnalysisDataObject.Partial
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
   ///OilAnalysisDataObject
   /// </summary>
   public partial class OilAnalysisDataObject
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
               }
           }
       }
   }
}
