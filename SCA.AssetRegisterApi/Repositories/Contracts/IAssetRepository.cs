using SCA.AssetRegisterApi.Models;

namespace SCA.AssetRegisterApi.Repositories.Contracts;

public interface IAssetRepository
{
    Task<IEnumerable<Asset>> GetAll();

    Task<Asset> GetById(int id);
    Task<Asset> Delete(int id);

    //retornar ou não? retonar um bool, um result 
    Task<Asset> Create(Asset Asset);
    Task<Asset> Update(Asset Asset);


}
