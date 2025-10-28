using Microsoft.EntityFrameworkCore;
using OmuzgorServise.Data;
using OmuzgorServise.Model;
namespace OmuzgorServise.Service
{
    public class DarajaService:IDaraja
    {
        private readonly OmuzgorDbContext _context;

        public DarajaService(OmuzgorDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Daraja>> GetAllAsync()
            => await _context.Daraja
                .Include(f => f.Omuzgoron)
                .ToListAsync();

        public async Task<Daraja?> GetByIdAsync(int id)
            => await _context.Daraja
                .Include(f => f.Omuzgoron)
                .FirstOrDefaultAsync(f => f.Id == id);

        public async Task<Daraja> CreateAsync(Daraja daraja)
        {
            _context.Daraja.Add(daraja);
            await _context.SaveChangesAsync();
            return daraja;
        }
        public async Task<Daraja?> UpdateAsync(Daraja daraja)
        {
            var existing = await _context.Daraja.FindAsync( daraja.Id);
            if (existing == null) return null;

            existing.Nomgu = daraja.Nomgu;
            existing.Sharh = daraja.Sharh;         
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var daraja = await _context.Daraja.FindAsync(id);
            if (daraja == null) return false;

            _context.Daraja.Remove( daraja);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
