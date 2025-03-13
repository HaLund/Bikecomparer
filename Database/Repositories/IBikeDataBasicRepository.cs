using DomainObjects;
using Database.EntityModels;

namespace Database.Repositories
{
    public interface IBikeDataBasicRepository : IRepositoryBase<BikeDataMain>
    {
        Task<BikeDetails> GetBikeAsync(int id);
        Task<BikeDetails> GetBikeAsync(int id1, int id2);
        Task<BikeDetails> GetBikeAsync(int id1, int id2, int id3);
        Task<BikeDetails> GetBikeAsync(int id1, int id2, int id3, int id4);
        Task<int> GetAmountOfBikesDefaultQueryAsync();
        Task<BikeDataBasic> GetAllBikesAsync(BikeDataBasic bikeDataBasic, int pageSize, int itemsToSkip, bool queryChangedSinceLastRequest);
    }
}
