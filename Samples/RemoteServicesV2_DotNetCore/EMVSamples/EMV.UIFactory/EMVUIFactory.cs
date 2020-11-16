using EMV.Dtos;
using EMV.ServiceFactory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;


namespace EMV.UIFactory
{
    public class EMVUIFactory : IEMVUIFactory
    {
        readonly IServiceProvider _serviceProvider;

        public EMVUIFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void ShowUI(EMVUI emvUI)
        {
            switch (emvUI)
            {
                case EMVUI.GETEMVCOMMANDS:
                    ShowGetEMVCommandsUI();
                    break;
            }
        }

        private void ShowGetEMVCommandsUI()
        {
            var request = new GetEMVCommandsRequestDto();
            try
            {
                Console.WriteLine("=====================Request building start======================");
                request.CustomerCode = Read_String_Input("Please enter the CustomerCode:", false);
                request.Username = Read_String_Input("Please enter the Username:", false);
                request.Password = Read_String_Input("Please enter the Password:", false);
                request.BillingLabel = Read_String_Input("Please enter the BillingLabel:", true);
                request.CustomerTransactionId = Read_String_Input("Please enter the CustomerTransactionID:", true);
                request.AdditionalRequestData = Read_MultipleKeysInput("AdditionalRequestData");
                request.DeviceType = Read_String_Input("Please enter the DeviceType:", true);
                request.EMVCommandType = Read_String_Input("Please enter the EMVCommandType:", true);
                request.KSN = Read_String_Input("Please enter the KSN:", false);
                request.KeyName = Read_String_Input("Please enter the KeyName:", false);
                request.SerialNumber = Read_String_Input("Please enter the SerialNumber:", false);
                request.XMLString = Read_LongString_Input("Please enter the XMLString:", false);

                Console.WriteLine("=====================Request building End======================");
                var svc = _serviceProvider.GetService<IEMVClient>();
                var responseDto = svc.GetEMVCommands(request);
                if (responseDto != null)
                {
                    var response = responseDto as GetEMVCommandsResponseDto;
                    Console.WriteLine("=====================Response Start======================");
                    Console.WriteLine("Response:");
                    Console.Write(PrettyXml(response.PageContent) + "\n");
                    Console.WriteLine("=====================Response End======================");
                }
                else
                {
                    Console.WriteLine("Response is null, Please check with input values given and try again");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message.ToString());
            }
        }


        #region Helper Functions
        private static string Read_KeyType_Input(string question)
        {
            List<string> keyTypes = new List<string> { "Pin", "Data" };
            Console.WriteLine(question);
            var ans = Console.ReadLine();
            if (keyTypes.Contains<string>(ans))
                return ans;
            else
            {
                Console.WriteLine("Invalid Input.");
                return Read_KeyType_Input(question);
            }
        }
        private static string Read_KeyDerivationType_Input(string question)
        {
            List<string> keyDerivationTypes = new List<string> { "DUKPT", "Fix" };
            Console.WriteLine(question);
            var ans = Console.ReadLine();
            if (keyDerivationTypes.Contains<string>(ans))
                return ans;
            else
            {
                Console.WriteLine("Invalid Input.");
                return Read_KeyDerivationType_Input(question);
            }
        }
        private static string Read_String_Input(string question, bool isOptional)
        {
            Console.WriteLine(question);
            var ans = Console.ReadLine();
            if ((!isOptional) && string.IsNullOrWhiteSpace(ans))
            {
                return Read_String_Input(question, isOptional);
            }
            return ans;
        }
        private static string Read_LongString_Input(string userMessage, bool isOptional)
        {
            Console.WriteLine(userMessage);
            byte[] inputBuffer = new byte[2621444];
            Stream inputStream = Console.OpenStandardInput(262144);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));
            string strInput = Console.ReadLine();
            if ((!isOptional) && string.IsNullOrWhiteSpace(strInput))
            {
                return Read_LongString_Input(userMessage, isOptional);
            }
            return strInput;
        }
        public static bool IsValidXml(string xml)
        {
            try
            {
                XDocument.Parse(xml);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static string PrettyXml(string xml)
        {
            if (IsValidXml(xml)) //print xml in beautiful format
            {
                var stringBuilder = new StringBuilder();
                var element = XElement.Parse(xml);
                var settings = new XmlWriterSettings
                {
                    OmitXmlDeclaration = true,
                    Indent = true,
                    NewLineOnAttributes = true
                };
                using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
                {
                    element.Save(xmlWriter);
                }
                return stringBuilder.ToString();
            }
            else
            {
                return xml;
            }
        }

        private static List<KeyValuePair<string, string>> Read_MultipleKeysInput(string question)
        {
            var noOfKeys = Read_Intuser_Input($"Please Enter No of Keys for {question}");
            var result = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < noOfKeys; i++)
            {
                var key = Read_Optional_String_Input("Key");
                var val = Read_Optional_String_Input("Value");
                result.Add(new KeyValuePair<string, string>(key, val));
            }
            return result;
        }
        private static int Read_Intuser_Input(string question)
        {
            var ans = Read_Mandatory_String_Input(question);
            try
            {
                var temp = int.Parse(ans);
                return temp;
            }
            catch
            {
                Console.WriteLine("Invalid Input.");
                return Read_Intuser_Input(question);
            }
        }
        private static string Read_Optional_String_Input(string question)
        {
            return Read_String_Input($"{question}:", true);
        }
        private static string Read_Mandatory_String_Input(string question)
        {
            return Read_String_Input($"{question}:", false);
        }
        #endregion
    }
}
