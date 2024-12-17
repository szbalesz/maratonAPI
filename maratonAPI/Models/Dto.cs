namespace maratonAPI.Models
{
   public record GetFemaleDto(string? Fnev, int? Szulev);
   public record GetRunnersDto(string? Fnev, int? Eletkor);
   public record GetBestRunnerDto(string? Fnev, int? Korido);
}
