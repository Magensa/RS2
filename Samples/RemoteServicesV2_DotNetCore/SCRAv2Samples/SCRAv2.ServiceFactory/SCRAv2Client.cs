using Magensa.SCRAv2.Services;
using Microsoft.Extensions.Configuration;
using SCRAv2.Dtos;
using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace SCRAv2.ServiceFactory
{
    public class SCRAv2Client : ISCRAv2Client
    {
        private readonly IConfiguration _config;
        public Uri Host { get; private set; }
        public SCRAv2Client(IConfiguration config)
        {
            _config = config;
            Host = new Uri(_config.GetValue<string>(Constants.SCRAV2SERVICEURL));
        }
        public async Task<GetCommandByKSNResponseDto> GetCommandByKSN(GetCommandByKSNRequestDto dto)
        {
            var responseDto = new GetCommandByKSNResponseDto();

            try
            {
                var soapRequest = new GetCommandByKSNRequest
                {
                    Authentication = new Authentication()
                    {
                        CustomerCode = dto.CustomerCode,
                        Username = dto.Username,
                        Password = dto.Password
                    },
                    BillingLabel = dto.BillingLabel,
                    CustomerTransactionID = dto.CustomerTransactionId,
                    KSN = dto.KSN,
                    KeyID = dto.KeyID,
                    CommandID = dto.CommandID
                };
                var svcClient = new Magensa.SCRAv2.Services.SCRAv2Client();
                var requestInterceptor = new SCRAv2InspectorBehavior();
                svcClient.Endpoint.EndpointBehaviors.Add(requestInterceptor);
                _ = await svcClient.GetCommandByKSNAsync(soapRequest);
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
        public async Task<GetCommandByMUTResponseDto> GetCommandByMUT(GetCommandByMUTRequestDto dto)
        {
            var responseDto = new GetCommandByMUTResponseDto();
            try
            {
                var soapRequest = new GetCommandByMUTRequest
                {
                    Authentication = new Authentication()
                    {
                        CustomerCode = dto.CustomerCode,
                        Username = dto.Username,
                        Password = dto.Password
                    },
                    BillingLabel = dto.BillingLabel,
                    CommandID = dto.CommandID,
                    CustomerTransactionID = dto.CustomerTransactionId,
                    KSN = dto.KSN,
                    UpdateToken = dto.UpdateToken
                };
                var svcClient = new Magensa.SCRAv2.Services.SCRAv2Client();
                var requestInterceptor = new SCRAv2InspectorBehavior();
                svcClient.Endpoint.EndpointBehaviors.Add(requestInterceptor);
                _ = await svcClient.GetCommandByMUTAsync(soapRequest);
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
        public async Task<GetCommandListResponseDto> GetCommandList(GetCommandListRequestDto dto)
        {
            var responseDto = new GetCommandListResponseDto();
            try
            {
                var soapRequest = new GetCommandListRequest
                {
                    Authentication = new Authentication()
                    {
                        CustomerCode = dto.CustomerCode,
                        Username = dto.Username,
                        Password = dto.Password
                    },
                    BillingLabel = dto.BillingLabel,
                    CustomerTransactionID = dto.CustomerTransactionId,
                    ExecutionType = dto.ExecutionType
                };
                var svcClient = new Magensa.SCRAv2.Services.SCRAv2Client();
                var requestInterceptor = new SCRAv2InspectorBehavior();
                svcClient.Endpoint.EndpointBehaviors.Add(requestInterceptor);
                _ = await svcClient.GetCommandListAsync(soapRequest);
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
        public async Task<GetFirmwareByMUTResponseDto> GetFirmwareByMUT(GetFirmwareByMUTRequestDto dto)
        {
            var responseDto = new GetFirmwareByMUTResponseDto();
            try
            {
                var soapRequest = new GetFirmwareByMUTRequest
                {
                    Authentication = new Authentication()
                    {
                        CustomerCode = dto.CustomerCode,
                        Username = dto.Username,
                        Password = dto.Password
                    },
                    BillingLabel = dto.BillingLabel,
                    CustomerTransactionID = dto.CustomerTransactionId,
                    FirmwareID = dto.FirmwareID,
                    KSN = dto.KSN,
                    UpdateToken = dto.UpdateToken
                };
                var svcClient = new Magensa.SCRAv2.Services.SCRAv2Client();
                var requestInterceptor = new SCRAv2InspectorBehavior();
                svcClient.Endpoint.EndpointBehaviors.Add(requestInterceptor);
                _ = await svcClient.GetFirmwareByMUTAsync(soapRequest);
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
        public async Task<GetFirmwareCommandsResponseDto> GetFirmwareCommands(GetFirmwareCommandsRequestDto dto)
        {
            var responseDto = new GetFirmwareCommandsResponseDto();
            try
            {
                var soapRequest = new GetFirmwareCommandsRequest
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
                    Firmware= System.Text.Encoding.UTF8.GetBytes(dto.Firmware),                     
                    KSN = dto.KSN,
                    KeyID = dto.KeyID,
                    SerialNumber = dto.SerialNumber
                };
                var svcClient = new Magensa.SCRAv2.Services.SCRAv2Client();
                var requestInterceptor = new SCRAv2InspectorBehavior();
                svcClient.Endpoint.EndpointBehaviors.Add(requestInterceptor);
                _ = await svcClient.GetFirmwareCommandsAsync(soapRequest);
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
        public async Task<GetFirmwareListResponseDto> GetFirmwareList(GetFirmwareListRequestDto dto)
        {
            var responseDto = new GetFirmwareListResponseDto();
            try
            {
                var soapRequest = new GetFirmwareListRequest
                {
                    Authentication = new Authentication()
                    {
                        CustomerCode = dto.CustomerCode,
                        Username = dto.Username,
                        Password = dto.Password
                    },
                    BillingLabel = dto.BillingLabel,
                    CustomerTransactionID = dto.CustomerTransactionId,
                    FirmwareType = dto.FirmwareType
                };
                var svcClient = new Magensa.SCRAv2.Services.SCRAv2Client();
                var requestInterceptor = new SCRAv2InspectorBehavior();
                svcClient.Endpoint.EndpointBehaviors.Add(requestInterceptor);
                _ = await svcClient.GetFirmwareListAsync(soapRequest);
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
                GetKeyListRequest soapRequest = new GetKeyListRequest
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
                var svcClient = new Magensa.SCRAv2.Services.SCRAv2Client();
                var requestInterceptor = new SCRAv2InspectorBehavior();
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
                GetKeyLoadCommandRequest soapRequest = new GetKeyLoadCommandRequest
                {
                    Authentication = new Authentication()
                    {
                        CustomerCode = dto.CustomerCode,
                        Username = dto.Username,
                        Password = dto.Password
                    },
                    BillingLabel = dto.BillingLabel,
                    CustomerTransactionID = dto.CustomerTransactionId,
                    KeyID = dto.KeyID,
                    KSN = dto.KSN,
                    UpdateToken = dto.UpdateToken
                };
                var svcClient = new Magensa.SCRAv2.Services.SCRAv2Client();
                var requestInterceptor = new SCRAv2InspectorBehavior();
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
    }
}
