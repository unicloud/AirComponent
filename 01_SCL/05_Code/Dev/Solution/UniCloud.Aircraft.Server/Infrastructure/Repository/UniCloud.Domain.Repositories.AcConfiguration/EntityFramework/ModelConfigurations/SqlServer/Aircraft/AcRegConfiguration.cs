using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Domain.Model;

namespace UniCloud.Domain.Repositories.EntityFramework.ModelConfigurations.SqlServer
{
    public class AcRegConfiguration : EntityTypeConfiguration<AcReg>
    {
        public AcRegConfiguration()
        {
            HasKey(a => a.ID);
            Property(a => a.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.Guid).HasColumnName("GUID");
            Property(a => a.AcConfigGuid).HasColumnName("AC_CONFIG_GUID");
            Property(a => a.AcConfigID).HasColumnName("AC_CONFIG_ID");
            Property(a => a.AcModelGuid).HasColumnName("AC_MODEL_GUID");
            Property(a => a.AcModelID).HasColumnName("AC_MODEL_ID");
            Property(a => a.AcTypeGuid).HasColumnName("AC_TYPE_GUID");
            Property(a => a.AcTypeID).HasColumnName("AC_TYPE_ID");
            Property(a => a.CarryingCapacity).HasColumnName("CARRYING_CAPACITY");
            Property(a => a.CreateDate).HasColumnName("CREATE_DATE").HasColumnType("datetime2");
            Property(a => a.DecodeConfigGuid).HasColumnName("DECODE_CONFIG_GUID");
            Property(a => a.DecodeConfigID).HasColumnName("DECODE_CONFIG_ID");
            Property(a => a.EngineTr).HasColumnName("ENGINE_TR");
            Property(a => a.ExportDate).HasColumnName("EXPORT_DATE").HasColumnType("datetime2");
            Property(a => a.FactoryDate).HasColumnName("FACTORY_DATE").HasColumnType("datetime2");
            Property(a => a.ImportCategory).HasColumnName("IMPORT_CATEGORY");
            Property(a => a.ImportDate).HasColumnName("IMPORT_DATE").HasColumnType("datetime2");
            Property(a => a.IsOperation).HasColumnName("IS_OPERATION");
            Property(a => a.Msn).HasColumnName("MSN");
            Property(a => a.OffsetUTC).HasColumnName("OFFSET_UTC");
            Property(a => a.Operators).HasColumnName("OPERATORS");
            Property(a => a.RegNumber).HasColumnName("REG_NUMBER");
            Property(a => a.SeatingCapacity).HasColumnName("SEATING_CAPACITY");
            Property(a => a.SubframeLenght).HasColumnName("SUBFRAME_LENGHT");
            Property(a => a.ExportCategory).HasColumnName("EXPORTCATEGORY");
            Property(a => a.Owner).HasColumnName("OWNER").HasMaxLength(200);

            HasMany(a => a.AcregLicenses).WithRequired().HasForeignKey(a => a.AcRegID);

            ToTable("AC_REG",Schema.Name);
        }
    }
}
