using FlightOffer.DAL.Entities;

namespace FlightOffer.DAL.Repositories.Interfaces
{
    public interface IAsyncRepository<T>
    {
        void Add(T item);
        void Update(T item);
        void AddMultiple(IList<Data> data);
        void Delete(T item);
        IList<T> GetAll();
        T GetById(int id);
        IList<T> Search(Filter filter);
    }
}
