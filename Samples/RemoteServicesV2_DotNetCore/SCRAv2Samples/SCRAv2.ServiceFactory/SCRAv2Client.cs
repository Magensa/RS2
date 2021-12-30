using Magensa.SCRAv2.Services;
using Microsoft.Extensions.Configuration;
using SCRAv2.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<(GetCommandByKSNResponseDto Response, RawSoapDetails SoapDetails)> GetCommandByKSN(GetCommandByKSNRequestDto dto)
        {
            (GetCommandByKSNResponseDto Response, RawSoapDetails SoapDetails) result = (default, default);

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
                var requestInterceptorBehavior = new SCRAv2InspectorBehavior();
                svcClient.Endpoint.EndpointBehaviors.Add(requestInterceptorBehavior);
                var svcResponse = await svcClient.GetCommandByKSNAsync(soapRequest);
                result.SoapDetails = new RawSoapDetails();
                result.SoapDetails.RequestXml = requestInterceptorBehavior.LastRequestXML;
                result.SoapDetails.ResponseXml = requestInterceptorBehavior.LastResponseXML;

                if (svcResponse != null)
                {
                    result.Response = new GetCommandByKSNResponseDto
                    {
                        CustomerTransactionId = svcResponse.CustomerTransactionId,
                        MagTranId = svcResponse.MagTranId,
                        Command = new Dtos.Command
                        {
                            CommandType = svcResponse.Command.CommandType,
                            Description = svcResponse.Command.Description,
                            ExecutionTypeEnum = svcResponse.Command.ExecutionTypeEnum,
                            ID = svcResponse.Command.ID,
                            Name = svcResponse.Command.Name,
                            Value = svcResponse.Command.Value
                        }
                    };
                }
            }
            catch (Exception ex) when (ex is CommunicationException || ex is ProtocolException || ex is FaultException || ex is Exception)
            {
                throw ex;
            }
            return result;
        }
        public async Task<(GetCommandByMUTResponseDto Response, RawSoapDetails SoapDetails)> GetCommandByMUT(GetCommandByMUTRequestDto dto)
        {
            (GetCommandByMUTResponseDto Response, RawSoapDetails SoapDetails) result = (default, default);
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
                var svcResponse = await svcClient.GetCommandByMUTAsync(soapRequest);
                result.SoapDetails = new RawSoapDetails();
                result.SoapDetails.RequestXml = requestInterceptor.LastRequestXML;
                result.SoapDetails.ResponseXml = requestInterceptor.LastResponseXML;
                if (svcResponse != null)
                {
                    result.Response = new GetCommandByMUTResponseDto()
                    {
                        CustomerTransactionId = svcResponse.CustomerTransactionId,
                        MagTranId = svcResponse.MagTranId,
                        Command = new Dtos.Command
                        {
                            CommandType = svcResponse.Command.CommandType,
                            Description = svcResponse.Command.Description,
                            ExecutionTypeEnum = svcResponse.Command.ExecutionTypeEnum,
                            ID = svcResponse.Command.ID,
                            Name = svcResponse.Command.Name,
                            Value = svcResponse.Command.Value
                        }
                    };
                }
            }
            catch (Exception ex) when (ex is CommunicationException || ex is ProtocolException || ex is FaultException || ex is Exception)
            {
                throw ex;
            }
            return result;
        }
        public async Task<(GetCommandListResponseDto Response, RawSoapDetails SoapDetails)> GetCommandList(GetCommandListRequestDto dto)
        {
            (GetCommandListResponseDto Response, RawSoapDetails SoapDetails) result = (default, default);
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
                var requestInterceptorBehavior = new SCRAv2InspectorBehavior();
                svcClient.Endpoint.EndpointBehaviors.Add(requestInterceptorBehavior);
                var svcResponse = await svcClient.GetCommandListAsync(soapRequest);
                result.SoapDetails = new RawSoapDetails();
                result.SoapDetails.RequestXml = requestInterceptorBehavior.LastRequestXML;
                result.SoapDetails.ResponseXml = requestInterceptorBehavior.LastResponseXML;

                if (svcResponse != null)
                {
                    result.Response = new GetCommandListResponseDto();
                    result.Response.CustomerTransactionId = svcResponse.CustomerTransactionId;
                    result.Response.MagTranId = svcResponse.MagTranId;
                    result.Response.Commands = new System.Collections.Generic.List<Dtos.Command>();
                    svcResponse.Commands.ToList().ForEach(x =>
                    {
                        var temp = new Dtos.Command()
                        {
                            CommandType = x.CommandType,
                            Description = x.Description,
                            ExecutionTypeEnum = x.ExecutionTypeEnum,
                            ID = x.ID,
                            Name = x.Name,
                            Value = x.Value
                        };
                        result.Response.Commands.Add(temp);
                    });
                }
            }
            catch (Exception ex) when (ex is CommunicationException || ex is ProtocolException || ex is FaultException || ex is Exception)
            {
                throw ex;
            }
            return result;
        }
        public async Task<(GetFirmwareByMUTResponseDto Response, RawSoapDetails SoapDetails)> GetFirmwareByMUT(GetFirmwareByMUTRequestDto dto)
        {
            (GetFirmwareByMUTResponseDto Response, RawSoapDetails SoapDetails) result = (default, default);
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
                var requestInterceptorBehavior = new SCRAv2InspectorBehavior();
                svcClient.Endpoint.EndpointBehaviors.Add(requestInterceptorBehavior);
                var svcResponse = await svcClient.GetFirmwareByMUTAsync(soapRequest);
                result.SoapDetails = new RawSoapDetails();
                result.SoapDetails.RequestXml = requestInterceptorBehavior.LastRequestXML;
                result.SoapDetails.ResponseXml = requestInterceptorBehavior.LastResponseXML;

                if (svcResponse != null)
                {
                    result.Response = new GetFirmwareByMUTResponseDto();
                    result.Response.CustomerTransactionId = svcResponse.CustomerTransactionId;
                    result.Response.MagTranId = svcResponse.MagTranId;
                    result.Response.Firmware = new Dtos.Firmware();
                    result.Response.Firmware.DateCreated = svcResponse.Firmware.DateCreated;
                    result.Response.Firmware.DateModified = svcResponse.Firmware.DateModified;
                    result.Response.Firmware.Description = svcResponse.Firmware.Description;
                    result.Response.Firmware.File = svcResponse.Firmware.File;
                    result.Response.Firmware.ID = svcResponse.Firmware.ID;
                    result.Response.Firmware.Name = svcResponse.Firmware.Name;
                    result.Response.Firmware.PartNumber = svcResponse.Firmware.PartNumber;
                    result.Response.Firmware.PostloadCommands = new List<Dtos.FirmwareCommand>();
                    svcResponse.Firmware.PostloadCommands.ToList().ForEach(x =>
                    {
                        var temp = new Dtos.FirmwareCommand() { Value = x.Value, Operation = x.Operation };
                        result.Response.Firmware.PostloadCommands.Add(temp);
                    });
                    result.Response.Firmware.PreloadCommands = new List<Dtos.FirmwareCommand>();
                    svcResponse.Firmware.PreloadCommands.ToList().ForEach(x =>
                    {
                        var temp = new Dtos.FirmwareCommand() { Value = x.Value, Operation = x.Operation };
                        result.Response.Firmware.PreloadCommands.Add(temp);
                    });
                    result.Response.Firmware.TargetID = svcResponse.Firmware.TargetID;
                    result.Response.Firmware.Type = svcResponse.Firmware.Type;
                    result.Response.Firmware.Version = svcResponse.Firmware.Version;
                }
            }
            catch (Exception ex) when (ex is CommunicationException || ex is ProtocolException || ex is FaultException || ex is Exception)
            {
                throw ex;
            }
            return result;
        }
        public async Task<(GetFirmwareCommandsResponseDto Response, RawSoapDetails SoapDetails)> GetFirmwareCommands(GetFirmwareCommandsRequestDto dto)
        {
            (GetFirmwareCommandsResponseDto Response, RawSoapDetails SoapDetails) result = (default, default);
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
                    Firmware = System.Text.Encoding.UTF8.GetBytes(dto.Firmware),
                    KSN = dto.KSN,
                    KeyID = dto.KeyID,
                    SerialNumber = dto.SerialNumber,
                    AdditionalRequestData = dto.AdditionalRequestData.ToArray()
                };
                var svcClient = new Magensa.SCRAv2.Services.SCRAv2Client();
                var requestInterceptorBehavior = new SCRAv2InspectorBehavior();
                svcClient.Endpoint.EndpointBehaviors.Add(requestInterceptorBehavior);
                var svcResponse = await svcClient.GetFirmwareCommandsAsync(soapRequest);
                result.SoapDetails = new RawSoapDetails();
                result.SoapDetails.RequestXml = requestInterceptorBehavior.LastRequestXML;
                result.SoapDetails.ResponseXml = requestInterceptorBehavior.LastResponseXML;

                if (svcResponse != null)
                {
                    result.Response = new GetFirmwareCommandsResponseDto();
                    result.Response.CustomerTransactionId = svcResponse.CustomerTransactionId;
                    result.Response.MagTranId = svcResponse.MagTranId;
                    result.Response.Commands = new List<string>();
                    svcResponse.Commands.ToList().ForEach(x =>
                    {
                        result.Response.Commands.Add(x);
                    });
                    result.Response.PostloadCommands = new List<Dtos.FirmwareCommand>();
                    svcResponse.PostloadCommands.ToList().ForEach(x =>
                    {
                        result.Response.PostloadCommands.Add(new Dtos.FirmwareCommand()
                        {
                            Operation = x.Operation,
                            Value = x.Value
                        });
                    });
                    result.Response.PreloadCommands = new List<Dtos.FirmwareCommand>();
                    svcResponse.PreloadCommands.ToList().ForEach(x =>
                    {
                        result.Response.PreloadCommands.Add(new Dtos.FirmwareCommand()
                        {
                            Operation = x.Operation,
                            Value = x.Value
                        });
                    });
                }
            }
            catch (Exception ex) when (ex is CommunicationException || ex is ProtocolException || ex is FaultException || ex is Exception)
            {
                throw ex;
            }
            return result;
        }
        public async Task<(GetFirmwareListResponseDto Response, RawSoapDetails SoapDetails)> GetFirmwareList(GetFirmwareListRequestDto dto)
        {
            (GetFirmwareListResponseDto Response, RawSoapDetails SoapDetails) result = (default, default);
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
                var requestInterceptorBehavior = new SCRAv2InspectorBehavior();
                svcClient.Endpoint.EndpointBehaviors.Add(requestInterceptorBehavior);
                var svcResponse = await svcClient.GetFirmwareListAsync(soapRequest);
                result.SoapDetails = new RawSoapDetails();
                result.SoapDetails.RequestXml = requestInterceptorBehavior.LastRequestXML;
                result.SoapDetails.ResponseXml = requestInterceptorBehavior.LastResponseXML;
                if (svcResponse != null)
                {
                    result.Response = new GetFirmwareListResponseDto();
                    result.Response.CustomerTransactionId = svcResponse.CustomerTransactionId;
                    result.Response.MagTranId = svcResponse.MagTranId;
                    result.Response.Firmwares = new List<Dtos.Firmware>();
                    foreach (var f in svcResponse.Firmwares.ToList())
                    {
                        var fw = new Dtos.Firmware();
                        fw.DateCreated = f.DateCreated;
                        fw.DateModified = f.DateModified;
                        fw.Description = f.Description;
                        fw.File = f.File;
                        fw.ID = f.ID;
                        fw.Name = f.Name;
                        fw.PartNumber = f.PartNumber;

                        if (f.PostloadCommands != null)
                        {
                            fw.PostloadCommands = new List<Dtos.FirmwareCommand>();
                            foreach (var plc in f.PostloadCommands)
                            {
                                fw.PostloadCommands.Add(new Dtos.FirmwareCommand()
                                {
                                    Operation = plc.Operation,
                                    Value = plc.Value
                                });

                            }
                        }
                        if (f.PreloadCommands != null)
                        {
                            fw.PreloadCommands = new List<Dtos.FirmwareCommand>();
                            foreach (var plc in f.PreloadCommands)
                            {
                                fw.PreloadCommands.Add(new Dtos.FirmwareCommand()
                                {
                                    Operation = plc.Operation,
                                    Value = plc.Value
                                });
                            }
                        }
                        fw.TargetID = f.TargetID;
                        fw.Type = f.Type;
                        fw.Version = f.Version;
                        result.Response.Firmwares.Add(fw);
                    }
                }
            }
            catch (Exception ex) when (ex is CommunicationException || ex is ProtocolException || ex is FaultException || ex is Exception)
            {
                throw ex;
            }
            return result;
        }
        public async Task<(GetKeyListResponseDto Response, RawSoapDetails SoapDetails)> GetKeyList(GetKeyListRequestDto dto)
        {
            (GetKeyListResponseDto Response, RawSoapDetails SoapDetails) result = (default, default);
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


                var svcClient = new Magensa.SCRAv2.Services.SCRAv2Client();
                var requestInterceptorBehavior = new SCRAv2InspectorBehavior();
                svcClient.Endpoint.EndpointBehaviors.Add(requestInterceptorBehavior);
                var svcResponse = await svcClient.GetKeyListAsync(soapRequest);
                result.SoapDetails = new RawSoapDetails();
                result.SoapDetails.RequestXml = requestInterceptorBehavior.LastRequestXML;
                result.SoapDetails.ResponseXml = requestInterceptorBehavior.LastResponseXML;
                if (svcResponse != null)
                {
                    result.Response = new GetKeyListResponseDto();
                    result.Response.CustomerTransactionId = svcResponse.CustomerTransactionId;
                    result.Response.MagTranId = svcResponse.MagTranId;
                    result.Response.ScravKeys = new List<Dtos.SCRAvkey>();
                    foreach (var key in svcResponse.Keys.ToList())
                    {
                        result.Response.ScravKeys.Add(new Dtos.SCRAvkey
                        {
                            Description = key.Description,
                            ID = key.ID,
                            KeyName = key.KeyName,
                            KeySlotNamePrefix = key.KeySlotNamePrefix,
                            KSI = key.KSI

                        });
                    }
                }
            }
            catch (Exception ex) when (ex is CommunicationException || ex is ProtocolException || ex is FaultException || ex is Exception)
            {
                throw ex;
            }
            return result;
        }
        public async Task<(GetKeyLoadCommandResponseDto Response, RawSoapDetails SoapDetails)> GetKeyLoadCommand(GetKeyLoadCommandRequestDto dto)
        {
            (GetKeyLoadCommandResponseDto Response, RawSoapDetails SoapDetails) result = (default, default);
            try
            {
                var soapRequest = new GetKeyLoadCommandRequest
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
                var requestInterceptorBehavior = new SCRAv2InspectorBehavior();
                svcClient.Endpoint.EndpointBehaviors.Add(requestInterceptorBehavior);
                var svcResponse = await svcClient.GetKeyLoadCommandAsync(soapRequest);
                result.SoapDetails = new RawSoapDetails();
                result.SoapDetails.RequestXml = requestInterceptorBehavior.LastRequestXML;
                result.SoapDetails.ResponseXml = requestInterceptorBehavior.LastResponseXML;
                if (svcResponse != null)
                {
                    result.Response = new GetKeyLoadCommandResponseDto();
                    result.Response.CustomerTransactionId = svcResponse.CustomerTransactionId;
                    result.Response.MagTranId = svcResponse.MagTranId;
                    result.Response.Commands = new List<Dtos.Command>();
                    foreach (var cmd in svcResponse.Commands.ToList())
                    {
                        result.Response.Commands.Add(new Dtos.Command
                        {
                            CommandType = cmd.CommandType,
                            Description = cmd.Description,
                            ExecutionTypeEnum = cmd.ExecutionTypeEnum,
                            ID = cmd.ID,
                            Name = cmd.Name,
                            Value = cmd.Value
                        });
                    }
                }
            }
            catch (Exception ex) when (ex is CommunicationException || ex is ProtocolException || ex is FaultException || ex is Exception)
            {
                throw ex;
            }
            return result;
        }
    }
}
