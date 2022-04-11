using System;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB;
using RojgarMantra.Data.Entities;

namespace RojgarMantra.Data.Helpers
{
   /* public class DatabaseSeeder
    {
        private readonly DatabaseContext _dataContext;

        public DatabaseSeeder(DatabaseContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<int> SeedItemEntries()
        {
            _dataContext.Items.Add(
                new Item()
                {
                    ItemDesc = "Samsung 32 inch LCD TV",
                    ItemNo = "SA-3348",
                    SellPrice = 35000
                });

            _dataContext.Items.Add(
                new Item()
                {
                    ItemDesc = "LG 21 inch LCD TV",
                    ItemNo = "LGA-37442",
                    SellPrice = 15000
                });

            // TODO implement method
            return await _dataContext.SaveChangesAsync();
        }

        public async Task<int> SeedSupplierEntries()
        {
            _dataContext.Suppliers.Add(new Supplier()
            {
                Name = "Best Electronics"
            });
            // TODO implement method
            return await _dataContext.SaveChangesAsync();
        }

        //public async Task<int> SeedOrdeEntries()
        //{
        //    _dataContext.Suppliers.Add(new Order()
        //    {
        //        Name = "Best Electronics"
        //    });
        //    // TODO implement method
        //    return await _dataContext.SaveChangesAsync();
        //}

        //public async Task<int> SeedOrderDetailEntries()
        //{
        //    var rincewindItems =
        //        _dataContext.Items.Where(item => item.ItemName == "The Colour of Magic");

        //    var rincewindSupplier = _dataContext.Supplier.FirstOrDefault(series => series.SupplierName == "Rincewind");

        //    if (!rincewindItems.Any() || rincewindSupplier == null)
        //    {
        //        throw new ArgumentException($"Unable to see {nameof(OrderDetail)}");
        //    }

        //    _dataContext.OrderDetail.AddRange(rincewindItems.Select(b => new OrderDetail()
        //    {
        //        ItemId = b.Id,
        //        SupplierId = rincewindSupplier.Id
        //    }));

        //    // TODO implement method
        //    return await _dataContext.SaveChangesAsync();
        //}
    }*/
}