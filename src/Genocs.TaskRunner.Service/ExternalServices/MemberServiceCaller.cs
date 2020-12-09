using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Genocs.TaskRunner.Service.Models;

namespace Genocs.TaskRunner.Service.ExternalServices
{
    public class MemberServiceCaller : IMemberServiceCaller
    {
        private readonly HttpClient _httpClient;

        public MemberServiceCaller(HttpClient httpClient)
        {
            _httpClient = httpClient;
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
