using DuongTrongTuanAnh_2280600041_lab06.Models;

namespace DuongTrongTuanAnh_2280600041_lab06.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        Product Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
