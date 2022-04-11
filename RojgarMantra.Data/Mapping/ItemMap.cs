//using System.Data.Entity;
//using RojgarMantra.Data.Entities;

//namespace RojgarMantra.Data.Mapping
//{
//    public class ItemMap
//    {
//        public ItemMap(EntityTypeBuilder<Item> entityBuilder)
//        {
//            entityBuilder.HasKey(b => b.Id);
//            entityBuilder.HasMany(b => b.OrderDetails)
//                .WithOne(bs => bs.Item)
//                .HasForeignKey(bs => bs.ItemId);
//            entityBuilder.ToTable("Items");
//        }
//    }
//}