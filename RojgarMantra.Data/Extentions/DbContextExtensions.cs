//using RojgarMantra.Data.Helpers;
//using System.Linq;

//namespace RojgarMantra.Data.Extentions
//{
//    public static class DbContextExtensions
//    {
//        public static int EnsureSeedData(this DatabaseContext appContext)
//        {
//            var itemCount = default(int);
//            var supplierCount = default(int);
//            var orderCount = default(int);
//            var orderDetailCount = default(int);

//            var dbSeeder = new DatabaseSeeder(appContext);

//            if (!appContext.Items.Any())
//            {
//                itemCount = dbSeeder.SeedItemEntries().Result;
//            }

//            if (!appContext.Suppliers.Any())
//            {
//                supplierCount = dbSeeder.SeedSupplierEntries().Result;
//            }

//            if (!appContext.Orders.Any())
//            {
//                //itemSupplierCount = dbSeeder.SeedOrderEntries().Result;
//            }

//            if (!appContext.OrderDetails.Any())
//            {
//                //itemSupplierCount = dbSeeder.SeedOrderDetailEntries().Result;
//            }

//            return itemCount + supplierCount + orderCount + orderDetailCount;
//        }
//    }
//}