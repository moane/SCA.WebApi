using Microsoft.EntityFrameworkCore;
using SCA.AssetRegisterApi.Context;
using SCA.AssetRegisterApi.Models;
using SCA.AssetRegisterApi.Repositories.Contracts;

namespace SCA.AssetRegisterApi.Repositories
{
    
    public class AssetRepository : IAssetRepository
    {
        private readonly AssetContext _context;
        public  AssetRepository(AssetContext context)
        {
            _context = context;
        }
        public async Task<Asset> GetById(int id)
        {
            return  await _context.Assets.Include(c => c.AssetType).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public  async Task<IEnumerable<Asset>> GetAll()
        {
            return await _context.Assets.Include(c => c.AssetType).ToListAsync();
        }

        public async Task<Asset> Create(Asset asset)
        {
            _context.Assets.Add(asset);
            await _context.SaveChangesAsync();
            return asset;
        }
                      

        public async Task<Asset> Update(Asset asset)
        {
            _context.Entry(asset).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return asset;
        }

        public async Task<Asset> Delete(int id)
        {
            var asset = await GetById(id);
            _context.Assets.Remove(asset);
            await _context.SaveChangesAsync();
            return asset;
        }
    }
}
