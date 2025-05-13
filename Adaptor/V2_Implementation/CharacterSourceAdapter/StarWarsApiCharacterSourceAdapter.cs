using Adaptor.V2_Implementation.Models;
using System.Text.Json;

namespace Adaptor.V2_Implementation.CharacterSourceAdapter
{
    public class StarWarsApiCharacterSourceAdapter : ICharacterSourceAdapter
    {
        private StarWarsApi _starWarsApi;
        public StarWarsApiCharacterSourceAdapter(StarWarsApi starWarsApi)
        {
            _starWarsApi = starWarsApi;
        }

        public async Task<IEnumerable<Person>> GetCharacters()
        {
            return await _starWarsApi.GetCharacters();
        }
    }

    public class StarWarsApi
    {
        public async Task<List<Person>> GetCharacters()
        {
            using (var client = new HttpClient())
            {
                string url = "https://swapi.co/api/people";
                string result = await client.GetStringAsync(url);
                var apiResult = JsonSerializer.Deserialize<List<Person>>(result);
                return apiResult;
            }
        }
    }
}
