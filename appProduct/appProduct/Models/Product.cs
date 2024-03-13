using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace appProduct.Models
{
    public class Product
    {
        [Key]
        [JsonPropertyName("idproduct")]
        public int idproduct { get; set; }

        [JsonPropertyName("name")]
        public string? name { get; set; }

        [JsonPropertyName("description")]
        public string? description { get; set; }

        [JsonPropertyName("quantity")]
        public int? quantity { get; set; }

        [JsonPropertyName("price")]
        public decimal? price { get; set; }

        [JsonPropertyName("usefulLife")]
        public int? usefulLife { get; set; }

    }
}
