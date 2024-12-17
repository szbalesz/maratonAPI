using maratonAPI.Models;
using maratonAPI.Repositories.Interfaces;

namespace maratonAPI.Repositories.Services
{
    public class EredmenyekService : EredmenyekInterface
    {
        private readonly MaratonvaltoContext _context;

        public EredmenyekService(MaratonvaltoContext context)
        {
            _context = context;
        }

        public async Task<Eredmenyek> NewResult(Eredmenyek eredmenyek)
        {
            var ujEredmeny = new Eredmenyek{ 
                Futo = eredmenyek.Futo,
                Kor = eredmenyek.Kor,
                Ido = eredmenyek.Ido
            };
            await _context.Eredmenyeks.AddAsync(ujEredmeny);
            await _context.SaveChangesAsync();
            return ujEredmeny;
        }
    }
}
