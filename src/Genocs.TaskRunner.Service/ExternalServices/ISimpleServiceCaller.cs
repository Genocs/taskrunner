using Genocs.TaskRunner.Service.Models;
using System.Threading.Tasks;

namespace Genocs.TaskRunner.Service.ExternalServices
{
    public interface ISimpleServiceCaller
    {
       Task<SimpleResult> GetSimpleModelAsync(string id);
    }
}
