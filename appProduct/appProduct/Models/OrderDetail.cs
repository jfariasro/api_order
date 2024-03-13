using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace appProduct.Models
{
    public class OrderDetail
    {
        [Key]
        [JsonPropertyName("idorderdetail")]
        public int IdOrderDetail { get; set; }

        [JsonPropertyName("idorder")]
        [ForeignKey("orderId")]
        public Order order { get; set; }

        [ForeignKey("productId")]
        [JsonPropertyName("product")]
        public Product product { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("priceUnit")]
        public int priceUnit { get; set; }

        [JsonPropertyName("subtotal")]
        public decimal Subtotal { get; set; }
    }
}
