using Adaptor.V2_Implementation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adaptor.V2_Implementation.CharacterSourceAdapter
{
    public class CharacterToPersonAdapter : Person
    {
        private readonly Character _character;

        public CharacterToPersonAdapter(Character character)
        {
            _character = character ?? throw new ArgumentNullException(nameof(character));
        }

        public override string Name
        {
            get => _character.FullName;
            set => _character.FullName = value;
        }

        public override string HairColor
        {
            get => _character.Hair;
            set => _character.Hair = value;
        }
    }
}
