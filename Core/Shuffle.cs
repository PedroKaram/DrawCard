using System.Text.Json.Serialization;

namespace Core
{
    public class Shuffle
    {
        public string Deck_Id { get; set; }

        public int Remaining { get; set; }

        [JsonConstructor] public Shuffle(){ }
    }
}
