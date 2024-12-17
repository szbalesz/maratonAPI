using maratonAPI.Models;

namespace maratonAPI.Repositories.Interfaces
{
    public interface FutokInterface
    {
        Task<List<Futok>> AllRunners();
        Task<Futok> ById(int id);
        Task<Futok> RunnerWithAllData(int id);
        Task<List<GetFemaleDto>> AllFemaleRunners(); 
        Task<List<GetRunnersDto>> RunnersAge(); 
        Task<List<GetBestRunnerDto>> BestRunner(); 
    }
}
