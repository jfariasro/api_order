using appProduct.Models;

namespace appProduct.Repository.Interfaces
{
    public interface IGenericRepository<TEntityModel> where TEntityModel : class
    {
        Task<string> Create(TEntityModel model);
        Task<IEnumerable<TEntityModel>> Read();
        Task<TEntityModel> Search(int id);
        Task<bool> Update(int id, TEntityModel model);
        Task<bool> Delete(int id);
    }
}
