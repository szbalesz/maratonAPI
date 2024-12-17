using maratonAPI.Models;
using maratonAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace maratonAPI.Repositories.Services
{
    public class FutokService : FutokInterface
    {
        private readonly MaratonvaltoContext _context;

        public FutokService(MaratonvaltoContext context)
        {
            _context = context;
        }

        public async Task<List<GetRunnersDto>> RunnersAge()
        {
            var age = await _context.Futoks
                .Where(futo => 2016 - futo.Szulev > 42)
                .OrderByDescending(futo => 2016-futo.Szulev)
                .Select(futo => new GetRunnersDto(futo.Fnev, 2016 - futo.Szulev))
                .ToListAsync();
            return age;
        }

        public async Task<List<GetFemaleDto>> AllFemaleRunners()
        {
            var females = await _context.Futoks.Where(futo => futo.Ffi == false).OrderBy(x => x.Fnev).Select(x=> new GetFemaleDto(x.Fnev, x.Szulev )).ToListAsync();
            return females;
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
        public async Task<Futok> RunnerWithAllData(int id)
        {
            var runner = await _context.Futoks.Include(futo => futo.Eredmenyeks).FirstOrDefaultAsync(futo => futo.Fid == id);
            return runner;
        }

        public async Task<List<GetBestRunnerDto>> BestRunner()
        {
            var best = await _context.Futoks.Include(futo => futo.Eredmenyeks)
                .OrderByDescending(futo => futo.Eredmenyeks.Select(e => e.Ido))
                .Select(futo => new GetBestRunnerDto(futo.Fnev,futo.Eredmenyeks.Select(e=>e.Ido).FirstOrDefault()))
                .ToListAsync();
            return best;
        }
    }
}
