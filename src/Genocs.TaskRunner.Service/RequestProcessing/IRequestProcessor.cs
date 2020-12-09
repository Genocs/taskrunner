using Genocs.TaskRunner.Messages.Messages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Genocs.TaskRunner.Service.RequestProcessing
{
    public interface IRequestProcessor
    {
        Task<bool> ProcessSimpleMessageAsync(SimpleMessage message, IReadOnlyDictionary<string, object> properties);
    }
}
