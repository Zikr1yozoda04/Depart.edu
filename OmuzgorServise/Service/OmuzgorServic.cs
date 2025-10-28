using Microsoft.EntityFrameworkCore;
using OmuzgorServise.Data;
using OmuzgorServise.Model;
using System.Text.RegularExpressions;

namespace OmuzgorServise.Service
{
    public class OmuzgorServic:IOmuzgor
    {
        private readonly OmuzgorDbContext _context;

        public OmuzgorServic(OmuzgorDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Omuzgor>> GetAllAsync()
        => await _context.Omuzgoron
            .Include(g => g.Unvon)
            .Include(g => g.Daraja)
            .ToListAsync();

        public async Task<Omuzgor?> GetByIdAsync(int id)
        => await _context.Omuzgoron
            .Include(g => g.Daraja)
            .Include(g => g.Unvon)
            .FirstOrDefaultAsync(g => g.Id == id);

        public async Task<Omuzgor> CreateAsync(Omuzgor omuzgor)
        {
            _context.Omuzgoron.Add(omuzgor);
            await _context.SaveChangesAsync();
            return omuzgor;
        }
        public async Task<Omuzgor?> UpdateAsync(Omuzgor omuzgor)
        {
            var existing = await _context.Omuzgoron.FindAsync(omuzgor.Id);
            if (existing == null) return null;

            existing.FullName = omuzgor.FullName;
            existing.Pol=omuzgor.Pol;
            existing.Telephon=omuzgor.Telephon;
            existing.IdUnvon=omuzgor.IdUnvon;
            existing.IdDaraja=omuzgor.IdDaraja;
            existing.Email=omuzgor.Email;
            existing.Rasm=omuzgor.Rasm;
            existing.JoiZist=omuzgor.JoiZist;
            existing.JoiTav=omuzgor.JoiTav;
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var omuzgor  = await _context.Omuzgoron.FindAsync(id);
            if (omuzgor == null) return false;

            _context.Omuzgoron.Remove(omuzgor);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
