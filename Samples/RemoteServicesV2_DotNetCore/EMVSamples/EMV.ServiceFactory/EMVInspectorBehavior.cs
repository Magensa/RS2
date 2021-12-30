using System.Collections.Generic;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace EMV.ServiceFactory
{
    /// <summary>
    /// defines soap inspector beharior
    /// </summary>
    public class EMVInspectorBehavior : IEndpointBehavior
    {
        private readonly EMVMessageInspector myMessageInspector = new EMVMessageInspector();

        public List<KeyValuePair<string, string>> ModifyTags { get; set; }
        /// <summary>
        /// Last requested soap xml
        /// </summary>
        public string LastRequestXML
        {
            get
            {
                return myMessageInspector.LastRequestXML;
            }
        }
        /// <summary>
        /// Last received response soap xml
        /// </summary>
        public string LastResponseXML
        {
            get
            {
                return myMessageInspector.LastResponseXML;
            }
        }


        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {

        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {

        }

        public void Validate(ServiceEndpoint endpoint)
        {

        }


        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            myMessageInspector.ModifyTags = ModifyTags;
            clientRuntime.ClientMessageInspectors.Add(myMessageInspector);
        }
    }
}
