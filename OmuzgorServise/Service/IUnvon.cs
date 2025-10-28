using OmuzgorServise.Model;

namespace OmuzgorServise.Service
{
    public interface IUnvon
    {
        Task<IEnumerable<Unvon>> GetAllAsync();
        Task<Unvon?> GetByIdAsync(int  id);
        Task<Unvon> CreateAsync(Unvon unvon);
        Task<Unvon?> UpdateAsync(Unvon faculty);
        Task<bool> DeleteAsync(int id);
    }
}
