using EMV.Dtos;

namespace EMV.ServiceFactory
{
    public interface IEMVClient
    {
        (GetEMVCommandsResponseDto Response, RawSoapDetails SoapDetails) GetEMVCommands(GetEMVCommandsRequestDto dto);
    }
}
