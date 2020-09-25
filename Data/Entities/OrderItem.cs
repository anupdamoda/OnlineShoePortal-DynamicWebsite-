namespace OnlineShoePortal_DynamicWebsite_.Data.Entities
{
  public class OrderItem
  {
    public int Id { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public OrderViewModel Order { get; set; }
  }
}