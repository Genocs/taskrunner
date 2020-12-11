using Genocs.TaskRunner.Service.Models;
using System.Threading.Tasks;

namespace Genocs.TaskRunner.Service.ExternalServices
{
    public interface ISimpleAuthServiceCaller
    {
        Task<SimpleResult> GetSimpleAuthModelAsync(string id);
    }
}
