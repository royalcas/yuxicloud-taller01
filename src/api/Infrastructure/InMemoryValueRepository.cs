using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Domain;
using Domain.Contracts;
using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
    public class InMemoryValueRepository : IValueRepository
    {
        private readonly IConfiguration _configuration;
        private static Dictionary<int, AValue> _inMemoryDB = new Dictionary<int, AValue>();

        private static object __lockObj = new object();
        private static int _currentId = 0;
        private static int _nextId {
            get {
                lock(__lockObj)
                {
                    return ++_currentId;
                }
            }
        }

        public InMemoryValueRepository(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<Maybe<AValue>> Get(int id)
        {
            if(await this.IsKeyPresentInDB(id))
                return Maybe<AValue>.From(_inMemoryDB[id]);
            else
                return Maybe<AValue>.None;
        }

        public async Task<IEnumerable<AValue>> GetAll()
        {
            var result = new List<AValue>();
            foreach(var value in _inMemoryDB)
                result.Add(value.Value);
            return result;
        }

        public async Task<Result> Add(AValue value)
        {
            var id = _nextId;
            var valueToInsert = new AValue(id, value.TheValue);
            _inMemoryDB[id] = valueToInsert;
            return Result.Ok();
        }

        public async Task<Result> Delete(int id)
        {
            if(await this.IsKeyPresentInDB(id))
            {
                _inMemoryDB.Remove(id);
                return Result.Ok();
            }
            else
                return Result.Fail("This ID is not present in the DB");
        }

        public async Task<Result> Update(AValue value)
        {
            if(await this.IsKeyPresentInDB(value.Id))
            {
                _inMemoryDB[value.Id] = value;
                return Result.Ok();
            }
            else
                return Result.Fail("This ID is not present in the DB");
        }

        private async Task<bool> IsKeyPresentInDB(int id)
        {
            return _inMemoryDB.ContainsKey(id);
        }
    }
}