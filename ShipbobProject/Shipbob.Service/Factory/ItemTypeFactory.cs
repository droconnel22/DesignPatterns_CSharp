using Shipbob.Data.Entities.Utility;


namespace Shipbob.Service.Factory
{
    internal static class ItemTypeFactory
    {
        public static ItemColors TranslateItemColor(string itemColor)
        {
            ItemColors colorResult;
            ItemColors.TryParse(itemColor, out colorResult);
            return colorResult;
        }

        public static string TranslateItemColor(ItemColors itemColor) => itemColor.ToString();

        public static ItemTypes TranslateItemType(string itemType)
        {
            ItemTypes itemResult;
            ItemTypes.TryParse(itemType, out itemResult);
            return itemResult;
        }

        public static string TranslateItemType(ItemTypes itemType) => itemType.ToString();
    }
}