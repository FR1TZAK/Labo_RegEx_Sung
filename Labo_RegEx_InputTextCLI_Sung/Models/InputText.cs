using System;
using System.Collections.Generic;
using System.Text;

namespace Labo_RegEx_InputTextCLI_Sung.Models
{
    public class InputText
    {
        public string InputTextValue { get; set; }


        public InputText()
        {

        }

        public void AddDefaultData()
        {
            InputTextValue =
        $"Be nothing customary at except the of clearly, switching well TUESDAY, 31ST MARCH 2020 57 minutes ago To copy, " +
        $"duties high the hand, subordinates world candidates, you up he a to saw the accustomed to dipshits from futurama. " +
        $"Oh Shit, Git!?! https://ohshitgit.com/ With and last instead even Git is fun, screwing up is easy and figuring out " +
        $"there he been italic, the so to the screen one you couldn't I or of to we at as between a emerge everyday. " +
        $"We to seeing in officer. And children even be the listen. Service, magicians relief. Richer noting been were up more " +
        $"he legs, in this in of overhauls days, were attained the all them, a because sleep world I in and a around the you " +
        $"problem. In would couple didn't and with often lay impasse. New theory suggests universe is a simulation, nothing is real. " +
        $"Source: https://video.foxbusiness.com/v/6219345230001/. And him its road http://www.caminoantwerp.com men, with importance, " +
        $"try the lots and term themselves, alone o'clock which, sentences sat here's met descriptions, few of but release the " +
        $"walls. At did like has touch this from it occupied must curse alarm reasoning torn soon phase he it hides camel my found. " +
        $"https://www.linkedin.com/pulse/after-work-what-determines-your-future-spend-one-hour-sundaram Jack Ma: after work is what " +
        $"determines your future! Spend 1 hour per day doing these 5 things and your life will change forever! May 19, 2016 LinkedIn." +
        $"To set made in https://coinmarketcap.com/ of distance with differentiates way as the thoughts their somehow been win your then " +
        $"everything and the absolutely packed let the too him judgment, and life the attempt, accept systematic www.codeproject.com of " +
        $"high be an a to an based not concise through file://yourfile or using FTP ftp://yourserver.info any address with a protocol to " +
        $"projected devious the some of I may harmonics, of and trial. Aylin Hay CEO Ticslogy Estates LLP ahay@mail.com. Greater, " +
        $"attempt, seven might there, all must and occupied on the got a respond have the but paint, in right themselves surprise " +
        $"arrives proceeded purpose sign in to ticket keep background which of new expectations.That note the ever have work all nor " +
        $"target and. Cruz McLaughlin Head of Business, Bronscan, cmclaughlin@bronscan.bt. Visit at https://medium.com";

        }


        public void AddYourData(string input)
        {
            InputTextValue = input;
        }

        public override string ToString()
        {
            return $"{InputTextValue}";
        }

    }
}
