using Labo_RegEx_InputTextCLI_Sung.Services;
using System;

namespace Labo_RegEx_InputTextCLI_Sung
{
    class Program
    {
        static void Main(string[] args)
        {
            // services
            DataService _dataService = new DataService();
            RegExService _regExService = new RegExService();

            // application
            string _inputTextPrimary = string.Empty;
            string _inputTextSecondary = string.Empty;
            string _repeatAction = "y";

            while (_repeatAction == "y")
            {
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine("COMMANDS LIST");
                Console.WriteLine("1. CheckDataForRegEx [1]");
                Console.WriteLine("2. AddDefaultData [2]");
                Console.WriteLine("3. UploadYourData [3]");
                Console.WriteLine("4. PrintDataForRegEx [4]");
                Console.WriteLine("5. PerformRegEx [5]");

                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine("Enter a number to continue: ");
                Console.WriteLine("----------------------------------------------------------------------");
                _inputTextPrimary = Console.ReadLine();


                switch (_inputTextPrimary)
                {
                    case "1":
                        Console.WriteLine("CheckDataForRegEx started ...");
                        Console.WriteLine(_dataService.CheckData()); // using DataService
                        break;
                    case "2":
                        Console.WriteLine("AddDefaultData started ...");
                        Console.WriteLine(_dataService.AddDefaultData()); // using DataService
                        break;
                    case "3":
                        Console.WriteLine("UploadYourData started ...");
                        Console.WriteLine("----------------------------------------------------------------------");
                        Console.WriteLine("Paste your data: ");
                        Console.WriteLine("----------------------------------------------------------------------");
                        _inputTextPrimary = Console.ReadLine();
                        Console.WriteLine(_dataService.UploadYourData(_inputTextPrimary)); // using DataService
                        break;
                    case "4":
                        Console.WriteLine("PrintDataForRegEx started ...");
                        Console.WriteLine(_dataService.PrintData()); // using DataService
                        break;
                    case "5":
                        Console.WriteLine("PerformRegEx started ...");
                        Console.WriteLine("----------------------------------------------------------------------");
                        Console.WriteLine("REGEX COMMAND LIST");
                        Console.WriteLine("1. SearchWebsites [1]");
                        Console.WriteLine("2. SearchEmailAddresses [2]");
                        Console.WriteLine("3. VerifyBelgianPhoneNumberFormatting [3]");
                        Console.WriteLine("----------------------------------------------------------------------");
                        _inputTextPrimary = Console.ReadLine();

                        int matches;
                        bool valid;

                        switch (_inputTextPrimary)
                        {
                            case "1":
                                Console.WriteLine("SearchWebsites started ...");

                                matches = _regExService.CountMatches(_dataService.DataForRegEx.InputTextValue, "webaddress-all");  // using DataService with RegExService

                                if (matches == 0)
                                {
                                    Console.WriteLine("No matches found");
                                }
                                else
                                {
                                    Console.WriteLine($"---------------------------------------");
                                    Console.WriteLine($"{matches} total matches found");
                                    Console.WriteLine($"---------------------------------------");
                                    _regExService.GetMatches().ForEach(Console.WriteLine);  // using RegExService
                                    Console.WriteLine($"---------------------------------------");

                                    matches = _regExService.CountMatches(_dataService.DataForRegEx.InputTextValue, "webaddress-http(s)");  // using DataService with RegExService
                                    Console.WriteLine($"webaddress http(s): {matches} matches");
                                    Console.WriteLine($"---------------------------------------");
                                    _regExService.GetMatchesByGroupNameAndValue("protocol", "http").ForEach(Console.WriteLine);  // using RegExService
                                    Console.WriteLine($"---------------------------------------");

                                    matches = _regExService.CountMatches(_dataService.DataForRegEx.InputTextValue, "webaddress-ftp");  // using DataService with RegExService
                                    Console.WriteLine($"webaddress ftp: {matches} matches");
                                    Console.WriteLine($"---------------------------------------");
                                    _regExService.GetMatchesByGroupNameAndValue("protocol", "ftp").ForEach(Console.WriteLine);  // using RegExService
                                    Console.WriteLine($"---------------------------------------");

                                    matches = _regExService.CountMatches(_dataService.DataForRegEx.InputTextValue, "webaddress-file");  // using DataService with RegExService
                                    Console.WriteLine($"webaddress file: {matches} matches");
                                    Console.WriteLine($"---------------------------------------");
                                    _regExService.GetMatchesByGroupNameAndValue("protocol", "file").ForEach(Console.WriteLine);  // using RegExService
                                    Console.WriteLine($"---------------------------------------");

                                }
                                break;
                            case "2":
                                Console.WriteLine("SearchEmailAddresses started ...");

                                matches = _regExService.CountMatches(_dataService.DataForRegEx.InputTextValue, "emailaddress-all");  // using DataService with RegExService

                                if (matches == 0)
                                {
                                    Console.WriteLine("No matches found");
                                }
                                else
                                {
                                    Console.WriteLine($"---------------------------------------");
                                    Console.WriteLine($"{matches} total matches found");
                                    Console.WriteLine($"---------------------------------------");
                                    _regExService.GetMatches().ForEach(Console.WriteLine);  // using RegExService
                                    Console.WriteLine($"---------------------------------------");

                                    Console.WriteLine($"name:");
                                    Console.WriteLine($"---------------------------------------");
                                    _regExService.GetMatchesByGroupName("name").ForEach(Console.WriteLine);  // using RegExService
                                    Console.WriteLine($"---------------------------------------");

                                    Console.WriteLine($"server:");
                                    Console.WriteLine($"---------------------------------------");
                                    _regExService.GetMatchesByGroupName("server").ForEach(Console.WriteLine);  // using RegExService
                                    Console.WriteLine($"---------------------------------------");
                                }

                                break;
                            case "3":
                                Console.WriteLine("VerifyBelgianPhoneNumberFormatting started ...");
                                Console.WriteLine("----------------------------------------------------------------------");
                                Console.WriteLine("ENTER A BELGIAN PHONE NUMBER");
                                Console.WriteLine("----------------------------------------------------------------------");
                                _inputTextPrimary = Console.ReadLine();

                                valid = _regExService.CheckValid(_inputTextPrimary, "belgianphonenumber-all");  // using DataService with RegExService

                                if (valid == false)
                                {
                                    Console.WriteLine($"{_inputTextPrimary} is NOT a valid belgian phone number");
                                }
                                else
                                {
                                    Console.WriteLine($"{_inputTextPrimary} is a valid belgian phone number");
                                }

                                break;
                            default:
                                Console.WriteLine("Wrong input");
                                Console.WriteLine("Pick another action please");
                                break;
                        }

                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        Console.WriteLine("Pick another action please");
                        break;
                }

                Console.Write($"Repeat operation? (y/n): ");
                _repeatAction = Console.ReadLine();
            }
            Console.ReadKey();
        }
    }

}
