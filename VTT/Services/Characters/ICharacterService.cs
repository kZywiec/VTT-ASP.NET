using VTT.Models.Entities;

namespace VTT.Services.Characters
{
    public interface ICharacterService
    {
        Character? CurrentCharacter { get;}

        Task SetCurrentCharacterById(int id);
    }
}