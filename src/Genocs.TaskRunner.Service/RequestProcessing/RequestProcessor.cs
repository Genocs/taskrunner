using Genocs.TaskRunner.Messages.Messages;
using Genocs.TaskRunner.Service.ExternalServices;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Genocs.TaskRunner.Service.RequestProcessing
{
    public class RequestProcessor : IRequestProcessor
    {
        private readonly ILogger<RequestProcessor> _logger;
        private readonly IValidationServiceCaller _validationServiceCaller;

        public RequestProcessor(
            ILogger<RequestProcessor> logger,
            IValidationServiceCaller validationServiceCaller)
        {
            _logger = logger;
            _validationServiceCaller = validationServiceCaller;
        }

        public async Task<bool> ProcessSimpleMessageAsync(SimpleMessage message, IReadOnlyDictionary<string, object> properties)
        {
            _logger.LogInformation("Processing Simple Message {MessageId}", message.MessageId);

            try
            {
                var requestStatus = await _validationServiceCaller.ChangeTransactionStatusAsync(message, null);
                if (requestStatus != null)
                {
                    _logger.LogInformation("Completed change transaction status request {MessageId}", message.MessageId);
                    return true;
                }
                else
                {
                    _logger.LogError("Failed process Simple Message status for request {MessageId}", message.MessageId);
                }

            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error processing Simple Message {MessageId}", message.MessageId);
            }

            return false;
        }
    }
}
