using Shipbob.Data.Entities;
using Shipbob.Data.Entities.Utility;
using Shipbob.Data.Repository;
using Shipbob.Service.Models.Inventory;
using Shipbob.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Shipbob.Service.Common;
using Shipbob.Service.Configuration;
using Shipbob.Service.Factory;

namespace Shipbob.Service.ServiceStrategies
{

    public class DefaultInventoryStrategy : IInventoryServiceStrategy
    {
        private readonly IServiceConfiguration serviceConfiguration;

        private readonly IDictionary<string, Queue<IItem>> creationalDictionary;

        private readonly BaseRepository<ItemEntity> _baseRepository;

        public DefaultInventoryStrategy(IServiceConfiguration serviceConfiguration)
        {
            this.serviceConfiguration = serviceConfiguration;
            this._baseRepository = new BaseRepository<ItemEntity>();
            this.creationalDictionary = new Dictionary<string, Queue<IItem>>();
        }

        public async Task<IDictionary<string, Queue<IItem>>> BuildInventory(int take = 0)
        {
            var redBaseballs = await this._baseRepository.GetSomeByCriteria(this.serviceConfiguration.LoadItemCountFromDatabase, BaseBallCriteria);
            this.creationalDictionary.Add("baseball", redBaseballs.ConvertToModel());

            var blueBats = await this._baseRepository.GetSomeByCriteria(this.serviceConfiguration.LoadItemCountFromDatabase, BlueBatCriteria);
            this.creationalDictionary.Add("bat", blueBats.ConvertToModel());

            var whiteHats = await this._baseRepository.GetSomeByCriteria(this.serviceConfiguration.LoadItemCountFromDatabase, WhiteHatCriteria);
            this.creationalDictionary.Add("hat", whiteHats.ConvertToModel());

            return this.creationalDictionary;
        }

        private bool WhiteHatCriteria(ItemEntity itemEntity) => LoadItemsCriteria(itemEntity, ItemColors.White, ItemTypes.Hat);

        private bool BlueBatCriteria(ItemEntity itemEntity) => LoadItemsCriteria(itemEntity, ItemColors.Blue, ItemTypes.Bat);

        private bool BaseBallCriteria(ItemEntity itemEntity) => LoadItemsCriteria(itemEntity, ItemColors.Red, ItemTypes.Baseball);

        private bool LoadItemsCriteria(ItemEntity i, ItemColors itemColor, ItemTypes itemType) =>
            i.IsSold == false
                    && i.ItemColor == itemColor
                    && i.ItemType == itemType;

    }
}
