using SCA.AssetRegisterApi.DTOs;

namespace SCA.AssetRegisterApi.Services.Contracts
{
    public interface IAssetTypeService
    {
        Task<IEnumerable<AssetTypeDTO>> GetAll();
        Task<AssetTypeDTO> GetById(int id);

        Task<AssetTypeDTO> CreateAssetType(AssetTypeDTO assetTypeDTO);
        Task<AssetTypeDTO> UpdateAssetType(AssetTypeDTO assetTypeDTO);
        Task DeleteAssetType(int id);
            
    }
}
