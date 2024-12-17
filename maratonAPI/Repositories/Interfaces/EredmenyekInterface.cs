using maratonAPI.Models;

namespace maratonAPI.Repositories.Interfaces
{
    public interface EredmenyekInterface
    {
        Task<Eredmenyek> NewResult(Eredmenyek eredmenyek);
    }
}
