using System.Collections.Generic;
using Vue.WebApi.Models;

namespace Vue.WebApi.Contracts
{
    public interface ISampleDataService
    {
        IEnumerable<SampleCompany> GetSampleCompanies();
    }
}
