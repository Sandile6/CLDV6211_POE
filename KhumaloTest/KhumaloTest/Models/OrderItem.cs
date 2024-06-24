using System.ComponentModel.DataAnnotations.Schema;

namespace KhumaloTest.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        public int CraftworkId { get; set; }

        [ForeignKey("CraftworkId")]
        public Craftwork Craftwork { get; set; }

        public int Quantity { get; set; }
    }
}