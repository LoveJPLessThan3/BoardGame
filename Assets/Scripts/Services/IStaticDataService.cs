public interface IStaticDataService : IService
{
    StaticDataPlayers ForPlayer(Players playersId);
    void LoadPlayers();
}