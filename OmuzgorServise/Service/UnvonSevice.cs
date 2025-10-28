using Microsoft.EntityFrameworkCore;
using OmuzgorServise.Data;
using OmuzgorServise.Model;

namespace OmuzgorServise.Service
{
    public class UnvonSevice:IUnvon
    {
        private readonly OmuzgorDbContext _context;

        public UnvonSevice(OmuzgorDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Unvon>> GetAllAsync()
            => await _context.Unvon
                .Include(f => f.Omuzgoron)                
                .ToListAsync();

        public async Task<Unvon?> GetByIdAsync(int id)
            => await _context.Unvon
                .Include(f => f.Omuzgoron)               
                .FirstOrDefaultAsync(f => f.Id == id);

        public async Task<Unvon> CreateAsync(Unvon unvon)
        {
            _context.Unvon.Add( unvon);
            await _context.SaveChangesAsync();
            return unvon;
        }
        public async Task<Unvon?> UpdateAsync(Unvon unvon)
        {
            var existing = await _context.Unvon.FindAsync(unvon.Id);
            if (existing == null) return null;

            existing.Nomgu = unvon.Nomgu;
            existing.Sharh=unvon.Sharh;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var unvon = await _context.Unvon.FindAsync(id);
            if (unvon == null) return false;

            _context.Unvon.Remove(unvon);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
