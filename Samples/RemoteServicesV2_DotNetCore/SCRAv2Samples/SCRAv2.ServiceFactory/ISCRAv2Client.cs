using SCRAv2.Dtos;
using System.Threading.Tasks;

namespace SCRAv2.ServiceFactory
{
    public interface ISCRAv2Client
    {
        Task<(GetCommandByKSNResponseDto Response, RawSoapDetails SoapDetails)> GetCommandByKSN(GetCommandByKSNRequestDto dto);
        Task<(GetCommandByMUTResponseDto Response, RawSoapDetails SoapDetails)> GetCommandByMUT(GetCommandByMUTRequestDto dto);
        Task<(GetCommandListResponseDto Response, RawSoapDetails SoapDetails)> GetCommandList(GetCommandListRequestDto dto);
        Task<(GetFirmwareByMUTResponseDto Response, RawSoapDetails SoapDetails)> GetFirmwareByMUT(GetFirmwareByMUTRequestDto dto);
        Task<(GetFirmwareCommandsResponseDto Response, RawSoapDetails SoapDetails)> GetFirmwareCommands(GetFirmwareCommandsRequestDto dto);
        Task<(GetFirmwareListResponseDto Response, RawSoapDetails SoapDetails)> GetFirmwareList(GetFirmwareListRequestDto dto);
        Task<(GetKeyListResponseDto Response, RawSoapDetails SoapDetails)> GetKeyList(GetKeyListRequestDto dto);
        Task<(GetKeyLoadCommandResponseDto Response, RawSoapDetails SoapDetails)> GetKeyLoadCommand(GetKeyLoadCommandRequestDto dto);
    }
}
