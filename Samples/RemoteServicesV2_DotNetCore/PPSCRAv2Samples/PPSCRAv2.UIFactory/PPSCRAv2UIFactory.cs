using Microsoft.Extensions.DependencyInjection;
using PPSCRAv2.Dtos;
using PPSCRAv2.ServiceFactory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace PPSCRAv2.UIFactory
{
    public class PPSCRAv2UIFactory : IPPSCRAv2UIFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public PPSCRAv2UIFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public void ShowUI(PPSCRAv2UI scrav2UI)
        {
            switch (scrav2UI)
            {
                case PPSCRAv2UI.GetCertLoadCommand:
                    ShowGetCertLoadCommandUI();
                    break;
                case PPSCRAv2UI.GetCommandListByDevice:
                    ShowGetCommandListByDeviceUI();
                    break;
                case PPSCRAv2UI.GetDeviceAuthCommand:
                    ShowGetDeviceAuthCommandUI();
                    break;
                case PPSCRAv2UI.GetEnableSREDCommand:
                    ShowGetEnableSREDCommandUI();
                    break;
                case PPSCRAv2UI.GetKeyList:
                    ShowGetKeyListUI();
                    break;
                case PPSCRAv2UI.GetKeyLoadCommand:
                    ShowGetKeyLoadCommandUI();
                    break;
                case PPSCRAv2UI.GetLoadConfigCommand:
                    ShowGetLoadConfigCommandUI();
                    break;
                case PPSCRAv2UI.GetPreActivateCommand:
                    ShowGetPreActivateCommandUI();
                    break;

            }
        }

        private void ShowGetCertLoadCommandUI()
        {
            var request = new GetCertLoadCommandRequestDto();
            try
            {
                Console.WriteLine("=====================Request building start======================");
                request.CustomerCode = Read_String_Input("Please enter the CustomerCode:", false);
                request.Username = Read_String_Input("Please enter the Username:", false);
                request.Password = Read_String_Input("Please enter the Password:", false);
                request.BillingLabel = Read_String_Input("Please enter the BillingLabel:", true);
                request.CustomerTransactionId = Read_String_Input("Please enter the CustomerTransactionID:", true);
                request.AdditionalRequestData = Read_MultipleKeysInput("AdditionalRequestData");
                request.Challenge = Read_Challenge_Input("Please enter the Challenge:", false);
                request.DeviceType = Read_String_Input("Please enter the DeviceType:", false);
                request.KSN = Read_String_Input("Please enter the KSN:", false);
                request.KeyType = Read_KeyType_Input("Please enter the KeyType:");
                Console.WriteLine("=====================Request building End======================");
                var svc = _serviceProvider.GetService<IPPSCRAv2Client>();
                var responseDto = svc.GetCertLoadCommand(request).Result;
                if (responseDto != null)
                {
                    var response = responseDto as GetCertLoadCommandResponseDto;
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
        private void ShowGetCommandListByDeviceUI()
        {
            var request = new GetCommandListByDeviceRequestDto();
            try
            {
                Console.WriteLine("=====================Request building start======================");
                request.CustomerCode = Read_String_Input("Please enter the CustomerCode:", false);
                request.Username = Read_String_Input("Please enter the Username:", false);
                request.Password = Read_String_Input("Please enter the Password:", false);
                request.BillingLabel = Read_String_Input("Please enter the BillingLabel:", true);
                request.CustomerTransactionId = Read_String_Input("Please enter the CustomerTransactionID:", true);
                request.AdditionalRequestData = Read_MultipleKeysInput("AdditionalRequestData");
                request.DeviceType = Read_DeviceType_Input("Please enter the DeviceType:");

                Console.WriteLine("=====================Request building End======================");
                var svc = _serviceProvider.GetService<IPPSCRAv2Client>();
                var responseDto = svc.GetCommandListByDevice(request).Result;
                if (responseDto != null)
                {
                    var response = responseDto as GetCommandListByDeviceResponseDto;
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
        private void ShowGetDeviceAuthCommandUI()
        {
            var request = new GetDeviceAuthCommandRequestDto();
            try
            {
                Console.WriteLine("=====================Request building start======================");
                request.CustomerCode = Read_String_Input("Please enter the CustomerCode:", false);
                request.Username = Read_String_Input("Please enter the Username:", false);
                request.Password = Read_String_Input("Please enter the Password:", false);
                request.BillingLabel = Read_String_Input("Please enter the BillingLabel:", true);
                request.CustomerTransactionId = Read_String_Input("Please enter the CustomerTransactionID:", true);
                request.AdditionalRequestData = Read_MultipleKeysInput("AdditionalRequestData");
                request.Challenge = Read_Challenge_Input("Please enter the Challenge:", false);
                request.DeviceCert = Read_LongString_Input("Please enter the DeviceCert:", false);
                request.DeviceType = Read_DeviceType_Input("Please enter the DeviceType:");
                request.KeyType = Read_KeyType_Input1("Please enter the KeyType:");

                Console.WriteLine("=====================Request building End======================");
                var svc = _serviceProvider.GetService<IPPSCRAv2Client>();
                var responseDto = svc.GetDeviceAuthCommand(request).Result;
                if (responseDto != null)
                {
                    var response = responseDto as GetDeviceAuthCommandResponseDto;
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
        private void ShowGetEnableSREDCommandUI()
        {
            var request = new GetEnableSREDCommandRequestDto();
            try
            {
                Console.WriteLine("=====================Request building start======================");
                request.CustomerCode = Read_String_Input("Please enter the CustomerCode:", false);
                request.Username = Read_String_Input("Please enter the Username:", false);
                request.Password = Read_String_Input("Please enter the Password:", false);
                request.BillingLabel = Read_String_Input("Please enter the BillingLabel:", true);
                request.CustomerTransactionId = Read_String_Input("Please enter the CustomerTransactionID:", true);
                request.AdditionalRequestData = Read_MultipleKeysInput("AdditionalRequestData");
                request.Challenge = Read_Challenge_Input("Please enter the Challenge:", false);
                request.DeviceType = Read_DeviceType_Input("Please enter the DeviceType:");
                request.KSN = Read_String_Input("Please enter the KSN:", false);
                request.WhiteListType = Read_String_Input("Please enter the WhiteListType:", true);

                Console.WriteLine("=====================Request building End======================");
                var svc = _serviceProvider.GetService<IPPSCRAv2Client>();
                var responseDto = svc.GetEnableSREDCommand(request).Result;
                if (responseDto != null)
                {
                    var response = responseDto as GetEnableSREDCommandResponseDto;
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
        private void ShowGetKeyListUI()
        {
            var request = new GetKeyListRequestDto();
            try
            {
                Console.WriteLine("=====================Request building start======================");
                request.CustomerCode = Read_String_Input("Please enter the CustomerCode:", false);
                request.Username = Read_String_Input("Please enter the Username:", false);
                request.Password = Read_String_Input("Please enter the Password:", false);
                request.BillingLabel = Read_String_Input("Please enter the BillingLabel:", true);
                request.CustomerTransactionId = Read_String_Input("Please enter the CustomerTransactionID:", true);


                Console.WriteLine("=====================Request building End======================");
                var svc = _serviceProvider.GetService<IPPSCRAv2Client>();
                var responseDto = svc.GetKeyList(request).Result;
                if (responseDto != null)
                {
                    var response = responseDto as GetKeyListResponseDto;
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
        private void ShowGetKeyLoadCommandUI()
        {
            var request = new GetKeyLoadCommandRequestDto();
            try
            {
                Console.WriteLine("=====================Request building start======================");
                request.CustomerCode = Read_String_Input("Please enter the CustomerCode:", false);
                request.Username = Read_String_Input("Please enter the Username:", false);
                request.Password = Read_String_Input("Please enter the Password:", false);
                request.BillingLabel = Read_String_Input("Please enter the BillingLabel:", true);
                request.CustomerTransactionId = Read_String_Input("Please enter the CustomerTransactionID:", true);
                request.AdditionalRequestData = Read_MultipleKeysInput("AdditionalRequestData");
                request.Challenge = Read_Challenge_Input("Please enter the Challenge:", false);
                request.DeviceCert = Read_DeviceCert_Input("Please enter the DeviceCert:", false);
                request.DeviceType = Read_DeviceType_Input("Please enter the DeviceType:");
                request.KSN = Read_String_Input("Please enter the KSN:", false);
                request.KSI = request.KSN.Substring(0, 7);
                request.KeyType = Read_KeyType_Input("Please enter the KeyType:");

                Console.WriteLine("=====================Request building End======================");
                var svc = _serviceProvider.GetService<IPPSCRAv2Client>();
                var responseDto = svc.GetKeyLoadCommand(request).Result;
                if (responseDto != null)
                {
                    var response = responseDto as GetKeyLoadCommandResponseDto;
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
        private void ShowGetLoadConfigCommandUI()
        {
            var request = new GetLoadConfigCommandRequestDto();
            try
            {
                Console.WriteLine("=====================Request building start======================");
                request.CustomerCode = Read_String_Input("Please enter the CustomerCode:", false);
                request.Username = Read_String_Input("Please enter the Username:", false);
                request.Password = Read_String_Input("Please enter the Password:", false);
                request.BillingLabel = Read_String_Input("Please enter the BillingLabel:", true);
                request.CustomerTransactionId = Read_String_Input("Please enter the CustomerTransactionID:", true);
                request.AdditionalRequestData = Read_MultipleKeysInput("AdditionalRequestData");
                request.Challenge = Read_Challenge_Input("Please enter the Challenge:", false);
                request.DeviceConfigCommands = Read_multipleConfigueCommands("Please enter Configue commands").ToArray();
                request.DeviceType = Read_DeviceType_Input("Please enter the DeviceType:");
                request.ExistingConfig = Read_String_Input("Please enter the ExistingConfig:", true);
                request.KSN = Read_String_Input("Please enter the KSN:", false);
                request.KeyType = Read_KeyType_Input1("Please enter the KeyType:");

                Console.WriteLine("=====================Request building End======================");
                var svc = _serviceProvider.GetService<IPPSCRAv2Client>();
                var responseDto = svc.GetLoadConfigCommand(request).Result;
                if (responseDto != null)
                {
                    var response = responseDto as GetLoadConfigCommandResponseDto;
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
        private void ShowGetPreActivateCommandUI()
        {
            var request = new GetPreActivateCommandRequestDto();
            try
            {
                Console.WriteLine("=====================Request building start======================");
                request.CustomerCode = Read_String_Input("Please enter the CustomerCode:", false);
                request.Username = Read_String_Input("Please enter the Username:", false);
                request.Password = Read_String_Input("Please enter the Password:", false);
                request.BillingLabel = Read_String_Input("Please enter the BillingLabel:", true);
                request.CustomerTransactionId = Read_String_Input("Please enter the CustomerTransactionID:", true);
                request.AdditionalRequestData = Read_MultipleKeysInput("AdditionalRequestData");
                request.Challenge = Read_Challenge_Input("Please enter the Challenge:", false);
                request.DeviceType = Read_DeviceType_Input("Please enter the DeviceType:");
                request.KSN = Read_String_Input("Please enter the KSN:", false);
                request.KeyType = Read_KeyType_Input("Please enter the KeyType:");
                request.OrderID = Read_String_Input("Please enter the OrderID:", false);
                request.TechID = Read_String_Input("Please enter the TechID:", false);

                Console.WriteLine("=====================Request building End======================");
                var svc = _serviceProvider.GetService<IPPSCRAv2Client>();
                var responseDto = svc.GetPreActivateCommand(request).Result;
                if (responseDto != null)
                {
                    var response = responseDto as GetPreActivateCommandResponseDto;
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

        private static string Read_ExecutionType_Input(string question)
        {
            List<string> keyTypes = new List<string> { "ALL", "KSN", "MUT" };
            Console.WriteLine(question);
            var ans = Console.ReadLine();
            if (keyTypes.Contains<string>(ans))
                return ans;
            else
            {
                Console.WriteLine("Invalid Input.");
                return Read_ExecutionType_Input(question);
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
        private static string Read_KeyType_Input(string question)
        {
            List<string> keyTypes = new List<string> { "PIN", "MSR", "AMK" };
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
        private static string Read_KeyType_Input1(string question)
        {
            List<string> keyTypes = new List<string> { "PIN", "MSR" };
            Console.WriteLine(question);
            var ans = Console.ReadLine();
            if (keyTypes.Contains<string>(ans))
                return ans;
            else
            {
                Console.WriteLine("Invalid Input.");
                return Read_KeyType_Input1(question);
            }
        }
        private static string Read_DeviceType_Input(string question)
        {
            List<string> deviceTypes = new List<string> { "DynaPro", "DynaProGO", "oDynamo", "Generic", "NotSpecified" };
            Console.WriteLine(question);
            var ans = Console.ReadLine();
            if (deviceTypes.Contains<string>(ans))
                return ans;
            else
            {
                Console.WriteLine("Invalid Input.");
                return Read_DeviceType_Input(question);
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
            byte[] inputBuffer = new byte[262144];
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
        private static string Read_Challenge_Input(string question, bool isOptional)
        {
            var ans = Read_String_Input(question, isOptional);
            if (ans.Length < 28)
            {
                Console.WriteLine("Input cannot be greater then 28 characters");
                return Read_String_Input(question, isOptional);
            }
            return ans;
        }
        private static string Read_DeviceCert_Input(string question, bool isOptional)
        {
            var ans = Read_LongString_Input(question, isOptional);
            if (ans.Length < 1908)
            {
                Console.WriteLine("Input cannot be greater then 1908 characters");
                return Read_LongString_Input(question, isOptional);
            }
            return ans;
        }
        private static int Read_Int_Input(string userMessage)
        {
            Console.WriteLine(userMessage);
            var userInputVal = Console.ReadLine();
            if ((string.IsNullOrWhiteSpace(userInputVal)) || (!userInputVal.All(char.IsDigit)))
            {
                Console.WriteLine("Invalid Input.");
                return Read_Int_Input(userMessage);
            }
            return int.Parse(userInputVal);
        }
        private static List<DeviceConfigCommanddto> Read_multipleConfigueCommands(string question)
        {
            var noOfKeys = Read_Intuser_Input($"Please Enter No of Keys for {question}");
            var result = new List<DeviceConfigCommanddto>();
            for (int i = 0; i < noOfKeys; i++)
            {
                var commandid = Read_Intuser_Input("CommandId");
                var confgueVal = Read_Intuser_Input("ConfigData");
                DeviceConfigCommanddto d = new DeviceConfigCommanddto
                {
                    DeviceConfigCommand_CommandId = commandid,
                    DeviceConfigCommand_ConfigData = confgueVal
                };
                result.Add(d);
            }
            return result;

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
