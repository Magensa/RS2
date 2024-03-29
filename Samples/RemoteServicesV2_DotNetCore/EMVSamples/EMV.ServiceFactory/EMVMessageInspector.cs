﻿using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Xml;

namespace EMV.ServiceFactory
{
    /// <summary>
    /// Inspects EMV soap request to modify or to view the soaprequest/soapresponse.
    /// </summary>
    public class EMVMessageInspector : IClientMessageInspector
    {
        public List<KeyValuePair<string, string>> ModifyTags { get; set; }
        public string LastRequestXML { get; private set; }
        public string LastResponseXML { get; private set; }
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            LastResponseXML = reply.ToString();
        }

        public object BeforeSendRequest(ref Message request, System.ServiceModel.IClientChannel channel)
        {
            if ((ModifyTags == null) || (ModifyTags.Count == 0))
            {
                LastRequestXML = request.ToString();
                return request;
            }
            else
            {
                var soapAction = request.Headers.Action;
                XmlDictionaryReader bodyReader = request.GetReaderAtBodyContents();
                var soapXml = bodyReader.ReadOuterXml();
                EMVBodyWriter newBody = new EMVBodyWriter(soapXml);
                newBody.ModifyTags = ModifyTags;
                Message replacedMessage = Message.CreateMessage(request.Version, soapAction, newBody);
                replacedMessage.Properties.CopyProperties(request.Properties);
                request = replacedMessage;
                LastRequestXML = request.ToString();
                return request;
            }
        }
    }
}
