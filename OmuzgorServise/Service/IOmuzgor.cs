using OmuzgorServise.Model;

namespace OmuzgorServise.Service
{
    public interface IOmuzgor
    {
        Task<IEnumerable<Omuzgor>> GetAllAsync();
        Task<Omuzgor?> GetByIdAsync(int id);
        Task<Omuzgor> CreateAsync(Omuzgor omuzgor);
        Task<Omuzgor?> UpdateAsync(Omuzgor omuzgor);
        Task<bool> DeleteAsync(int id);
    }
}
