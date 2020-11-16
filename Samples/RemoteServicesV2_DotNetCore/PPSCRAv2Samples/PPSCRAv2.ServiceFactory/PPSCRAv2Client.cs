using Magensa.PPSCRAv2.Services;
using Microsoft.Extensions.Configuration;
using PPSCRAv2.Dtos;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace PPSCRAv2.ServiceFactory
{
    public class PPSCRAv2Client : IPPSCRAv2Client
    {
        private readonly IConfiguration _config;
        public Uri Host { get; private set; }
        public PPSCRAv2Client(IConfiguration config)
        {
            _config = config;
            Host = new Uri(_config.GetValue<string>(Constants.SERVICEURL));
        }

        public async Task<GetCertLoadCommandResponseDto> GetCertLoadCommand(GetCertLoadCommandRequestDto dto)
        {
            var responseDto = new GetCertLoadCommandResponseDto();
            try
            {
                var soapRequest = new GetCertLoadCommandRequest
                {
                    Authentication = new Authentication()
                    {
                        CustomerCode = dto.CustomerCode,
                        Username = dto.Username,
                        Password = dto.Password
                    },
                    BillingLabel = dto.BillingLabel,
                    CustomerTransactionID = dto.CustomerTransactionId,
                    Challenge = dto.Challenge,
                    KSN = dto.KSN,
                    DeviceType = dto.DeviceType,
                    KeyType = dto.KeyType,
                    AdditionalRequestData = dto.AdditionalRequestData.ToArray()
                };
                var svcClient = new Magensa.PPSCRAv2.Services.PPSCRAv2Client();
                var requestInterceptor = new PPSCRAv2InspectorBehavior();
                svcClient.Endpoint.EndpointBehaviors.Add(requestInterceptor);
                _ = await svcClient.GetCertLoadCommandAsync(soapRequest);
                _ = requestInterceptor.LastRequestXML;
                string responseXML = requestInterceptor.LastResponseXML;
                responseDto.PageContent = responseXML;
            }
            catch (Exception ex) when (ex is CommunicationException || ex is ProtocolException || ex is FaultException || ex is Exception)
            {
                throw ex;
            }
            return responseDto;
        }
        public async Task<GetCommandListByDeviceResponseDto> GetCommandListByDevice(GetCommandListByDeviceRequestDto dto)
        {
            var responseDto = new GetCommandListByDeviceResponseDto();
            try
            {
                var soapRequest = new GetCommandListByDeviceRequest
                {
                    Authentication = new Authentication()
                    {
                        CustomerCode = dto.CustomerCode,
                        Username = dto.Username,
                        Password = dto.Password
                    },
                    BillingLabel = dto.BillingLabel,
                    CustomerTransactionID = dto.CustomerTransactionId,
                    DeviceType = dto.DeviceType,
                    AdditionalRequestData = dto.AdditionalRequestData.ToArray()
                };
                var svcClient = new Magensa.PPSCRAv2.Services.PPSCRAv2Client();
                var requestInterceptor = new PPSCRAv2InspectorBehavior();
                svcClient.Endpoint.EndpointBehaviors.Add(requestInterceptor);
                _ = await svcClient.GetCommandListByDeviceAsync(soapRequest);
                _ = requestInterceptor.LastRequestXML;
                string responseXML = requestInterceptor.LastResponseXML;
                responseDto.PageContent = responseXML;
            }
            catch (Exception ex) when (ex is CommunicationException || ex is ProtocolException || ex is FaultException || ex is Exception)
            {
                throw ex;
            }
            return responseDto;
        }
        public async Task<GetDeviceAuthCommandResponseDto> GetDeviceAuthCommand(GetDeviceAuthCommandRequestDto dto)
        {
            var responseDto = new GetDeviceAuthCommandResponseDto();
            try
            {
                var soapRequest = new GetDeviceAuthCommandRequest
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
                    DeviceCert = dto.DeviceCert,
                    Challenge = dto.Challenge,
                    KeyType = dto.KeyType
                };
                var svcClient = new Magensa.PPSCRAv2.Services.PPSCRAv2Client();
                var requestInterceptor = new PPSCRAv2InspectorBehavior();
                svcClient.Endpoint.EndpointBehaviors.Add(requestInterceptor);
                _ = await svcClient.GetDeviceAuthCommandAsync(soapRequest);
                _ = requestInterceptor.LastRequestXML;
                string responseXML = requestInterceptor.LastResponseXML;
                responseDto.PageContent = responseXML;
            }
            catch (Exception ex) when (ex is CommunicationException || ex is ProtocolException || ex is FaultException || ex is Exception)
            {
                throw ex;
            }
            return responseDto;
        }
        public async Task<GetEnableSREDCommandResponseDto> GetEnableSREDCommand(GetEnableSREDCommandRequestDto dto)
        {
            var responseDto = new GetEnableSREDCommandResponseDto();
            try
            {
                var soapRequest = new GetEnableSREDCommandRequest
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
                    Challenge = dto.Challenge,
                    DeviceType = dto.DeviceType,
                    KSN = dto.KSN,
                    WhiteListType = dto.WhiteListType
                };
                var svcClient = new Magensa.PPSCRAv2.Services.PPSCRAv2Client();
                var requestInterceptor = new PPSCRAv2InspectorBehavior();
                svcClient.Endpoint.EndpointBehaviors.Add(requestInterceptor);
                _ = await svcClient.GetEnableSREDCommandAsync(soapRequest);
                _ = requestInterceptor.LastRequestXML;
                string responseXML = requestInterceptor.LastResponseXML;
                responseDto.PageContent = responseXML;
            }
            catch (Exception ex) when (ex is CommunicationException || ex is ProtocolException || ex is FaultException || ex is Exception)
            {
                throw ex;
            }
            return responseDto;
        }
        public async Task<GetKeyListResponseDto> GetKeyList(GetKeyListRequestDto dto)
        {
            var responseDto = new GetKeyListResponseDto();
            try
            {
                var soapRequest = new GetKeyListRequest
                {
                    Authentication = new Authentication()
                    {
                        CustomerCode = dto.CustomerCode,
                        Username = dto.Username,
                        Password = dto.Password
                    },
                    BillingLabel = dto.BillingLabel,
                    CustomerTransactionID = dto.CustomerTransactionId
                };
                var svcClient = new Magensa.PPSCRAv2.Services.PPSCRAv2Client();
                var requestInterceptor = new PPSCRAv2InspectorBehavior();
                svcClient.Endpoint.EndpointBehaviors.Add(requestInterceptor);
                _ = await svcClient.GetKeyListAsync(soapRequest);
                _ = requestInterceptor.LastRequestXML;
                string responseXML = requestInterceptor.LastResponseXML;
                responseDto.PageContent = responseXML;
            }
            catch (Exception ex) when (ex is CommunicationException || ex is ProtocolException || ex is FaultException || ex is Exception)
            {
                throw ex;
            }
            return responseDto;
        }
        public async Task<GetKeyLoadCommandResponseDto> GetKeyLoadCommand(GetKeyLoadCommandRequestDto dto)
        {
            var responseDto = new GetKeyLoadCommandResponseDto();
            try
            {
                var soapRequest = new GetPPKeyLoadCommandRequest
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
                    Challenge = dto.Challenge,
                    DeviceCert = dto.DeviceCert,
                    DeviceType = dto.DeviceType,
                    KSN = dto.KSN,
                    KSI = dto.KSI,
                    KeyType = dto.KeyType
                };
                var svcClient = new Magensa.PPSCRAv2.Services.PPSCRAv2Client();
                var requestInterceptor = new PPSCRAv2InspectorBehavior();
                svcClient.Endpoint.EndpointBehaviors.Add(requestInterceptor);
                _ = await svcClient.GetKeyLoadCommandAsync(soapRequest);
                _ = requestInterceptor.LastRequestXML;
                string responseXML = requestInterceptor.LastResponseXML;
                responseDto.PageContent = responseXML;
            }
            catch (Exception ex) when (ex is CommunicationException || ex is ProtocolException || ex is FaultException || ex is Exception)
            {
                throw ex;
            }
            return responseDto;
        }
        public async Task<GetLoadConfigCommandResponseDto> GetLoadConfigCommand(GetLoadConfigCommandRequestDto dto)
        {
            var responseDto = new GetLoadConfigCommandResponseDto();
            try
            {
                var soapRequest = new GetLoadConfigCommandRequest
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
                    Challenge = dto.Challenge,
                    DeviceType = dto.DeviceType
                };
                var deviceConfigCommands = dto.DeviceConfigCommands;
                List<DeviceConfigCommand> configueCommandsArr = new List<DeviceConfigCommand>();
                foreach (var item in deviceConfigCommands)
                {
                    DeviceConfigCommand deviceConfigCommand = new DeviceConfigCommand
                    {
                        CommandId = item.DeviceConfigCommand_CommandId,
                        ConfigData = item.DeviceConfigCommand_ConfigData
                    };
                    configueCommandsArr.Add(deviceConfigCommand);
                }
                soapRequest.ConfigCommands = configueCommandsArr.ToArray();
                soapRequest.ExistingConfig = dto.ExistingConfig;
                soapRequest.KSN = dto.KSN;
                soapRequest.KeyType = dto.KeyType;
                var svcClient = new Magensa.PPSCRAv2.Services.PPSCRAv2Client();
                var requestInterceptor = new PPSCRAv2InspectorBehavior();
                svcClient.Endpoint.EndpointBehaviors.Add(requestInterceptor);
                _ = await svcClient.GetLoadConfigCommandAsync(soapRequest);
                _ = requestInterceptor.LastRequestXML;
                string responseXML = requestInterceptor.LastResponseXML;
                responseDto.PageContent = responseXML;
            }
            catch (Exception ex) when (ex is CommunicationException || ex is ProtocolException || ex is FaultException || ex is Exception)
            {
                throw ex;
            }
            return responseDto;
        }
        public async Task<GetPreActivateCommandResponseDto> GetPreActivateCommand(GetPreActivateCommandRequestDto dto)
        {
            var responseDto = new GetPreActivateCommandResponseDto();
            try
            {
                var soapRequest = new GetPreActivateCommandRequest
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
                    Challenge = dto.Challenge,
                    DeviceType = dto.DeviceType,
                    KSN = dto.KSN,
                    KeyType = dto.KeyType,
                    OrderID = dto.OrderID,
                    TechID = dto.TechID
                };
                var svcClient = new Magensa.PPSCRAv2.Services.PPSCRAv2Client();
                var requestInterceptor = new PPSCRAv2InspectorBehavior();
                svcClient.Endpoint.EndpointBehaviors.Add(requestInterceptor);
                var soapResponse = await svcClient.GetPreActivateCommandAsync(soapRequest);
                _ = requestInterceptor.LastRequestXML;
                string responseXML = requestInterceptor.LastResponseXML;
                responseDto.PageContent = responseXML;
            }
            catch (Exception ex) when (ex is CommunicationException || ex is ProtocolException || ex is FaultException || ex is Exception)
            {
                throw ex;
            }
            return responseDto;
        }
    }
}
