using PPSCRAv2.Dtos;

namespace PPSCRAv2.ServiceFactory
{
    public interface IPPSCRAv2Client
    {
        (GetCertLoadCommandResponseDto Response, RawSoapDetails SoapDetails) GetCertLoadCommand(GetCertLoadCommandRequestDto dto);
        (GetCommandListByDeviceResponseDto Response,RawSoapDetails SoapDetails) GetCommandListByDevice(GetCommandListByDeviceRequestDto dto);
        (GetDeviceAuthCommandResponseDto Response, RawSoapDetails SoapDetails) GetDeviceAuthCommand(GetDeviceAuthCommandRequestDto dto);
        (GetEnableSREDCommandResponseDto Response, RawSoapDetails SoapDetails) GetEnableSREDCommand(GetEnableSREDCommandRequestDto dto);
        (GetKeyListResponseDto Response, RawSoapDetails SoapDetails) GetKeyList(GetKeyListRequestDto dto);
        (GetKeyLoadCommandResponseDto Response, RawSoapDetails SoapDetails) GetKeyLoadCommand(GetKeyLoadCommandRequestDto dto);
        (GetLoadConfigCommandResponseDto Response,RawSoapDetails SoapDetails) GetLoadConfigCommand(GetLoadConfigCommandRequestDto dto);
        (GetPreActivateCommandResponseDto Response,RawSoapDetails SoapDetails) GetPreActivateCommand(GetPreActivateCommandRequestDto dto);
    }
}
