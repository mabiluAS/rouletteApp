using System.Data;
using System.Threading.Tasks;
using System.Threading;

namespace rouletteApp.Data
{
    public interface IApplicationWriteDbConnection : IApplicationReadDbConnection
    {
        Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);
    }
}
