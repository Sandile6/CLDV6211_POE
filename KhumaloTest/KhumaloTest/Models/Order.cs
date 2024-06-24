namespace KhumaloTest.Models
{
    public class Order
    {
        public User User { get; set; }
        public string ClientName { get; set; }
        public string Email { get; set; }
        public int CraftworkId { get; set; }
        public Craftwork Craftwork { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }


    }
}