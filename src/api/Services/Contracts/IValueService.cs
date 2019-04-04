using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Services.DTO;

namespace Services.Contracts
{
    public interface IValueService
    {
        Task<Maybe<ValueDTO>> GetValueById(int id);
        Task<IEnumerable<ValueDTO>> GetAllValues();
        Task<Result> AddValue(string value);
        Task<Result> UpdateValue(int id, string newValue);
        Task<Result> DeleteValue(int id);
    }
}
