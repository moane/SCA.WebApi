using AutoMapper;
using SCA.AssetRegisterApi.DTOs;
using SCA.AssetRegisterApi.Models;
using SCA.AssetRegisterApi.Repositories.Contracts;
using SCA.AssetRegisterApi.Services.Contracts;

namespace SCA.AssetRegisterApi.Services
{
    public class AssetTypeService : IAssetTypeService
    {
        private readonly IAssetTypeRepository _assetTypeRepository;
        private readonly IMapper _mapper;

        public AssetTypeService(IAssetTypeRepository assetTypeRepository, IMapper mapper)
        {
            _assetTypeRepository = assetTypeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AssetTypeDTO>> GetAll()
        {
            var assetTypes = await _assetTypeRepository.GetAll();
            return _mapper.Map<IEnumerable<AssetTypeDTO>>(assetTypes);
        }

        public async Task<AssetTypeDTO> GetById(int id)
        {
            var assetTypes = await _assetTypeRepository.GetById(id);
            return _mapper.Map<AssetTypeDTO>(assetTypes);
        }

        public async Task<AssetTypeDTO> CreateAssetType(AssetTypeDTO assetTypeDTO)
        {
            var assetTypeEntity = _mapper.Map<AssetType>(assetTypeDTO);
            await _assetTypeRepository.Create(assetTypeEntity);
            assetTypeDTO.Id = assetTypeEntity.Id;

            return assetTypeDTO;

        }
              

        public async Task<AssetTypeDTO> UpdateAssetType(AssetTypeDTO assetTypeDTO)
        {
            var assetTypeEntity = _mapper.Map<AssetType>(assetTypeDTO);
            await _assetTypeRepository.Update(assetTypeEntity);
            assetTypeDTO.Id = assetTypeEntity.Id;

            return assetTypeDTO;
        }

        public async Task DeleteAssetType(int id)
        {            
            await _assetTypeRepository.Delete(id);
            

        }
    }
}
