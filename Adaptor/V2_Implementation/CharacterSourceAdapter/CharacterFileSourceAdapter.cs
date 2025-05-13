using Adaptor.V2_Implementation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Adaptor.V2_Implementation.CharacterSourceAdapter
{
    public class CharacterFileSourceAdapter : ICharacterSourceAdapter
    {
        private string _fileName;
        private readonly CharacterFileSource _characterFileSource;

        public CharacterFileSourceAdapter(string fileName, CharacterFileSource characterFileSource)
        {
            _fileName = fileName;
            _characterFileSource = characterFileSource;
        }

        public async Task<IEnumerable<Person>> GetCharacters() => (await _characterFileSource
                 .GetCharactersFromFile(_fileName))
                 .Select(character => new CharacterToPersonAdapter(character));
    }

    public class CharacterFileSource
    {
        public async Task<List<Character>> GetCharactersFromFile(string filename)
        {
            var characters = JsonSerializer.Deserialize<List<Character>>(await File.ReadAllTextAsync(filename));

            return characters;
        }
    }
}
