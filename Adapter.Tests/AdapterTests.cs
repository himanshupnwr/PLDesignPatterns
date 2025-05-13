using Adaptor.V2_Implementation;
using Adaptor.V2_Implementation.CharacterSourceAdapter;
using Xunit.Abstractions;

namespace Adapter.Tests
{
    public class AdapterTests
    {
        private readonly ITestOutputHelper _output;

        public AdapterTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task DisplayCharactersFromFile()
        {
            string filename = @"Adapter/People.json";
            var service = new StarWarsCharacterDisplayService(
                new CharacterFileSourceAdapter(filename, new CharacterFileSource()));

            var result = await service.ListCharacters();

            _output.WriteLine(result);
        }

        [Fact]
        public async Task DisplayCharactersFromApi()
        {
            var service = new StarWarsCharacterDisplayService(
                new StarWarsApiCharacterSourceAdapter(new StarWarsApi()));

            var result = await service.ListCharacters();

            _output.WriteLine(result);
        }
    }
}