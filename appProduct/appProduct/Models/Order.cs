using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace appProduct.Models
{
    public class Order
    {
        [Key]
        [JsonPropertyName("idorder")]
        public int IdOrder { get; set; }

        [ForeignKey("customerId")]
        [JsonPropertyName("idcustomer")]
        public Customer customer { get; set; }

        [JsonPropertyName("date")]
        public DateTime date { get; set; }
    }
}
