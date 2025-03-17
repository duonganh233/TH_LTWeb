using DuongTrongTuanAnh_2280600041.Models;

namespace DuongTrongTuanAnh_2280600041.Repository
{

    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int id);
    }
}
