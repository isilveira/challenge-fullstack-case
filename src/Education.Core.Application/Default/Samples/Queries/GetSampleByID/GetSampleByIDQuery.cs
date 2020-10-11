using Education.Core.Domain.Entities.Default;

namespace Education.Core.Application.Default.Samples.Queries.GetSampleByID
{
    public class GetSampleByIDQuery : ApplicationRequest<Sample, GetSampleByIDQueryResponse>
    {
        public GetSampleByIDQuery()
        {
            ConfigKeys(x => x.SampleID);
            
            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);  
        }
    }
}
