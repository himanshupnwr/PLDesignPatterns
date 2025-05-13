using Adaptor.V2_Implementation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adaptor.V2_Implementation.CharacterSourceAdapter
{
    public interface ICharacterSourceAdapter
    {
        Task<IEnumerable<Person>> GetCharacters();
    }
}
