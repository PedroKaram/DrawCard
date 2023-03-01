using System.Text.Json.Serialization;

namespace Core
{
    public class Card
    {
        public string Code { get; set; }

        public int Value { get; set; }

        public string Suit { get; set; }

        [JsonConstructor] public Card() { }
    }
}