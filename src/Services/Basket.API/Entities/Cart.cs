namespace Basket.API.Entities
{
    public class Cart
    {
        public string? UserName { set; get; }

        public List<CartItem> Items { set; get; } = new();

        public Cart() { }

        public Cart(string? userName)
        {
            UserName = userName;
        }

        public decimal? TotalPrice => Items.Sum(x => x.ItemPrice * x.Quantity);
    }
}
