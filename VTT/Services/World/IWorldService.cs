using VTT.Models.Entities;

namespace VTT.Services.Characters
{
    public interface IWorldService
    {
        World? CurrentWorld { get; set; }

        Task SetCurrentWorldById(int id);
    }
}