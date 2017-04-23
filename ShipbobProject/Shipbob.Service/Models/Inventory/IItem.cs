namespace Shipbob.Service.Models.Inventory
{
    public interface IItem
    {
        int ItemId { get; }
        string ItemColor { get; }

        string ItemType { get; }

        bool IsSold { get; }

    }
}