using Labo_RegEx_InputTextCLI_Sung.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labo_RegEx_InputTextCLI_Sung.Services
{
    public class DataService
    {
        private InputText _dataForRegEx = new InputText();
        public InputText DataForRegEx { get => _dataForRegEx; set => _dataForRegEx = value; }

        private bool _dataForRegExDefault = false;
        public bool DataForRegExDefault { get => _dataForRegExDefault; set => _dataForRegExDefault = value; }

        public DataService()
        {

        }

        public string CheckData()
        {
            string result = "none";

            if (DataForRegEx.InputTextValue != null)
            {
                result = "Data was found\n";
                result += "Return to command menu and use option PerformRegEx";
            }
            else
            {
                result = "Initial data was not found\n";
                result += "Return to command menu and use option AddInitialData";
            }
            return result;
        }

        public string AddDefaultData()
        {
            string result = "none";

            if (DataForRegExDefault == true)
            {
                result = "Default Data was already added\n";
                result += "Return to command menu and use option PerformRegEx";
            }
            else
            {
                result = "Default data adding ...\n";
                DataForRegEx.AddDefaultData();
                DataForRegExDefault = true;
            }
            return result;
        }

        public string UploadYourData(string input)
        {
            string result = "none";

            if (input != null && input != string.Empty)
            {
                result = $"Valid input given \n";
                result += "Your data adding ...\n";
                DataForRegEx.AddYourData(input);
                DataForRegExDefault = false;
            }
            else
            {
                result = $"Invalid input given";
            }

            return result;
        }

        public string PrintData()
        {
            string result = "none";

            if(DataForRegEx.InputTextValue != null && DataForRegEx.InputTextValue != string.Empty)
            {
                result = DataForRegEx.InputTextValue;
            }
            else
            {
                result = $"No data found";
            }

            return result;
        }
    }
}
