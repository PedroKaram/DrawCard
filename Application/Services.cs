using Core;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Application
{
    public class Services
    {

		Shuffle Deck = new Shuffle();
		public async Task<Shuffle> RunAsync()
        {
			try
			{
				using (HttpClient client = new HttpClient()) 
				{
					client.BaseAddress = new Uri("https://www.deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1");
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
					if (response.IsSuccessStatusCode) 
					{
						Deck = await response.Content.ReadFromJsonAsync<Shuffle>();
					}

					return Deck;
				}
			}

			catch (Exception)
			{

				return null;
			}
        }

		public async Task<Card> RunDrawAsync()
		{
            Card Cards = new Card();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://www.deckofcardsapi.com");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var deckId = await RunAsync();
                    
                    HttpResponseMessage response = await client.GetAsync("/api/deck/sbvd4wy1i6nk/draw/?count=1");
                    if (response.IsSuccessStatusCode)
                    {
                        //Cards = Newtonsoft.Json.JsonConvert.DeserializeObject<Card>(await response.Content.ReadFromJsonAsync());
                        Cards = await response.Content.ReadFromJsonAsync<Card>();
                    }

                    return Cards;
                }
            }

            catch (Exception)
            {

                return null;
            }
        }
    }
}