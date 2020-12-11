using System;

namespace Genocs.TaskRunner.ExternalWeb.Models
{
    public class ChangeStatusSchedule
    {
        public string TransactionId { get; set; }
        public string CountryId { get; set; }
        public string CustomsOfficeCode { get; set; }

        public string CustomsStatus { get; set; }
        public string CustomsDateEvent { get; set; }
    }
}
