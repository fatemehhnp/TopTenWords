using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTenWords.Utility
{ 
    //Interface for TopWords class
    public interface ITopWords
    {
        Dictionary<string, int> GetTopWords(string url);
    }
}
