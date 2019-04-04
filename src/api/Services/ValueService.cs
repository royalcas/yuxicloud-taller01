using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Domain.Contracts;
using Services.Contracts;
using Services.DTO;
using Domain;

namespace Services
{
    public class ValueService : IValueService
    {
        private readonly IValueRepository _valueRepository;

        public ValueService(IValueRepository valueRepository)
        {
            this._valueRepository = valueRepository;
        }

        public async Task<Result> AddValue(string value)
        {
            return await this._valueRepository.Add(new AValue(0, value));
        }

        public async Task<Result> DeleteValue(int id)
        {
            return await this._valueRepository.Delete(id);
        }

        public async Task<IEnumerable<ValueDTO>> GetAllValues()
        {
            return (await this._valueRepository.GetAll()).Select(CreateDTO);
        }

        public async Task<Maybe<ValueDTO>> GetValueById(int id)
        {
            return (await this._valueRepository.Get(id)).Select(CreateDTO);
        }

        public async Task<Result> UpdateValue(int id, string newValue)
        {
            return await this._valueRepository.Update(new AValue(id, newValue));
        }

        private ValueDTO CreateDTO(AValue value)
        {
            return new ValueDTO() { Id = value.Id, Value = value.TheValue };
        }
    }
}