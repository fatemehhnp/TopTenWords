using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopTenWords.Utility;

namespace TopTenWords
{
    class Program
    {
        static void Main(string[] args)
        {
            /*I used console app to implement the Number of 10 top words in the text file. I implemented the requied
             function in topwords class, I wanted to install ninject framework for implementing dependency
             injection, but I thought its better not to complicate the code for a small application*/
             //instantiate top words class
            var mytopwords = new TopWords();
            //calling Gettopwords to return the dictionary of top 10 words and their accurances
            //also returns the error message in key if filepath is not valid or if text file is empty
            var result = mytopwords.GetTopWords(@"Test.txt");
            //print each top 10 words with their accurances and their rank in console
            result.ToList().ForEach(x => Console.WriteLine(string.Format("the top {0} word are: {1} with {2} accurences",
            result.ToList().IndexOf(x) + 1, x.Key, x.Value)));
            Console.Read();
        }
    }
}
