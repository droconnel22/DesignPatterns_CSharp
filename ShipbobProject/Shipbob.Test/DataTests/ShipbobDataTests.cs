using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shipbob.Data.Entities;
using Shipbob.Data.Entities.Utility;
using Shipbob.Data.Repository;
using Shipbob.Service.Models.Inventory;
using Shipbob.Test.Utility;

namespace Shipbob.Test.DataTests
{

    /*
    Automated tests are generally NOT DONE for data layers! 
    there are truly more integration tests 
    */

    [TestClass]
    public class ShipbobDataTests
    {
        private BaseRepository<ItemEntity> inventoryRepository = new BaseRepository<ItemEntity>();

        private BaseRepository<OrderEntity>  orderRespoistory = new BaseRepository<OrderEntity>();


        public void SetUp()
        {
          
        }

        [TestMethod]
        public async Task WhenPassedInventoryStratgey_ForBlueBats_AlwaysRetuns_CollectionsOfUnSOldItems()
        {
          
            var result = await this.inventoryRepository.GetSomeByCriteria(25, (entity => entity.ItemColor == ItemColors.Blue && entity.ItemType == ItemTypes.Bat));

            Assert.AreEqual(25,result.Count());
            foreach (var entity in result)
            {
                Assert.AreNotEqual(0,entity.ItemId);
                Assert.AreEqual(ItemTypes.Bat,entity.ItemType);
                Assert.AreEqual(ItemColors.Blue, entity.ItemColor);
            }

        }

        [TestMethod]
        public async Task WhenPassedInventoryStrategy_ForWhiteHats_AlwaysReturns_CollectionOfUnsoldWhiteHats()
        {
            var result = await this.inventoryRepository.GetSomeByCriteria(25, (entity => entity.ItemColor == ItemColors.White && entity.ItemType == ItemTypes.Hat));

            Assert.AreEqual(25, result.Count());
            foreach (var entity in result)
            {
                Assert.AreNotEqual(0, entity.ItemId);
                Assert.AreEqual(ItemTypes.Hat, entity.ItemType);
                Assert.AreEqual(ItemColors.White, entity.ItemColor);
            }
        }

        [TestMethod]
        public async Task WhenPassedInventoryStrategy_ForRedBaseballs_AlwaysReturns_CollectionOfUnsoldRedBaseballs()
        {
            var result = await this.inventoryRepository.GetSomeByCriteria(25, (entity => entity.ItemColor == ItemColors.Red && entity.ItemType == ItemTypes.Baseball));

            Assert.AreEqual(25, result.Count());
            foreach (var entity in result)
            {
                Assert.AreNotEqual(0, entity.ItemId);
                Assert.AreEqual(ItemTypes.Baseball, entity.ItemType);
                Assert.AreEqual(ItemColors.Red, entity.ItemColor);
            }
        }

        [TestMethod]
        public async Task WhenAddingAnEntity_ValidItem_Always_AddsItemToDB_And_ReturnsTrue()
        {
            var result = await this.inventoryRepository.AddEntityAsync(ShipbobTestUtility.GetValidItemEntity);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task WhenAddingAnEntity_ValidOrder_Always_AddsITemToDB_ReturnsTrue()
        {
            var result = await this.orderRespoistory.AddEntityAsync(ShipbobTestUtility.GetValidOrderEntity());
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task WhenUpdatingAnEntity_ValidOrder_Always_UpdatesItems_AddsOrders_ReturnsTrue()
        {
            var currentItems = await this.inventoryRepository.GetSomeByCriteria(1, (entity => entity.IsSold == false));
            Assert.IsNotNull(currentItems);
            var currentitem = currentItems.FirstOrDefault();
            currentitem.IsSold = true;
            var result = await this.inventoryRepository.UpdateEntityAsync(currentitem);
            Assert.IsTrue(result);
        }

    }
}
