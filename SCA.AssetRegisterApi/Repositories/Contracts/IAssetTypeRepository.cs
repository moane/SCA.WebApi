using SCA.AssetRegisterApi.Models;

namespace SCA.AssetRegisterApi.Repositories.Contracts;

public interface IAssetTypeRepository
{
    Task<IEnumerable<AssetType>> GetAll();

    Task<AssetType> GetById(int id);
    Task<AssetType> Delete(int id);

    //retornar ou não? retonar um bool, um result 
    Task<AssetType> Create(AssetType assetType);
    Task<AssetType> Update(AssetType assetType);


}
