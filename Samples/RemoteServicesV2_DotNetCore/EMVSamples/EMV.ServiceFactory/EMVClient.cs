using EMV.Dtos;
using Magensa.EMV.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.ServiceModel;

namespace EMV.ServiceFactory
{
    public class EMVClient : IEMVClient
    {
        private readonly IConfiguration _config;
        public Uri ServiceUrl { get; private set; }
       

        public EMVClient(IConfiguration config)
        {
            _config = config;
            ServiceUrl = new Uri(_config.GetValue<string>(Constants.EMVSERVICEURL));
        }

        public GetEMVCommandsResponseDto GetEMVCommands(GetEMVCommandsRequestDto dto)
        {
            var response = new GetEMVCommandsResponseDto();

            try
            {
                var soapRequest = new GetEMVCommandsRequest
                {
                    Authentication = new Authentication()
                    {
                        CustomerCode = dto.CustomerCode,
                        Username = dto.Username,
                        Password = dto.Password
                    },
                    BillingLabel = dto.BillingLabel,
                    CustomerTransactionID = dto.CustomerTransactionId,
                    AdditionalRequestData = dto.AdditionalRequestData.ToArray(),
                    DeviceType = dto.DeviceType,
                    EMVCommandType = dto.EMVCommandType,
                    KSN = dto.KSN,
                    KeyName = dto.KeyName,
                    SerialNumber = dto.SerialNumber,
                    XMLString = dto.XMLString
                };

                var svcEndPointAddress = new EndpointAddress(ServiceUrl.ToString());
                var svcEndPointConfig = Magensa.EMV.Services.EMVClient.EndpointConfiguration.BasicHttpsBinding_IEMV;
                var svcClient = new Magensa.EMV.Services.EMVClient(svcEndPointConfig, svcEndPointAddress);
                var requestInterceptor = new EMVInspectorBehavior();
                svcClient.Endpoint.EndpointBehaviors.Add(requestInterceptor);
                _ = svcClient.GetEMVCommandsAsync(soapRequest).Result;
                _ = requestInterceptor.LastRequestXML;
                string responseXML = requestInterceptor.LastResponseXML;
                response.PageContent = responseXML;
            }
            catch (Exception ex) when (ex is CommunicationException || ex is ProtocolException || ex is FaultException || ex is Exception)
            {
                throw ex;
            }
            return response;
        }
    }
}
