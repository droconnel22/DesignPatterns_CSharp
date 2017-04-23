namespace ShipBob.Domain.ViewModels
{
    public  class ItemViewModel
    {
        public int ItemId { get; set; }

        public string ItemType { get; set; }

        public string ItemColor { get; set; }

        public bool IsSold { get; set; }
    }
}