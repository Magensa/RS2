using EMV.Dtos;

namespace EMV.ServiceFactory
{
    public interface IEMVClient
    {
        GetEMVCommandsResponseDto GetEMVCommands(GetEMVCommandsRequestDto dto);
    }
}
