//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using RojgarMantra.Data.Entities;

//namespace RojgarMantra.Data.Mapping
//{
//    public class OrderMap
//    {
//        public OrderMap(EntityTypeBuilder<Order> entityBuilder)
//        {
//            entityBuilder.HasKey(b => b.Id);
//            entityBuilder.HasMany(b => b.OrderDetails)
//                .WithOne(bs => bs.Order)
//                .HasForeignKey(bs => bs.OrderId);
//            entityBuilder.ToTable("Orders");
//        }
//    }
//}