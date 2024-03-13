using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace appProduct.Models
{
    public class Customer
    {
        [Key]
        [JsonPropertyName("idcustomer")]
        public int idcustomer { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("phone")]
        public string phone { get; set; }

        [JsonPropertyName("age")]
        public int age { get; set; }

    }
}
