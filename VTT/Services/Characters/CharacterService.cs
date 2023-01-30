using VTT.Models.Entities;
using VTT.Services.Repositories;

namespace VTT.Services.Characters
{
    public class CharacterService : ICharacterService
    {
        private readonly IRepositoryBase<Character> _repositoryBase;

        public Character? CurrentCharacter { get; set; }

        public CharacterService(IRepositoryBase<Character> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task SetCurrentCharacterById(int id)
        {
            var character = await _repositoryBase.FindAsync(ch => ch.id == id);
            this.CurrentCharacter = character.First();
        }
    }
}
