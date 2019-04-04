using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace Domain.Contracts
{
    public interface IWriteRepository<T>
    {
        Task<Result> Add(T value);
        Task<Result> Update(T value);
        Task<Result> Delete(int id);
    }
}