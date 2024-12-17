using maratonAPI.Models;

namespace maratonAPI.Repositories.Interfaces
{
    public interface FutokInterface
    {
        Task<List<Futok>> AllRunners();
        Task<Futok> ById(int id);
    }
}
