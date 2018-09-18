namespace ShopSite.Models
{
    public class ItemPosition
    {
        public int ItemPositionId { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal OrderValue { get; set; }

        public virtual Item Item { get; set; }
        public virtual Order Order { get; set; }
    }
}