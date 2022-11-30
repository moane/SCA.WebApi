using AutoMapper;
using SCA.AssetRegisterApi.DTOs;
using SCA.AssetRegisterApi.Models;
using SCA.AssetRegisterApi.Repositories.Contracts;
using SCA.AssetRegisterApi.Services.Contracts;

namespace SCA.AssetRegisterApi.Services
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IMapper _mapper;

        public AssetService(IAssetRepository AssetRepository, IMapper mapper)
        {
            _assetRepository = AssetRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AssetDTO>> GetAll()
        {
            var Assets = await _assetRepository.GetAll();
            return _mapper.Map<IEnumerable<AssetDTO>>(Assets);
        }

        public async Task<AssetDTO> GetById(int id)
        {
            var assets = await _assetRepository.GetById(id);
            return _mapper.Map<AssetDTO>(assets);
        }

        public async Task<AssetDTO> CreateAsset(AssetDTO assetDTO)
        {
            var assetEntity = _mapper.Map<Asset>(assetDTO);
            await _assetRepository.Create(assetEntity);
            assetDTO.Id = assetEntity.Id;

            return assetDTO;

        }
              

        public async Task<AssetDTO> UpdateAsset(AssetDTO assetDTO)
        {
            var assetEntity = _mapper.Map<Asset>(assetDTO);
            await _assetRepository.Update(assetEntity);
            assetDTO.Id = assetEntity.Id;

            return assetDTO;
        }

        public async Task DeleteAsset(int id)
        {            
            await _assetRepository.Delete(id);
            

        }
    }
}
