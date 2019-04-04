using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace Domain.Contracts
{
    public interface IReadRepository<T>
    {
        Task<Maybe<T>> Get(int id);
        Task<IEnumerable<T>> GetAll();
    }
}