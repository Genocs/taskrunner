using Genocs.TaskRunner.Messages.Messages;
using Genocs.TaskRunner.Service.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Genocs.TaskRunner.Service.ExternalServices
{
    public class SimpleAuthServiceCaller : ISimpleAuthServiceCaller
    {
        private readonly HttpClient _httpClient;

        public SimpleAuthServiceCaller(HttpClient httpClient)
            => _httpClient = httpClient;

        public Task<ChangeStatusSchedule> ChangeTransactionStatusAsync(SimpleMessage simpleMessage, string transactionId)
        {
            throw new NotImplementedException();
        }

        //public async Task<PackageGen> UpsertPackageAsync(PackageInfo packageInfo)
        //{
        //    try
        //    {
        //        var response = await _httpClient.PutAsJsonAsync($"{packageInfo.PackageId}", packageInfo);
        //        if (response.StatusCode == HttpStatusCode.Created)
        //        {
        //            return await response.Content.ReadAsAsync<PackageGen>();
        //        }
        //        else if (response.StatusCode == HttpStatusCode.NoContent)
        //        {
        //            return  await this.GetPackageAsync(packageInfo.PackageId);
        //        }

        //        throw new BackendServiceCallFailedException(response.ReasonPhrase);
        //    }
        //    catch (BackendServiceCallFailedException)
        //    {
        //        throw;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new BackendServiceCallFailedException(e.Message, e);
        //    }
        //}

        //private async Task<PackageGen> GetPackageAsync(string packageId)
        //{
        //    try
        //    {
        //        var response = await _httpClient.GetAsync($"{packageId}");
        //        if (response.StatusCode == HttpStatusCode.OK)
        //        {
        //            return await response.Content.ReadAsAsync<PackageGen>();
        //        }

        //        throw new BackendServiceCallFailedException(response.ReasonPhrase);
        //    }
        //    catch (BackendServiceCallFailedException)
        //    {
        //        throw;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new BackendServiceCallFailedException(e.Message, e);
        //    }
        //}
    }
}
