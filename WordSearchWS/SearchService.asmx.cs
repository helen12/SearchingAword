using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WordSearchWS
{
    /// <summary>
    /// Summary description for SearchService
    /// </summary>
    [WebService(Namespace = "http://helenswebservice.com/webservice")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SearchService : System.Web.Services.WebService
    {

        [WebMethod]
        public string Search(string sentence, String serachKey)
        {
             String theFoundWord = "";
            try
            {
                if (sentence.Length == 0)
                {
                    throw new myExeption();
                }


                //check if the sentence is only  string
                bool hasNumber = false;
                string[] words = sentence.Split(' ');// adding the sentence in to array of words

                // this loop is used to check if each of the string is a valid string

                for (int j = 0; j < words.Length; j++)
                {
                    if (words[j].Any(char.IsDigit))//check each inputted word is not a number
                    {
                        hasNumber = true;
                        break;
                    }
                }
                if (hasNumber == true)
                {

                    throw new myExeption("The Sentence has number please enter another sentence");
                }



               

                if (serachKey.Length == 0)// check if no searching key is entered
                {
                    throw new myExeption("No Searching key entered", serachKey.Length);
                }

                //check if the searchíng key is valid string
                if (serachKey.Any(char.IsDigit))
                {
                    bool validSearchKey = false;
                    throw new myExeption("No valid searching key entered", validSearchKey);
                }




               

                bool found = false;
                for (int i = 0; i <= words.Length - 1; i++)
                {
                    if (serachKey == words[i])
                    {
                        found = true;
                        theFoundWord = words[i];
                        break;
                    }


                }
                if (found != true)

                     theFoundWord= "Unable to find the result for the word " ;

                

            }

            catch (myExeption me)
            {
                Console.WriteLine(me.Message);

            }




            return theFoundWord;
           
        }
    }

    public class myExeption : Exception
    {
        public myExeption()
        {

        }

        public myExeption(string message)
            : base(message)
        {

        }

        public myExeption(string message, int length)
            : base(message)
        {
        }
        public myExeption(string message, bool validSearch)
            : base(message)
        {
        }
    }
}
