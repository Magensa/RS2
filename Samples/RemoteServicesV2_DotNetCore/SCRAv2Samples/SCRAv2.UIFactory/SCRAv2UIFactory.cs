using Microsoft.Extensions.DependencyInjection;
using SCRAv2.Dtos;
using SCRAv2.ServiceFactory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace SCRAv2.UIFactory
{
    /// <summary>
    /// Factory of SCRAv2 Operations
    /// </summary>    
    public class SCRAv2UIFactory : ISCRAv2UIFactory
    {
        readonly IServiceProvider _serviceProvider;

        public SCRAv2UIFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public void ShowUI(SCRAv2UI scrav2UI)
        {
            switch (scrav2UI)
            {
                case SCRAv2UI.GetCommandByKSN:
                    ShowGetCommandByKsnUI();
                    break;
                case SCRAv2UI.GETCOMMANDBYMUT:
                    ShowGetCommandByMUTUI();
                    break;
                case SCRAv2UI.GETCOMMANDLIST:
                    ShowGetCommandListUI();
                    break;
                case SCRAv2UI.GETFIRMWARELIST:
                    ShowGetFirmwareListUI();
                    break;
                case SCRAv2UI.GETKEYLIST:
                    ShowGetKeyListUI();
                    break;
                case SCRAv2UI.GETFIRMWAREBYMUT:
                    ShowGetFirmwareByMUTUI();
                    break;
                case SCRAv2UI.GETFIRMWARECOMMANDS:
                    ShowGetFirmwareCommandsUI();
                    break;
                case SCRAv2UI.GETKEYLOADCOMMAND:
                    ShowGetKeyLoadCommandUI();
                    break;
            }
        }

        private void ShowGetCommandByKsnUI()
        {
            var request = new GetCommandByKSNRequestDto();
            try
            {
                Console.WriteLine("=====================Request building start======================");
                request.CustomerCode = Read_String_Input("Please enter the CustomerCode:", false);
                request.Username = Read_String_Input("Please enter the Username:", false);
                request.Password = Read_String_Input("Please enter the Password:", false);
                request.BillingLabel = Read_String_Input("Please enter the BillingLabel:", true);
                request.CustomerTransactionId = Read_String_Input("Please enter the CustomerTransactionID:", true);
                request.CommandID = Read_Int_Input("Please enter the CommandID:");
                request.KSN = Read_String_Input("Please enter the KSN:", false);
                request.KeyID = Read_Int_Input("Please enter the KeyID:");

                Console.WriteLine("=====================Request building End======================");
                var svc = _serviceProvider.GetService<ISCRAv2Client>();
                var result = svc.GetCommandByKSN(request).Result;
                if ((result.Response != null) && (result.SoapDetails != null))
                {
                    Console.WriteLine("=====================Response Start======================");
                    Console.WriteLine("Request:");
                    Console.Write(PrettyXml(result.SoapDetails.RequestXml) + "\n");
                    Console.WriteLine("Response:");
                    Console.Write(PrettyXml(result.SoapDetails.ResponseXml) + "\n");
                    Console.WriteLine("=====================Response End======================");
                    Console.WriteLine("=====================Parsed Response Start======================");
                    Console.WriteLine(result.Response.ToString());
                    Console.WriteLine("=====================Parsed Response End======================");
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
        private void ShowGetCommandByMUTUI()
        {
            var request = new GetCommandByMUTRequestDto();
            try
            {
                Console.WriteLine("=====================Request building start======================");
                request.CustomerCode = Read_String_Input("Please enter the CustomerCode:", false);
                request.Username = Read_String_Input("Please enter the Username:", false);
                request.Password = Read_String_Input("Please enter the Password:", false);
                request.BillingLabel = Read_String_Input("Please enter the BillingLabel:", true);
                request.CustomerTransactionId = Read_String_Input("Please enter the CustomerTransactionID:", true);
                request.CommandID = Read_Int_Input("Please enter the CommandID:");
                request.KSN = Read_String_Input("Please enter the KSN:", false);
                request.UpdateToken = Read_String_Input("Please enter the UpdateToken:", false);

                Console.WriteLine("=====================Request building End======================");
                var svc = _serviceProvider.GetService<ISCRAv2Client>();
                var result = svc.GetCommandByMUT(request).Result;
                if ((result.Response != null) && (result.SoapDetails != null))
                {
                    Console.WriteLine("=====================Response Start======================");
                    Console.WriteLine("Request:");
                    Console.Write(PrettyXml(result.SoapDetails.RequestXml) + "\n");
                    Console.WriteLine("Response:");
                    Console.Write(PrettyXml(result.SoapDetails.ResponseXml) + "\n");
                    Console.WriteLine("=====================Response End======================");
                    Console.WriteLine("=====================Parsed Response Start======================");
                    Console.WriteLine(result.Response.ToString());
                    Console.WriteLine("=====================Parsed Response End======================");
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
        private void ShowGetFirmwareByMUTUI()
        {
            var request = new GetFirmwareByMUTRequestDto();
            try
            {
                Console.WriteLine("=====================Request building start======================");
                request.CustomerCode = Read_String_Input("Please enter the CustomerCode:", false);
                request.Username = Read_String_Input("Please enter the Username:", false);
                request.Password = Read_String_Input("Please enter the Password:", false);
                request.BillingLabel = Read_String_Input("Please enter the BillingLabel:", true);
                request.CustomerTransactionId = Read_String_Input("Please enter the CustomerTransactionID:", true);
                request.FirmwareID = Read_Int_Input("Please enter the FirmwareId:");
                request.KSN = Read_String_Input("Please enter the KSN:", false);
                request.UpdateToken = Read_String_Input("Please enter the UpdateToken:", false);

                Console.WriteLine("=====================Request building End======================");
                var svc = _serviceProvider.GetService<ISCRAv2Client>();
                var result = svc.GetFirmwareByMUT(request).Result;
                if ((result.Response != null) && (result.SoapDetails != null))
                {
                    Console.WriteLine("=====================Response Start======================");
                    Console.WriteLine("Request:");
                    Console.Write(PrettyXml(result.SoapDetails.RequestXml) + "\n");
                    Console.WriteLine("Response:");
                    Console.Write(PrettyXml(result.SoapDetails.ResponseXml) + "\n");
                    Console.WriteLine("=====================Response End======================");
                    Console.WriteLine("=====================Parsed Response Start======================");
                    Console.WriteLine(result.Response.ToString());
                    Console.WriteLine("=====================Parsed Response End======================");
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
        private void ShowGetFirmwareCommandsUI()
        {
            var request = new GetFirmwareCommandsRequestDto();
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
                //developer comments: Firmware will have long input 
                //increase the buffer size in Read_LongString_Input function based on the requirement
                request.Firmware = Read_LongString_Input("Please enter the Firmware:", true);
                request.KSN = Read_String_Input("Please enter the KSN:", false);
                request.KeyID = Read_Int_Input("Please enter the KeyID:");
                request.SerialNumber = Read_String_Input("Please enter the SerialNumber:", true);

                Console.WriteLine("=====================Request building End======================");
                var svc = _serviceProvider.GetService<ISCRAv2Client>();
                var result = svc.GetFirmwareCommands(request).Result;
                if ((result.Response != null) && (result.SoapDetails != null))
                {
                    Console.WriteLine("=====================Response Start======================");
                    Console.WriteLine("Request:");
                    Console.Write(PrettyXml(result.SoapDetails.RequestXml) + "\n");
                    Console.WriteLine("Response:");
                    Console.Write(PrettyXml(result.SoapDetails.ResponseXml) + "\n");
                    Console.WriteLine("=====================Response End======================");
                    Console.WriteLine("=====================Parsed Response Start======================");
                    Console.WriteLine(result.Response.ToString());
                    Console.WriteLine("=====================Parsed Response End======================");
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
        private void ShowGetCommandListUI()
        {
            var request = new GetCommandListRequestDto();
            try
            {
                Console.WriteLine("=====================Request building start======================");
                request.CustomerCode = Read_String_Input("Please enter the CustomerCode:", false);
                request.Username = Read_String_Input("Please enter the Username:", false);
                request.Password = Read_String_Input("Please enter the Password:", false);
                request.BillingLabel = Read_String_Input("Please enter the BillingLabel:", true);
                request.CustomerTransactionId = Read_String_Input("Please enter the CustomerTransactionID:", true);
                request.ExecutionType = Read_ExecutionType_Input("Please enter the ExecutionType:");

                Console.WriteLine("=====================Request building End======================");
                var svc = _serviceProvider.GetService<ISCRAv2Client>();
                var result = svc.GetCommandList(request).Result;
                if ((result.Response != null) && (result.SoapDetails != null))
                {
                    Console.WriteLine("=====================Response Start======================");
                    Console.WriteLine("Request:");
                    Console.Write(PrettyXml(result.SoapDetails.RequestXml) + "\n");
                    Console.WriteLine("Response:");
                    Console.Write(PrettyXml(result.SoapDetails.ResponseXml) + "\n");
                    Console.WriteLine("=====================Response End======================");
                    Console.WriteLine("=====================Parsed Response Start======================");
                    Console.WriteLine(result.Response.ToString());
                    Console.WriteLine("=====================Parsed Response End======================");
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
        private void ShowGetFirmwareListUI()
        {
            var request = new GetFirmwareListRequestDto();
            try
            {
                Console.WriteLine("=====================Request building start======================");
                request.CustomerCode = Read_String_Input("Please enter the CustomerCode:", false);
                request.Username = Read_String_Input("Please enter the Username:", false);
                request.Password = Read_String_Input("Please enter the Password:", false);
                request.BillingLabel = Read_String_Input("Please enter the BillingLabel:", true);
                request.CustomerTransactionId = Read_String_Input("Please enter the CustomerTransactionID:", true);
                request.FirmwareType = Read_String_Input("Please enter the FirmwareType:", true);

                Console.WriteLine("=====================Request building End======================");
                var svc = _serviceProvider.GetService<ISCRAv2Client>();
                var result = svc.GetFirmwareList(request).Result;
                if ((result.Response != null) && (result.SoapDetails != null))
                {
                    Console.WriteLine("=====================Response Start======================");
                    Console.WriteLine("Request:");
                    Console.Write(PrettyXml(result.SoapDetails.RequestXml) + "\n");
                    Console.WriteLine("Response:");
                    Console.Write(PrettyXml(result.SoapDetails.ResponseXml) + "\n");
                    Console.WriteLine("=====================Response End======================");
                    Console.WriteLine("=====================Parsed Response Start======================");
                    Console.WriteLine(result.Response.ToString());
                    Console.WriteLine("=====================Parsed Response End======================");
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
                var svc = _serviceProvider.GetService<ISCRAv2Client>();
                var result = svc.GetKeyList(request).Result;
                if ((result.Response != null) && (result.SoapDetails != null))
                {
                    Console.WriteLine("=====================Response Start======================");
                    Console.WriteLine("Request:");
                    Console.Write(PrettyXml(result.SoapDetails.RequestXml) + "\n");
                    Console.WriteLine("Response:");
                    Console.Write(PrettyXml(result.SoapDetails.ResponseXml) + "\n");
                    Console.WriteLine("=====================Response End======================");
                    Console.WriteLine("=====================Parsed Response Start======================");
                    Console.WriteLine(result.Response.ToString());
                    Console.WriteLine("=====================Parsed Response End======================");

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
                request.KSN = Read_String_Input("Please enter the KSN:", false);
                request.KeyID = Read_Int_Input("Please enter the KeyID:");
                request.UpdateToken = Read_String_Input("Please enter the UpdateToken:", false);

                Console.WriteLine("=====================Request building End======================");
                var svc = _serviceProvider.GetService<ISCRAv2Client>();
                var result = svc.GetKeyLoadCommand(request).Result;
                if ((result.Response != null) && (result.SoapDetails != null))
                {
                    Console.WriteLine("=====================Response Start======================");
                    Console.WriteLine("Request:");
                    Console.Write(PrettyXml(result.SoapDetails.RequestXml) + "\n");
                    Console.WriteLine("Response:");
                    Console.Write(PrettyXml(result.SoapDetails.ResponseXml) + "\n");
                    Console.WriteLine("=====================Response End======================");
                    Console.WriteLine("=====================Parsed Response Start======================");
                    Console.WriteLine(result.Response.ToString());
                    Console.WriteLine("=====================Parsed Response End======================");
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
            byte[] inputBuffer = new byte[662144];
            Stream inputStream = Console.OpenStandardInput(262144);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));
            string strInput = Console.ReadLine();
            if ((!isOptional) && string.IsNullOrWhiteSpace(strInput))
            {
                return Read_LongString_Input(userMessage, isOptional);
            }
            return strInput;
        }
        /// <summary>
        /// validates string is a valid xml or not
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Validates the xml string input and returns the formatted xml string
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
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
            var noOfKeys = Read_Int_Input($"Please Enter No of Keys for {question}");
            var result = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < noOfKeys; i++)
            {
                var key = Read_String_Input("Key", true);
                var val = Read_String_Input("Value", true);
                result.Add(new KeyValuePair<string, string>(key, val));
            }
            return result;
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

        #endregion
    }
}
