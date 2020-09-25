using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoePortal_DynamicWebsite_.Data.Entities
{
  public class OrderViewModel
  {
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderNumber { get; set; }
    public ICollection<OrderItem> Items { get; set; }
    public StoreUser User { get; set; }
    public object OrderId { get; internal set; }
  }
}
