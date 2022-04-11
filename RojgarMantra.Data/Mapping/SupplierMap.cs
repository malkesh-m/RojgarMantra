//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using RojgarMantra.Data.Entities;

//namespace RojgarMantra.Data.Mapping
//{
//    public class SupplierMap
//    {
//        public SupplierMap(EntityTypeBuilder<Supplier> entityBuilder)
//        {
//            entityBuilder.HasKey(s => s.Id);
//            entityBuilder.HasMany(s => s.Orders)
//                .WithOne(bs => bs.Supplier)
//                .HasForeignKey(bs => bs.SupplierId);
//            entityBuilder.ToTable("Supplier");
//        }
//    }
//}