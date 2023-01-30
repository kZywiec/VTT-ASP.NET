using VTT.Models.Entities;
using VTT.Services.Repositories;

namespace VTT.Services.Characters
{
    public class WorldService : IWorldService
    {
        private readonly IRepositoryBase<World> _repositoryBase;

        public World? CurrentWorld { get; set; }

        public WorldService(IRepositoryBase<World> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task SetCurrentWorldById(int id)
        {
            var world = await _repositoryBase.FindAsync(w => w.id == id);
            this.CurrentWorld = world.First();
        }
    }
}
