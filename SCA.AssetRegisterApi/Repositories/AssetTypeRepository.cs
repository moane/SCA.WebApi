using Microsoft.EntityFrameworkCore;
using SCA.AssetRegisterApi.Context;
using SCA.AssetRegisterApi.Models;
using SCA.AssetRegisterApi.Repositories.Contracts;

namespace SCA.AssetRegisterApi.Repositories
{
    
    public class AssetTypeRepository : IAssetTypeRepository
    {
        private readonly AssetContext _context;
        public  AssetTypeRepository(AssetContext context)
        {
            _context = context;
        }
        public async Task<AssetType> GetById(int id)
        {
            return  await _context.AssetTypes.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public  async Task<IEnumerable<AssetType>> GetAll()
        {
            return await _context.AssetTypes.ToListAsync();
        }

        public async Task<AssetType> Create(AssetType assetType)
        {
            _context.AssetTypes.Add(assetType);
            await _context.SaveChangesAsync();
            return assetType;
        }
                      

        public async Task<AssetType> Update(AssetType assetType)
        {
            _context.Entry(assetType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return assetType;
        }

        public async Task<AssetType> Delete(int id)
        {
            var assetType = await GetById(id);
            _context.AssetTypes.Remove(assetType);
            await _context.SaveChangesAsync();
            return assetType;
        }
    }
}
