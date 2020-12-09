using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Genocs.TaskRunner.Service.Exceptions;
using Genocs.TaskRunner.Service.Models;
using Genocs.TaskRunner.Messages.Messages;

namespace Genocs.TaskRunner.Service.ExternalServices
{
    public class ValidationServiceCaller : IValidationServiceCaller
    {
        private readonly HttpClient _httpClient;

        public ValidationServiceCaller(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ChangeStatusSchedule> ChangeTransactionStatusAsync(SimpleMessage transactionRequest, string transactionId)
        {
            try
            {
                var request = CreateChangeStatusSchedule(transactionRequest, transactionId);

                //var response = await _httpClient.PostAsJsonAsync($"weatherforecast/{transactionRequest.TransactionId}/updatetransactionrequests", request);
                
                var content = PackageContent(transactionRequest);
                var response = await _httpClient.PostAsync($"UTU.TaxFree.Host.Validation/transactionsdigitalelaboratedcommand", content);


                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<ChangeStatusSchedule>();
                }

                throw new BackendServiceCallFailedException(response.ReasonPhrase);
            }
            catch (BackendServiceCallFailedException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new BackendServiceCallFailedException(e.Message, e);
            }
        }

        private ChangeStatusSchedule CreateChangeStatusSchedule(SimpleMessage simpleMessage, string transactionId)
        {
            // Fake data 
            ChangeStatusSchedule scheduleChangeStatus = new ChangeStatusSchedule
            {
                TransactionId = transactionId,
                CountryId = simpleMessage.MessageBody,
                CustomsStatus = "TODO",
                CustomsDateEvent = DateTime.UtcNow.ToString("yyyy-MM-dd")
            };

            return scheduleChangeStatus;
        }

        private HttpContent PackageContent<T>(T transactionRequest) where T : class
        {
            var content = new StringContent(JsonConvert.SerializeObject(transactionRequest));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            return content;
        }
    }
}
