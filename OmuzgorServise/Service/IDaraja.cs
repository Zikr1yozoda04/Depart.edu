using OmuzgorServise.Model;

namespace OmuzgorServise.Service
{
    public interface IDaraja
    {
        Task<IEnumerable<Daraja>> GetAllAsync();
        Task<Daraja?> GetByIdAsync(int id);
        Task<Daraja> CreateAsync(Daraja daraja);
        Task<Daraja?> UpdateAsync(Daraja daraja);
        Task<bool> DeleteAsync(int id);
    }
}
