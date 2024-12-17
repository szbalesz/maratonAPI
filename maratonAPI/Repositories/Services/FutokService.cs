using maratonAPI.Models;
using maratonAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace maratonAPI.Repositories.Services
{
    public class FutokService : FutokInterface
    {
        private readonly MaratonvaltoContext _context;

        public FutokService(MaratonvaltoContext context)
        {
            _context = context;
        }

        public async Task<List<Futok>> AllRunners()
        {
            var runners = await _context.Futoks.ToListAsync();
            return runners;
        }

        public async Task<Futok> ById(int id)
        {
            var runner = await _context.Futoks.FirstOrDefaultAsync(x => x.Fid == id);
            return runner;
        }
    }
}
