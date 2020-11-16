using PPSCRAv2.Dtos;
using System.Threading.Tasks;

namespace PPSCRAv2.ServiceFactory
{
    public interface IPPSCRAv2Client
    {
        Task<GetCertLoadCommandResponseDto> GetCertLoadCommand(GetCertLoadCommandRequestDto dto);
        Task<GetCommandListByDeviceResponseDto> GetCommandListByDevice(GetCommandListByDeviceRequestDto dto);
        Task<GetDeviceAuthCommandResponseDto> GetDeviceAuthCommand(GetDeviceAuthCommandRequestDto dto);
        Task<GetEnableSREDCommandResponseDto> GetEnableSREDCommand(GetEnableSREDCommandRequestDto dto);
        Task<GetKeyListResponseDto> GetKeyList(GetKeyListRequestDto dto);
        Task<GetKeyLoadCommandResponseDto> GetKeyLoadCommand(GetKeyLoadCommandRequestDto dto);
        Task<GetLoadConfigCommandResponseDto> GetLoadConfigCommand(GetLoadConfigCommandRequestDto dto);
        Task<GetPreActivateCommandResponseDto> GetPreActivateCommand(GetPreActivateCommandRequestDto dto);
    }
}
