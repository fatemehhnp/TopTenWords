using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTenWords
{
    /*
      I created readfile in this class because I needed to use it as an external
      dependency in my unit test.
     */
    public class FileReader: IFileReader
    {
        private string basepath=AppDomain.CurrentDomain.BaseDirectory;
        
        public IEnumerable<string> ReadFileLines(string url)
        {
            var result = File.ReadAllLines(basepath+url).ToList();
            return result;
        }
    }
}
