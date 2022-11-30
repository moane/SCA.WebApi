using SCA.AssetRegisterApi.DTOs;

namespace SCA.AssetRegisterApi.Services.Contracts
{
    public interface IAssetService
    {
        Task<IEnumerable<AssetDTO>> GetAll();
        Task<AssetDTO> GetById(int id);

        Task<AssetDTO> CreateAsset(AssetDTO AssetDTO);
        Task<AssetDTO> UpdateAsset(AssetDTO AssetDTO);
        Task DeleteAsset(int id);
            
    }
}
