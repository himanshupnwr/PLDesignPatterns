using Adaptor.V2_Implementation.CharacterSourceAdapter;
using Adaptor.V2_Implementation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adaptor.V2_Implementation
{
    public class StarWarsCharacterDisplayService
    {
        private readonly ICharacterSourceAdapter _characterSourceAdapter;

        public StarWarsCharacterDisplayService(ICharacterSourceAdapter characterSourceAdapter)
        {
            _characterSourceAdapter = characterSourceAdapter;
        }

        public async Task<string> ListCharacters()
        {
            var people = await _characterSourceAdapter.GetCharacters();

            var sb = new StringBuilder();
            int nameWidth = 30;
            sb.AppendLine($"{"NAME".PadRight(nameWidth)}   {"HAIR"}");
            foreach (Person person in people)
            {
                sb.AppendLine($"{person.Name.PadRight(nameWidth)}   {person.HairColor}");
            }

            return sb.ToString();
        }
    }
}
