#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：zhangnx 时间：2013/8/14 17:30:53
// 文件名：PropertyCodeContainer
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

namespace BaseCodeTools.AutoGenerate.PropertyCode
{
    public class PropertyCodeContainer
    {
        private static PropertyCodeContainer _instance;
        private readonly Dictionary<string, IPropertyCode> _propertyCodes = new Dictionary<string, IPropertyCode>();

        public PropertyCodeContainer()
        {
            RegisterPropertyCode();
        }

        private void RegisterPropertyCode()
        {
            _propertyCodes.Add("String", new StringProperty("string"));
            _propertyCodes.Add("Int32", new IntProperty("int"));
            _propertyCodes.Add("DateTime", new DateTimeProperty("DateTime"));
            _propertyCodes.Add("Decimal", new DecimalProperty("decimal"));
            _propertyCodes.Add("Boolean", new BooleanProperty("bool"));
            _propertyCodes.Add("bool", new BooleanProperty("bool"));
            _propertyCodes.Add("Guid", new GuidProperty("Guid"));
            _propertyCodes.Add("GuidClass", new GuidClassProperty("Guid"));
            _propertyCodes.Add("Byte", new ByteProperty("byte"));
            _propertyCodes.Add("ByteArray", new ByteArrayProperty("byte[]"));
            _propertyCodes.Add("Xml", new XmlProperty("string"));
            _propertyCodes.Add("DataObject", new DataObjectProperty("DataObject"));
            _propertyCodes.Add("Collection", new CollectionProperty("Collection"));
        }

        public static PropertyCodeContainer GetInstance()
        {
            return _instance ?? (_instance = new PropertyCodeContainer());
        }

        public IPropertyCode GetProertyCode(string propertyType)
        {
            IPropertyCode iCode;
            if (_propertyCodes.TryGetValue(propertyType,out iCode))
            {
                return iCode;
            }
            else
            {
                return null;
            }
        }
    }
}
