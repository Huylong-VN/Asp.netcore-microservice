namespace Basket.API.Entities
{
    public class CartItem
    {
        public int? Quantity { set; get; }
        public decimal? ItemPrice { set; get; }
        public string? ItemNo { set; get; }
        public string? ItemName { set; get; }
    }
}
