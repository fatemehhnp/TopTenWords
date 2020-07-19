using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTenWords.Utility
{
    //this class contains function for calculating the top 10 words in a text file
    public class TopWords
    {
        /*private declarationfor ifilereader interface (it was implemented in seperate file
          for test purpose)and inject it to
         constracture as an optional parameter and if its null, it will be instantiate with a new instance of
         class
        */
        private IFileReader _Reader;
        public TopWords(IFileReader Reader=null)
        {
            _Reader = Reader??new FileReader();
        }
        //returns dictionary of string and integer for words and number of accurances
        public Dictionary<string, int> GetTopWords(string url)
        {
            //gets the base path and combine it with the relative text file
            var path = AppDomain.CurrentDomain.BaseDirectory + url;
            //check if file exist with the given path
            if (File.Exists(path))
            {
                //reads all line of file and if its empty pass the suitable to a new dictionary and inform user
                var lines = _Reader.ReadFileLines(url);
                //checks if file is not empty
                if (lines.Count() != 0)
                {
                    /*filter non-empty lines of the file and replace parantheses in the line with empy
                     space and split the words with an array of relative seperators, groups and make 
                     new type of word and their count, sort in a descending order by words count and takes the top 10 
                     and convert it to dictionary
                     */
                    var topwords = lines.Where(line => line != "").ToList().Select(s => s.Replace('(', ' ').Replace(')', ' '))
                        .Select(x => x.Split(new[] { ',',' ','.','*','©','.',':','-','/','=',
            '_','~','?',';','"'}, StringSplitOptions.RemoveEmptyEntries)).ToList().SelectMany(word => word)
                    .GroupBy(word => word).Select(g => new { Word = g.Key, Count = g.Count() })
                    .OrderByDescending(w => w.Count)
                    .Take(10).ToDictionary(w => w.Word, w => w.Count);
                    return topwords;
                }
                else
                {
                    return new Dictionary<string, int> {
                        {"file is empty",0 }
                    };
                }
            }
            else
            {
                return new Dictionary<string, int>
                {
                    {"file path is not valid",0 }
                };
            }
        }
    }
}