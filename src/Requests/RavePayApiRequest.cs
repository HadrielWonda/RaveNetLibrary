using System.Net.Http;
using System.Net.Http.Headers;
using RaveNetLibrary.Payments;

namespace RaveNetLibrary;

    internal class RavePayApiRequest : RavePayApiRequestBase<RaveApiResponse<PayResponseData>, PayResponseData>
    {
       
    }

    internal class RavePayApiRequest<T1, T2> : RavePayApiRequestBase<T1, T2> where T1 : RaveApiResponse<T2>, new() where T2 : class
    {
        internal RavePayApiRequest():base()
        {
            Config = new RavePayConfig(false);
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        internal RavePayApiRequest(RavePayConfig config): base(config)
        {
            Config = config;
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

       
    }

