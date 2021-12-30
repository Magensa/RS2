using Magensa.PPSCRAv2.Services;
using Microsoft.Extensions.Configuration;
using PPSCRAv2.Dtos;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.ServiceModel;

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

        public (GetCertLoadCommandResponseDto Response, RawSoapDetails SoapDetails) GetCertLoadCommand(GetCertLoadCommandRequestDto dto)
        {
            (GetCertLoadCommandResponseDto Response, RawSoapDetails SoapDetails) result = (default, default);
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
                var soapResponse = svcClient.GetCertLoadCommandAsync(soapRequest).Result;
                
                responseDto.AdditionalOutputData = soapResponse.AdditionalOutputData;
                var cmd = new Dtos.Command()
                {
                    CommandType = soapResponse.Command.CommandType,
                    Description = soapResponse.Command.Description,
                    ID = soapResponse.Command.ID,
                    Name = soapResponse.Command.Name,
                    Value = soapResponse.Command.Value,
                    ExecutionTypeEnum = soapResponse.Command.ExecutionTypeEnum
                };
                responseDto.Command = cmd;
                responseDto.CustomerTransactionId = soapResponse.CustomerTransactionId;
                responseDto.MagTranId = soapResponse.MagTranId;

                result.SoapDetails = new RawSoapDetails
                {
                    RequestXml = requestInterceptor.LastRequestXML,
                    ResponseXml = requestInterceptor.LastResponseXML
                };
                result.Response = responseDto;
            }
            catch (Exception ex) when (ex is CommunicationException || ex is ProtocolException || ex is FaultException || ex is Exception)
            {
                throw ex;
            }
            return result;
        }
        public (GetCommandListByDeviceResponseDto Response, RawSoapDetails SoapDetails) GetCommandListByDevice(GetCommandListByDeviceRequestDto dto)
        {
            (GetCommandListByDeviceResponseDto Response, RawSoapDetails SoapDetails) result = (default, default);
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
                var soapResponse = svcClient.GetCommandListByDeviceAsync(soapRequest).Result;
                responseDto.AdditionalOutputData = soapResponse.AdditionalOutputData;
                responseDto.Commands = new List<Dtos.Command>();
                soapResponse.Commands.ToList().ForEach(cmd => responseDto.Commands.Add(new Dtos.Command()
                {
                    CommandType = cmd.CommandType,
                    Description = cmd.Description,
                    ID = cmd.ID,
                    Name = cmd.Name,
                    Value = cmd.Value,
                    ExecutionTypeEnum = cmd.ExecutionTypeEnum
                }));
                responseDto.CustomerTransactionId = soapResponse.CustomerTransactionId;
                responseDto.MagTranId = soapResponse.MagTranId;

                result.SoapDetails = new RawSoapDetails
                {
                    RequestXml = requestInterceptor.LastRequestXML,
                    ResponseXml = requestInterceptor.LastResponseXML
                };
                result.Response = responseDto;
            }
            catch (Exception ex) when (ex is CommunicationException || ex is ProtocolException || ex is FaultException || ex is Exception)
            {
                throw ex;
            }
            return result;
        }
        public (GetDeviceAuthCommandResponseDto Response, RawSoapDetails SoapDetails) GetDeviceAuthCommand(GetDeviceAuthCommandRequestDto dto)
        {
            (GetDeviceAuthCommandResponseDto Response, RawSoapDetails SoapDetails) result = (default, default);
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
                var soapResponse = svcClient.GetDeviceAuthCommandAsync(soapRequest).Result;
                responseDto.AdditionalOutputData = soapResponse.AdditionalOutputData;
                var cmd = new Dtos.Command()
                {
                    CommandType = soapResponse.Command.CommandType,
                    Description = soapResponse.Command.Description,
                    ID = soapResponse.Command.ID,
                    Name = soapResponse.Command.Name,
                    Value = soapResponse.Command.Value,
                    ExecutionTypeEnum = soapResponse.Command.ExecutionTypeEnum
                };
                responseDto.Command = cmd;
                responseDto.CustomerTransactionId = soapResponse.CustomerTransactionId;
                responseDto.MagTranId = soapResponse.MagTranId;
                responseDto.KCV = soapResponse.KCV;
                responseDto.KeyType = soapResponse.KeyType;

                result.SoapDetails = new RawSoapDetails
                {
                    RequestXml = requestInterceptor.LastRequestXML,
                    ResponseXml = requestInterceptor.LastResponseXML
                };
                result.Response = responseDto;
            }
            catch (Exception ex) when (ex is CommunicationException || ex is ProtocolException || ex is FaultException || ex is Exception)
            {
                throw ex;
            }
            return result;
        }
        public (GetEnableSREDCommandResponseDto Response, RawSoapDetails SoapDetails) GetEnableSREDCommand(GetEnableSREDCommandRequestDto dto)
        {
            (GetEnableSREDCommandResponseDto Response, RawSoapDetails SoapDetails) result = (default, default);
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
                var soapResponse = svcClient.GetEnableSREDCommandAsync(soapRequest).Result;
                responseDto.AdditionalOutputData = soapResponse.AdditionalOutputData;
                var cmd = new Dtos.Command()
                {
                    CommandType = soapResponse.Command.CommandType,
                    Description = soapResponse.Command.Description,
                    ID = soapResponse.Command.ID,
                    Name = soapResponse.Command.Name,
                    Value = soapResponse.Command.Value,
                    ExecutionTypeEnum = soapResponse.Command.ExecutionTypeEnum
                };
                responseDto.Command = cmd;
                responseDto.CustomerTransactionId = soapResponse.CustomerTransactionId;
                responseDto.MagTranId = soapResponse.MagTranId;

                result.SoapDetails = new RawSoapDetails
                {
                    RequestXml = requestInterceptor.LastRequestXML,
                    ResponseXml = requestInterceptor.LastResponseXML
                };
                result.Response = responseDto;
            }
            catch (Exception ex) when (ex is CommunicationException || ex is ProtocolException || ex is FaultException || ex is Exception)
            {
                throw ex;
            }
            return result;
        }
        public (GetKeyListResponseDto Response, RawSoapDetails SoapDetails) GetKeyList(GetKeyListRequestDto dto)
        {
            (GetKeyListResponseDto Response, RawSoapDetails SoapDetails) result = (default, default);
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
                var soapResponse = svcClient.GetKeyListAsync(soapRequest).Result;
                responseDto.PPScraKeys = new List<Dtos.PPSCRAKey>();
                soapResponse.Keys.ToList().ForEach(pkey => responseDto.PPScraKeys.Add(new Dtos.PPSCRAKey()
                {
                    Description = pkey.Description,
                    ID = pkey.ID,
                    KeyName = pkey.KeyName,
                    KSI = pkey.KSI,
                    KeySlotNamePrefix = pkey.KeySlotNamePrefix

                }));
                responseDto.CustomerTransactionId = soapResponse.CustomerTransactionId;
                responseDto.MagTranId = soapResponse.MagTranId;


                result.SoapDetails = new RawSoapDetails
                {
                    RequestXml = requestInterceptor.LastRequestXML,
                    ResponseXml = requestInterceptor.LastResponseXML
                };
                result.Response = responseDto;
            }
            catch (Exception ex) when (ex is CommunicationException || ex is ProtocolException || ex is FaultException || ex is Exception)
            {
                throw ex;
            }
            return result;
        }
        public (GetKeyLoadCommandResponseDto Response, RawSoapDetails SoapDetails) GetKeyLoadCommand(GetKeyLoadCommandRequestDto dto)
        {
            (GetKeyLoadCommandResponseDto Response, RawSoapDetails SoapDetails) result = (default, default);
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
                var soapResponse = svcClient.GetKeyLoadCommandAsync(soapRequest).Result;
                responseDto.AdditionalOutputData = soapResponse.AdditionalOutputData;
                var cmd = new Dtos.Command()
                {
                    CommandType = soapResponse.Command.CommandType,
                    Description = soapResponse.Command.Description,
                    ID = soapResponse.Command.ID,
                    Name = soapResponse.Command.Name,
                    Value = soapResponse.Command.Value,
                    ExecutionTypeEnum = soapResponse.Command.ExecutionTypeEnum
                };
                responseDto.Command = cmd;
                responseDto.CustomerTransactionId = soapResponse.CustomerTransactionId;
                responseDto.MagTranId = soapResponse.MagTranId;
                responseDto.BaseKCV = soapResponse.BaseKCV;
                responseDto.DukptKCV = soapResponse.DukptKCV;
                responseDto.KeyPrefix = soapResponse.KeyPrefix;
                responseDto.KeyType = soapResponse.KeyType;

                result.SoapDetails = new RawSoapDetails
                {
                    RequestXml = requestInterceptor.LastRequestXML,
                    ResponseXml = requestInterceptor.LastResponseXML
                };
                result.Response = responseDto;
            }
            catch (Exception ex) when (ex is CommunicationException || ex is ProtocolException || ex is FaultException || ex is Exception)
            {
                throw ex;
            }
            return result;
        }
        public (GetLoadConfigCommandResponseDto Response, RawSoapDetails SoapDetails) GetLoadConfigCommand(GetLoadConfigCommandRequestDto dto)
        {
            (GetLoadConfigCommandResponseDto Response, RawSoapDetails SoapDetails) result = (default, default);
            
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
                var soapResponse = svcClient.GetLoadConfigCommandAsync(soapRequest).Result;
                var responseDto = new GetLoadConfigCommandResponseDto();
                responseDto.AdditionalOutputData = soapResponse.AdditionalOutputData;
                var cmd = new Dtos.Command()
                {
                    CommandType = soapResponse.Command.CommandType,
                    Description = soapResponse.Command.Description,
                    ID = soapResponse.Command.ID,
                    Name = soapResponse.Command.Name,
                    Value = soapResponse.Command.Value,
                    ExecutionTypeEnum = soapResponse.Command.ExecutionTypeEnum
                };
                responseDto.Command = cmd;
                responseDto.CustomerTransactionId = soapResponse.CustomerTransactionId;
                responseDto.MagTranId = soapResponse.MagTranId;
                responseDto.TargetConfig = soapResponse.TargetConfig;
                result.SoapDetails = new RawSoapDetails
                {
                    RequestXml = requestInterceptor.LastRequestXML,
                    ResponseXml = requestInterceptor.LastResponseXML
                };
                result.Response = responseDto;
            }
            catch (Exception ex) when (ex is CommunicationException || ex is ProtocolException || ex is FaultException || ex is Exception)
            {
                throw ex;
            }
            return result;
        }
        public (GetPreActivateCommandResponseDto Response, RawSoapDetails SoapDetails) GetPreActivateCommand(GetPreActivateCommandRequestDto dto)
        {
            (GetPreActivateCommandResponseDto Response, RawSoapDetails SoapDetails) result = (default, default);
            
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
                var soapResponse = svcClient.GetPreActivateCommandAsync(soapRequest).Result;
                var responseDto = new GetPreActivateCommandResponseDto();
                responseDto.AdditionalOutputData = soapResponse.AdditionalOutputData;
                var cmd = new Dtos.Command()
                {
                    CommandType = soapResponse.Command.CommandType,
                    Description = soapResponse.Command.Description,
                    ID = soapResponse.Command.ID,
                    Name = soapResponse.Command.Name,
                    Value = soapResponse.Command.Value,
                    ExecutionTypeEnum = soapResponse.Command.ExecutionTypeEnum
                };
                responseDto.Command = cmd;
                responseDto.CustomerTransactionId = soapResponse.CustomerTransactionId;
                responseDto.MagTranId = soapResponse.MagTranId;
                result.SoapDetails = new RawSoapDetails
                {
                    RequestXml = requestInterceptor.LastRequestXML,
                    ResponseXml = requestInterceptor.LastResponseXML
                };
                result.Response = responseDto;
            }
            catch (Exception ex) when (ex is CommunicationException || ex is ProtocolException || ex is FaultException || ex is Exception)
            {
                throw ex;
            }
            return result;
        }
    }
}
