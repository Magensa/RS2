using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.Xml;

namespace EMV.ServiceFactory
{
    /// <summary>
    /// writes custom soap body
    /// </summary>
    public class EMVBodyWriter : BodyWriter
    {
        private readonly string body;
        public List<KeyValuePair<string, string>> ModifyTags { get; set; }
        public EMVBodyWriter(string strData) : base(true)
        {
            body = strData;
        }
        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            var modifiedBody = body;
            if (ModifyTags != null)
            {
                foreach (var item in ModifyTags)
                {
                    if ((item.Key.Trim() == "") && (item.Value.Trim() == ""))
                    {
                        //no need to modify
                    }
                    else
                    {
                        modifiedBody = modifiedBody.Replace(item.Key, item.Value);
                    }
                }
            }
            writer.WriteRaw(modifiedBody);
        }
    }
}
