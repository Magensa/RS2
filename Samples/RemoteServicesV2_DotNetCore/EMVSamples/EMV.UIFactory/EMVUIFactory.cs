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
using static System.Console;


namespace EMV.UIFactory
{
    /// <summary>
    /// Factory of EMV operations
    /// </summary>
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
                WriteLine("=====================Request building start======================");
                request.CustomerCode = Read_String_Input("Please enter the CustomerCode:", false);
                request.Username = Read_String_Input("Please enter the Username:", false);
                request.Password = Read_String_Input("Please enter the Password:", false);
                request.BillingLabel = Read_String_Input("Please enter the BillingLabel:", true);
                request.CustomerTransactionId = Read_String_Input("Please enter the CustomerTransactionID:", true);
                request.AdditionalRequestData = Read_MultipleKeysInput("AdditionalRequestData");
                request.EMVCommandType = Read_EMVCommandType_Input("Please enter the EMVCommandType:");
                request.DeviceType = Read_DeviceType_Input("Please enter the DeviceType:", request.EMVCommandType);
                request.KSN = Read_String_Input("Please enter the KSN:", false);
                request.KeyName = Read_String_Input("Please enter the KeyName:", false);
                request.SerialNumber = Read_String_Input("Please enter the SerialNumber:", false);
                request.XMLString = Read_LongString_Input("Please enter the XMLString:", false);

                WriteLine("=====================Request building End======================");
                var svc = _serviceProvider.GetService<IEMVClient>();
                var result = svc.GetEMVCommands(request);
                if ((result.Response != null) && (result.SoapDetails != null))
                {
                    WriteLine("Request:");
                    Write(PrettyXml(result.SoapDetails.RequestXml) + "\n");
                    WriteLine("=====================Response Start======================");
                    WriteLine("Response:");
                    Write(PrettyXml(result.SoapDetails.ResponseXml) + "\n");
                    WriteLine("=====================Response End======================");
                    WriteLine("=====================Parsed Response Start======================");
                    WriteLine($"{nameof(result.Response.AdditionalOutputData)} : { result.Response.AdditionalOutputData }");
                    result.Response.Commands.ForEach(cmd =>
                    {
                        WriteLine($"{nameof(cmd.CommandType)} : { cmd.CommandType}");
                        WriteLine($"{nameof(cmd.Description)} : { cmd.Description}");
                        WriteLine($"{nameof(cmd.ID)} : { cmd.ID}");
                        WriteLine($"{nameof(cmd.Name)} : { cmd.Name}");
                        WriteLine($"{nameof(cmd.Value)} : { cmd.Value}");
                        WriteLine($"{nameof(cmd.ExecutionTypeEnum)} : { cmd.ExecutionTypeEnum}");
                    });
                    WriteLine($"{nameof(result.Response.CustomerTransactionId)} : { result.Response.CustomerTransactionId }");
                    WriteLine($"{nameof(result.Response.MagTranId)} : { result.Response.MagTranId }");
                    result.Response.PostloadCommands.ForEach(cmd =>
                    {
                        WriteLine($"{nameof(cmd.CommandType)} : { cmd.CommandType}");
                        WriteLine($"{nameof(cmd.Description)} : { cmd.Description}");
                        WriteLine($"{nameof(cmd.ID)} : { cmd.ID}");
                        WriteLine($"{nameof(cmd.Name)} : { cmd.Name}");
                        WriteLine($"{nameof(cmd.Value)} : { cmd.Value}");
                        WriteLine($"{nameof(cmd.ExecutionTypeEnum)} : { cmd.ExecutionTypeEnum}");
                    });
                    result.Response.PreloadCommands.ForEach(cmd =>
                    {
                        WriteLine($"{nameof(cmd.CommandType)} : { cmd.CommandType}");
                        WriteLine($"{nameof(cmd.Description)} : { cmd.Description}");
                        WriteLine($"{nameof(cmd.ID)} : { cmd.ID}");
                        WriteLine($"{nameof(cmd.Name)} : { cmd.Name}");
                        WriteLine($"{nameof(cmd.Value)} : { cmd.Value}");
                        WriteLine($"{nameof(cmd.ExecutionTypeEnum)} : { cmd.ExecutionTypeEnum}");
                    });
                    WriteLine("=====================Parsed Response End======================");

                }
                else
                {
                    WriteLine("Response is null, Please check with input values given and try again");
                }
            }
            catch (Exception ex)
            {
                WriteLine("Error: " + ex.Message.ToString());
            }
        }

        #region Helper Functions
        private static string Read_String_Input(string question, bool isOptional)
        {
            WriteLine(question);
            var ans = ReadLine();
            if ((!isOptional) && string.IsNullOrWhiteSpace(ans))
            {
                return Read_String_Input(question, isOptional);
            }
            return ans;
        }
        /// <summary>
        /// Accepts large string input, as the default string implemenattion has limitations.
        /// </summary>
        /// <param name="userMessage"></param>
        /// <param name="isOptional"></param>
        /// <returns></returns>
        private static string Read_LongString_Input(string userMessage, bool isOptional)
        {
            WriteLine(userMessage);
            byte[] inputBuffer = new byte[2621444];
            Stream inputStream = OpenStandardInput(262144);
            SetIn(new StreamReader(inputStream, InputEncoding, false, inputBuffer.Length));
            string strInput = ReadLine();
            if ((!isOptional) && string.IsNullOrWhiteSpace(strInput))
            {
                return Read_LongString_Input(userMessage, isOptional);
            }
            return strInput;
        }
        /// <summary>
        /// check string is a valid xml or not
        /// </summary>
        /// <param name="xml"></param>
        /// <returns>A boolean output as the xml string is parsed</returns>
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
        /// <returns>A formatted string xml</returns>
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
                WriteLine("Invalid Input.");
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

        private static readonly string EMVTag_CommandType = "EMVTag";
        private static readonly string CAPK_CommandType = "CAPK";
        private static string Read_EMVCommandType_Input(string question)
        {
            List<string> emvCommandTypes = new List<string> { EMVTag_CommandType, CAPK_CommandType };
            WriteLine($"{question} ({string.Join<string>(",", emvCommandTypes)})");
            var ans = ReadLine();
            if (emvCommandTypes.Contains<string>(ans))
                return ans;
            else
            {
                WriteLine("Invalid Input.");
                return Read_EMVCommandType_Input(question);
            }
        }

        private static string Read_DeviceType_Input(string question, string emvCommandType)
        {
            if (emvCommandType.Trim().ToUpper() == EMVTag_CommandType.Trim().ToUpper())
            {
                List<string> deviceTypes = new List<string> { "DynaPro", "eDynamo" };

                WriteLine($"{question} ({string.Join<string>(",", deviceTypes)})");
                var ans = ReadLine();
                if (deviceTypes.Contains<string>(ans))
                    return ans;
                else
                {
                    WriteLine("Invalid Input.");
                    return Read_DeviceType_Input(question, emvCommandType);
                }
            }
            if (emvCommandType.Trim().ToUpper() == CAPK_CommandType.Trim().ToUpper())
            {
                List<string> deviceTypes = new List<string> { "DynaPro", "eDynamo", "oDynamo", "DynaWave " };
                WriteLine($"{question} ({string.Join<string>(",", deviceTypes)})");
                var ans = ReadLine();
                if (string.IsNullOrEmpty(ans))
                {
                    WriteLine($"Device Type will be considered as {deviceTypes[0]} (default)");
                    ans = deviceTypes[0];
                }

                if (deviceTypes.Contains<string>(ans))
                    return ans;
                else
                {
                    WriteLine("Invalid Input.");
                    return Read_DeviceType_Input(question, emvCommandType);
                }
            }
            throw new Exception($"Invalid EMVCommandType({emvCommandType})");
        }
        #endregion
    }
}
