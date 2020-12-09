using System.Threading.Tasks;
using Genocs.TaskRunner.Messages.Messages;
using Genocs.TaskRunner.Service.Models;

namespace Genocs.TaskRunner.Service.ExternalServices
{
    public interface ISimpleServiceCaller
    {
        Task<ChangeStatusSchedule> ChangeTransactionStatusAsync(SimpleMessage simpleMessage, string transactionId);
    }
}
