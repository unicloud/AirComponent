using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using UniCloud.DataObjects;
using UniCloud.Domain.Model;

namespace UniCloud.Application
{
    public class ApplicationAutoMap
    {
        public static void Initialize()
        {
            Mapper.CreateMap<AcCategory, AcCategoryDataObject>();
            Mapper.CreateMap<AcCategoryDataObject, AcCategory>();
            Mapper.CreateMap<AcConfig, AcConfigDataObject>();
            Mapper.CreateMap<AcConfigDataObject, AcConfig>();
            Mapper.CreateMap<AcModel, AcModelDataObject>();
            Mapper.CreateMap<AcModelDataObject, AcModel>();
            Mapper.CreateMap<AcReg, AcRegDataObject>();
            Mapper.CreateMap<AcRegDataObject, AcReg>();
            Mapper.CreateMap<AcregLicense, AcregLicenseDataObject>();
            Mapper.CreateMap<AcregLicenseDataObject, AcregLicense>();
            Mapper.CreateMap<AcType, AcTypeDataObject>();
            Mapper.CreateMap<AcTypeDataObject, AcType>();
            Mapper.CreateMap<Ata, AtaDataObject>().ForMember(p=>p.ChildAtas,p=>p.Ignore());
            Mapper.CreateMap<AtaDataObject, Ata>();
            Mapper.CreateMap<LicenseType, LicenseTypeDataObject>();
            Mapper.CreateMap<LicenseTypeDataObject, LicenseType>();
        }
    }
}
