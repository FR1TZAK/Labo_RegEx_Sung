using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Labo_RegEx_InputTextCLI_Sung.Services
{
    public class RegExService
    {
        private MatchCollection _regexExpressionMatches = null;
        public MatchCollection RegexExpressionMatches { get => _regexExpressionMatches; set => _regexExpressionMatches = value; }

        private List<string> _matchStrings = new List<string>();
        public List<string> MatchStrings { get => _matchStrings; set => _matchStrings = value; }

        private Dictionary<string, Regex> _regexDictionary = new Dictionary<string, Regex>();
        public Dictionary<string, Regex> RegexDictionary { get => _regexDictionary; set => _regexDictionary = value; }


        public RegExService()
        {
            // regex for web address
            RegexDictionary.Add("webaddress-all", new Regex("((?<protocol>([Hh][Tt][Tt][Pp][Ss]?://)|([Ff][Tt][Pp]://)){1}([A-Za-z]{1,})(\\.{1}[A-Za-z]{1,})(\\.{1}[A-Za-z]{1,})?[/]?[.]*)|((?<protocol>[Ff][Ii][Ll][Ee]://){1}([A-Za-z]{1,})[.]*)|(([Ww]{3})(\\.{1}[A-Za-z]{1,})(\\.{1}[A-Za-z]{1,})[/]?[.]*)"));
            RegexDictionary.Add("webaddress-http(s)", new Regex("((?<protocol>[Hh][Tt][Tt][Pp][Ss]?://){1}([A-Za-z]{1,})(\\.{1}[A-Za-z]{1,})(\\.{1}[A-Za-z]{1,})?[/]?[.]*)"));
            RegexDictionary.Add("webaddress-ftp", new Regex("((?<protocol>[Ff][Tt][Pp]://){1}([A-Za-z]{1,})(\\.{1}[A-Za-z]{1,})(\\.{1}[A-Za-z]{1,})?[/]?[.]*)"));
            RegexDictionary.Add("webaddress-file", new Regex("((?<protocol>[Ff][Ii][Ll][Ee]://){1}([A-Za-z]{1,})[.]*)"));
            RegexDictionary.Add("webaddress-www", new Regex("(([Ww]{3})(\\.{1}[A-Za-z]{1,})(\\.{1}[A-Za-z]{1,})[/]?[.]*)"));

            // regex for email address
            RegexDictionary.Add("emailaddress-all", new Regex("(?<name>[\\w\\.-]+)@(?<server>[\\w\\.-]+)"));

            // regex for belgian phone numbers
            RegexDictionary.Add("belgianphonenumber-all", new Regex("(?<tel>\\b0[\\d]{8}\\b)|(?<mobile>\\b04[\\d]{8}\\b)"));

        }


        public int CountMatches(string text, string filter)
        {
            int count = 0;

            if (text != null && text != string.Empty)
            {
                RegexExpressionMatches = RegexDictionary[filter].Matches(text);
                count = RegexExpressionMatches.Count;
            }

            return count;
        }


        public List<string> GetMatches()
        {
            MatchStrings.Clear();

            MatchStrings.AddRange(
                RegexExpressionMatches
                    .Cast<Match>()
                    .Select(m => m.Groups[0].Value).ToList()
                    ); ;

            return MatchStrings;
        }

        public List<string> GetMatchesByGroupName(string groupName)
        {
            MatchStrings.Clear();

            MatchStrings.AddRange(
                RegexExpressionMatches
                    .Cast<Match>()
                    .Select(m => m.Groups[groupName].Value).ToList()
                    );

            return MatchStrings;
        }

        public List<string> GetMatchesByGroupNameAndValue(string groupName, string groupValue)
        {
            MatchStrings.Clear();

            MatchStrings.AddRange(
                RegexExpressionMatches
                    .Cast<Match>()
                    .Where(f => f.Groups[groupName].Value.Contains(groupValue))
                    .Select(m => m.Groups[0].Value).ToList()
                    );

            return MatchStrings;
        }

        public bool CheckValid(string text, string filter)
        {
            bool valid = false;


            if (text != null && text != string.Empty)
            {
                RegexExpressionMatches = RegexDictionary[filter].Matches(text);
                int count = 0;
                count = RegexExpressionMatches.Count;

                if(count == 1)
                {
                    valid = true;
                }
                else
                {
                    valid = false;
                }
            }

            return valid;
        }


    }
}
