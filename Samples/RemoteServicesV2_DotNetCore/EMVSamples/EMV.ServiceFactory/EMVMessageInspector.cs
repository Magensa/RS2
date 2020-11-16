using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Xml;

namespace EMV.ServiceFactory
{
    public class EMVMessageInspector : IClientMessageInspector
    {
        public string LastRequestXML { get; private set; }
        public string LastResponseXML { get; private set; }
        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            LastResponseXML = reply.ToString();
        }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            var soapAction = request.Headers.Action;
            XmlDictionaryReader bodyReader = request.GetReaderAtBodyContents();
            var soapXml= bodyReader.ReadOuterXml();
            EMVBodyWriter newBody = new EMVBodyWriter(soapXml);
            Message replacedMessage = Message.CreateMessage(request.Version, soapAction, newBody);
            replacedMessage.Properties.CopyProperties(request.Properties);
            request = replacedMessage;
            LastRequestXML = request.ToString();
            return request;
        }
    }
}
