using SCRAv2.Dtos;
using System.Threading.Tasks;

namespace SCRAv2.ServiceFactory
{
    public interface ISCRAv2Client
    {
        Task<GetCommandByKSNResponseDto> GetCommandByKSN(GetCommandByKSNRequestDto dto);
        Task<GetCommandByMUTResponseDto> GetCommandByMUT(GetCommandByMUTRequestDto dto);
        Task<GetCommandListResponseDto> GetCommandList(GetCommandListRequestDto dto);
        Task<GetFirmwareListResponseDto> GetFirmwareList(GetFirmwareListRequestDto dto);
        Task<GetKeyListResponseDto> GetKeyList(GetKeyListRequestDto dto);
        Task<GetFirmwareByMUTResponseDto> GetFirmwareByMUT(GetFirmwareByMUTRequestDto dto);
        Task<GetFirmwareCommandsResponseDto> GetFirmwareCommands(GetFirmwareCommandsRequestDto dto);
        Task<GetKeyLoadCommandResponseDto> GetKeyLoadCommand(GetKeyLoadCommandRequestDto dto);
    }
}
