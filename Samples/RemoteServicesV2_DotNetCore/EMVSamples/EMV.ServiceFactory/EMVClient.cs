using EMV.Dtos;
using Magensa.EMV.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public (GetEMVCommandsResponseDto Response, RawSoapDetails SoapDetails) GetEMVCommands(GetEMVCommandsRequestDto dto)
        {
            (GetEMVCommandsResponseDto Response, RawSoapDetails SoapDetails) result = (default, default);
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
                var requestInterceptorBehavior = new EMVInspectorBehavior();
                //developer comments: The default behaviour of the soap message 
                //encodes the cdata tags . The encoded values will be sent to soap service and the soap request fails
                //therefore replacing the encoded tags
                requestInterceptorBehavior.ModifyTags = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("&lt;","<"),
                    new KeyValuePair<string, string>("&gt;", ">")
                };
                svcClient.Endpoint.EndpointBehaviors.Add(requestInterceptorBehavior);
                var soapResponse = svcClient.GetEMVCommandsAsync(soapRequest).Result;

                response.AdditionalOutputData = soapResponse.AdditionalOutputData;
                response.Commands = new List<Dtos.Command>();
                soapResponse.Commands.ToList().ForEach(cmd => response.Commands.Add(new Dtos.Command()
                {
                    CommandType = cmd.CommandType,
                    Description = cmd.Description,
                    ID = cmd.ID,
                    Name = cmd.Name,
                    Value = cmd.Value,
                    ExecutionTypeEnum = cmd.ExecutionTypeEnum
                }));
                response.CustomerTransactionId = soapResponse.CustomerTransactionId;
                response.MagTranId = soapResponse.MagTranId;
                response.PostloadCommands = new List<Dtos.Command>();
                soapResponse.PostloadCommands.ToList().ForEach(cmd => response.Commands.Add(new Dtos.Command()
                {
                    CommandType = cmd.CommandType,
                    Description = cmd.Description,
                    ID = cmd.ID,
                    Name = cmd.Name,
                    Value = cmd.Value,
                    ExecutionTypeEnum = cmd.ExecutionTypeEnum
                }));
                response.PreloadCommands = new List<Dtos.Command>();
                soapResponse.PreloadCommands.ToList().ForEach(cmd => response.Commands.Add(new Dtos.Command()
                {
                    CommandType = cmd.CommandType,
                    Description = cmd.Description,
                    ID = cmd.ID,
                    Name = cmd.Name,
                    Value = cmd.Value,
                    ExecutionTypeEnum = cmd.ExecutionTypeEnum
                }));

                result.SoapDetails = new RawSoapDetails
                {
                    RequestXml = requestInterceptorBehavior.LastRequestXML,
                    ResponseXml = requestInterceptorBehavior.LastResponseXML
                };
                result.Response = response;

            }
            catch (Exception ex) when (ex is CommunicationException || ex is ProtocolException || ex is FaultException || ex is Exception)
            {
                throw ex;
            }
            return result;
        }
    }
}
