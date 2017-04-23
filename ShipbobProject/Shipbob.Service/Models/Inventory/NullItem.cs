namespace Shipbob.Service.Models.Inventory
{
    public class NullItem : IItem
    {
        private static NullItem instance;


        private NullItem()
        {
        }

        public static IItem GetInstance()
        {
            if (instance == null)
                instance = new NullItem();
            return instance;
        }

        public int ItemId => 0;
        public string ItemColor => string.Empty;
        public string ItemType => string.Empty;
        public bool IsSold => false;
    }
}