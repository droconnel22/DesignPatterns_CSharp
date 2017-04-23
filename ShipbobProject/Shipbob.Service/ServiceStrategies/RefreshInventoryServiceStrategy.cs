using System.Collections.Generic;
using System.Threading.Tasks;
using Shipbob.Data.Entities;
using Shipbob.Data.Entities.Utility;
using Shipbob.Data.Repository;
using Shipbob.Service.Common;
using Shipbob.Service.Models.Inventory;

namespace Shipbob.Service.ServiceStrategies
{
    public class RefreshInventoryServiceStrategy : IInventoryServiceStrategy
    {
        private readonly BaseRepository<ItemEntity> _baseRepository;

        public async Task<IDictionary<string, Queue<IItem>>> BuildInventory(int take = 0)
        {
            var resultDictionary = new Dictionary<string, Queue<IItem>>();

            var redBaseballs = await this._baseRepository.GetSomeByCriteria(take, BaseBallCriteria);
            resultDictionary.Add("baseball", redBaseballs.ConvertToModel());

            var blueBats = await this._baseRepository.GetSomeByCriteria(take, BlueBatCriteria);
            resultDictionary.Add("bat", blueBats.ConvertToModel());

            var whiteHats = await this._baseRepository.GetSomeByCriteria(take, WhiteHatCriteria);
            resultDictionary.Add("hat", whiteHats.ConvertToModel());

            return resultDictionary;
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